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
        public void ObtDetFactura(DetFactura objDetFactura, ref List<DetFactura> lstFactDet)
        {

            CD_Datos CDDatos = new CD_Datos();
            OracleCommand Cmd = null;

            try
            {
                OracleDataReader dr = null;


                string[] Parametros = { "p_id_factura" };
                object[] Valores = { objDetFactura.ID_FACT };
                Cmd = CDDatos.GenerarOracleCommandCursor("PKG_FELECTRONICA.Obt_Grid_Factura_Detalle", ref dr, Parametros, Valores);

                if (dr.HasRows)
                {

                    while (dr.Read())
                    {
                        objDetFactura = new DetFactura();
                        objDetFactura.IdDetFact = Convert.ToInt32(dr[0]);
                        objDetFactura.DescConcepto= Convert.ToString(dr[2]);
                        objDetFactura.ClaveConcepto = Convert.ToString(dr[1]);
                        objDetFactura.Importe = Convert.ToString(dr[4]);
                        objDetFactura.FACT_TOTAL = Convert.ToString(dr[5]);
                        //objDetFactura.Clave = Convert.ToString(dr["clave"].ToString());
                        //objDetFactura.Id_Padre = Convert.ToInt32(dr["id_padre"].ToString());

                        //objMenu.Usuario = Usuario;
                        //objMenu.Grupo = Grupo;
                        lstFactDet.Add(objDetFactura);
                        //LlenarTree(ref Arbolito, objMenu, ref List);

                    }
                    dr.Close();
                }
                dr.Close();
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
