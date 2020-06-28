using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data.OracleClient;
using System.Linq;
using System.Text;

namespace CapaDatos
{
    public class CD_Cuotas_Lenguas_SIAE
    {
        public void InsertarCuotasLenguas(ref string Verificador, CuotasLenguasSIAE objCuotas)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand Cmd = null;
            try
            {
                String[] Parametros = { "P_ESCUELA", "P_NIVEL", "P_TIPO" };
                object[] Valores = { objCuotas.Escuela, objCuotas.Nivel, objCuotas.Tipo, objCuotas.Importe_Italiano, objCuotas.Importe_Frances,
                    objCuotas.Importe_Aleman, objCuotas.Importe_Chino, objCuotas.Importe_Tzotzil, objCuotas.Importe_Tzental, objCuotas.Importe_Espaniol
                };
                String[] ParametrosOut = { "p_Bandera" };
                Cmd = CDDatos.GenerarOracleCommand("INS_CUOTAS_LENGUAS", ref Verificador, Parametros, Valores, ParametrosOut);
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
        public void ConsultarCuotasLenguas(CuotasLenguasSIAE ObjCuotas, ref List<CuotasLenguasSIAE> List)
        {
            CD_Datos CDDatos = new CD_Datos("INGRESOS");
            OracleCommand cmm = null;
            try
            {

                OracleDataReader dr = null;               
                string[] ParametrosIn = { "P_Escuela", "P_Tipo" };
                Object[] Valores = { ObjCuotas.Escuela, ObjCuotas.Tipo };
                cmm = CDDatos.GenerarOracleCommandCursor("PKG_PAGOS_2016.Obt_Grid_Cuotas_Lenguas", ref dr, ParametrosIn, Valores);                

                while (dr.Read())
                {
                    ObjCuotas = new CuotasLenguasSIAE();
                    ObjCuotas.Id = Convert.ToInt32(dr[0]);
                    ObjCuotas.Escuela = Convert.ToString(dr[1]);
                    ObjCuotas.Status = Convert.ToString(dr[2]);
                    ObjCuotas.Nivel = Convert.ToInt32(dr[3]);
                    ObjCuotas.Importe_Ingles = Convert.ToDouble(dr[4]);
                    ObjCuotas.Importe_Italiano = Convert.ToDouble(dr[5]);
                    ObjCuotas.Importe_Frances = Convert.ToDouble(dr[6]);
                    ObjCuotas.Importe_Aleman = Convert.ToDouble(dr[7]);
                    ObjCuotas.Importe_Chino = Convert.ToDouble(dr[8]);
                    ObjCuotas.Importe_Tzotzil = Convert.ToDouble(dr[9]);
                    ObjCuotas.Importe_Tzental = Convert.ToDouble(dr[10]);
                    ObjCuotas.Importe_Espaniol = Convert.ToDouble(dr[11]);
                    List.Add(ObjCuotas);

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
