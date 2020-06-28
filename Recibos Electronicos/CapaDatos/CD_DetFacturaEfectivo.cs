using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OracleClient;
using CapaEntidad;
#region Hecho por
//Nombre:      Lisseth Gutiérrez Gómez
//Correo:      lis_go82@hotmail.com
//Institución: Unach
#endregion
namespace CapaDatos
{
    public class CD_DetFacturaEfectivo
    {
        public void DetFacturaEfecInsertar(List<DetConcepto> ListDetConc, int idFactEfec, ref string Verificador)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand Cmd = null;
            try
            {
                CDDatos.StartTrans();
                for (int i = 0; i < ListDetConc.Count; i++)
                {
                    String[] Parametros = { "P_ID_FACT_EFEC", "P_CLAVE_CONCEPTO", "P_DESCRIPCION" };
                    object[] Valores = { idFactEfec, ListDetConc[i].ClaveConcepto, ListDetConc[i].Descripcion };
                    String[] ParametrosOut = { "p_Bandera" };
                    Cmd = CDDatos.GenerarOracleCommand("INS_FACT_EFECT_DETALLE", ref Verificador, Parametros, Valores, ParametrosOut);
                }

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
        public void DetFacturaEfecEliminar(int idFactEfec, ref string Verificador)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand Cmd = null;
            try
            {
                string[] Parametros = { "P_ID_FACT_EFEC" };
                string[] ParametrosOut = { "P_BANDERA" };
                object[] Valores = { idFactEfec };
                Cmd = CDDatos.GenerarOracleCommand("DEL_FACT_EFECT_DETALLE", ref Verificador, Parametros, Valores, ParametrosOut);
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

        public void DetFacturaEfecConsultar(ref List<DetConcepto> ListDetConc, int idFactEfec, ref string Verificador)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand cmm = null;
            try
            {

                OracleDataReader dr = null;

                string[] ParametrosIn ={ "P_ID_FACT_EFEC" };
                Object[] Valores ={ idFactEfec };
                cmm = CDDatos.GenerarOracleCommandCursor("PKG_FELECTRONICA_2016.Obt_Grid_Facturas_Efec_Det", ref dr, ParametrosIn, Valores);

                while (dr.Read())
                {
                    DetConcepto ObjConceptoDet = new DetConcepto();
                    ObjConceptoDet.ClaveConcepto = Convert.ToString(dr.GetValue(0));
                    ObjConceptoDet.Descripcion = Convert.ToString(dr.GetValue(1));
                    ListDetConc.Add(ObjConceptoDet);
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
