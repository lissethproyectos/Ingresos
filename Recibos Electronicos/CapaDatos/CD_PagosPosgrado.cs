using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data.OracleClient;
using System.Linq;
using System.Text;

namespace CapaDatos
{
    public class CD_PagosPosgrado
    {
        public void ConsultarPagosPosgrado(PagosPosgrado ObjPagoPosgrado, ref List<PagosPosgrado> List)
        {
            CD_Datos CDDatos = new CD_Datos("SIAE");
            OracleCommand cmm = null;
            try
            {
                OracleDataReader dr = null;

                string[] Parametros = { "P_Matricula", "P_Escuela", "P_CARRERA" };
                object[] Valores = { ObjPagoPosgrado.Matricula, ObjPagoPosgrado.Escuela, ObjPagoPosgrado.Carrera };

                cmm = CDDatos.GenerarOracleCommandCursor("PKG_POSGRADO.Obt_Grid_Pagos", ref dr, Parametros, Valores);
                while (dr.Read())
                {
                    PagosPosgrado objPagos = new PagosPosgrado();
                    objPagos.IdRef = Convert.ToInt32(dr[7]);
                    objPagos.Concepto = Convert.ToString(dr[5]);
                    objPagos.No_Pago = Convert.ToInt32(dr[1]);
                    objPagos.Importe = Convert.ToDouble(dr[2]);
                    objPagos.Referencia = Convert.ToString(dr[3]);
                    objPagos.Fecha_Pago = Convert.ToString(dr[4]);
                    objPagos.Semestre = Convert.ToInt32(dr[6]);
                    objPagos.IdPago = Convert.ToInt32(dr[8]);
                    objPagos.Ciclo_Actual = Convert.ToString(dr[9]);
                    List.Add(objPagos);
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
        public void EditarPagosPosgrado(PagosPosgrado ObjPagoPosgrado, ref string Verificador)
        {
            CD_Datos CDDatos = new CD_Datos("SIAE");
            OracleCommand Cmd = null;

            try
            {
                String[] Parametros = { "P_ID_REF", "P_SEMESTRE", "P_NO_PAGO", "P_ID_PAGO", "P_CICLO_ACTUAL" };
                object[] Valores = { ObjPagoPosgrado.IdRef, ObjPagoPosgrado.Semestre, ObjPagoPosgrado.No_Pago, ObjPagoPosgrado.IdPago,
                ObjPagoPosgrado.Ciclo_Actual
                };
                String[] ParametrosOut = { "P_BANDERA" };

                Cmd = CDDatos.GenerarOracleCommand("UPD_PAGO_POSGRADO", ref Verificador, Parametros, Valores, ParametrosOut);

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