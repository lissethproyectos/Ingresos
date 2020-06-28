using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OracleClient;
using System.IO;
using CapaEntidad;

namespace CapaDatos
{
    public class CD_DetFactura
    {
        public void DetFacturaInsertar(ref DetFactura ObjDetFactura, ref string Verificador)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand Cmd = null;
            try
            {
                String[] Parametros = { "P_ID_FACTURA", "P_CLAVE_CONCEPTO", "P_DESCRIPCION_CONCEPTO", "P_CANTIDAD", 
                                        "P_VALOR_UNITARIO", "P_IMPORTE"
                                      };
                object[] Valores = { ObjDetFactura.ID_FACT, ObjDetFactura.ClaveConcepto, ObjDetFactura.DescConcepto, ObjDetFactura.Cantidad,
                                   ObjDetFactura.ValorUnitario, ObjDetFactura.Importe};
                String[] ParametrosOut = { "p_Bandera" };

                Cmd = CDDatos.GenerarOracleCommand("INS_FACTURA_DETALLE", ref Verificador, Parametros, Valores, ParametrosOut);


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
        public void DetFacturaAgregar(int IdFact, List<DetFactura> listDetFact, ref string Verificador)
        {
            if (listDetFact.Count >= 1)
            {
                for (int i = 0; i < listDetFact.Count; i++)
                {
                    CD_Datos CDDatos = new CD_Datos();
                    OracleCommand Cmd = null;
                    try
                    {
                        String[] Parametros = { "P_ID_FACTURA", "P_CLAVE_CONCEPTO", "P_DESCRIPCION_CONCEPTO", "P_CANTIDAD",
                                        "P_VALOR_UNITARIO", "P_IMPORTE"
                                      };
                        object[] Valores = { IdFact, listDetFact[i].ClaveConcepto, listDetFact[i].DescConcepto, listDetFact[i].Cantidad,
                                   listDetFact[i].ValorUnitario, listDetFact[i].Importe};
                        String[] ParametrosOut = { "p_Bandera" };

                        Cmd = CDDatos.GenerarOracleCommand("INS_FACTURA_DETALLE", ref Verificador, Parametros, Valores, ParametrosOut);
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
        public void DetFacturaBorrar(ref DetFactura ObjDetFactura, ref string Verificador)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand Cmd = null;
            try
            {
                String[] Parametros = { "P_ID_FACTURA_DETALLE"
                                      };
                object[] Valores = { ObjDetFactura.IdDetFact};
                String[] ParametrosOut = { "p_Bandera" };

                Cmd = CDDatos.GenerarOracleCommand("DEL_FACTURA_DETALLE", ref Verificador, Parametros, Valores, ParametrosOut);

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
        public void DetFacturaEliminar(int IdFact, ref string Verificador)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand Cmd = null;
            try
            {
                String[] Parametros = { "P_ID_FACTURA"
                                      };
                object[] Valores = { IdFact };
                String[] ParametrosOut = { "p_Bandera" };

                Cmd = CDDatos.GenerarOracleCommand("DEL_DETALLE", ref Verificador, Parametros, Valores, ParametrosOut);

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
