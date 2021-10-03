using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CapaEntidad;
using System.Data.OracleClient;

namespace CapaDatos
{
    public class CD_Mensaje
    {
        public void ConsultarMensajes(Mensaje ObjMensaje, ref List<Mensaje> List)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand cmm = null;
            try
            {
                OracleDataReader dr = null;

                string[] Parametros = { "p_centro_contable", "p_buscar", "p_id_sistema"};
                object[] Valores = { ObjMensaje.Tipo_Usuario, "", 14 };
                cmm = CDDatos.GenerarOracleCommandCursor("PKG_CONTABILIDAD.Obt_Grid_Informativa", ref dr, Parametros, Valores);
                while (dr.Read())
                {
                    ObjMensaje = new Mensaje();
                    ObjMensaje.IdMensaje = Convert.ToInt32(dr.GetValue(0));
                    ObjMensaje.Tipo_Usuario = Convert.ToString(dr.GetValue(1));
                    ObjMensaje.TMensaje = Convert.ToString(dr.GetValue(2));
                    ObjMensaje.Status = Convert.ToString(dr.GetValue(5));
                    ObjMensaje.Fecha_inicial = Convert.ToString(dr.GetValue(3));
                    ObjMensaje.Fecha_inicial = Convert.ToString(dr.GetValue(4));
                    List.Add(ObjMensaje);
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
        public void ObtenerMensajes(ref Mensaje ObjMensaje, ref string Verificador)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand cmm = null;
            try
            {
                OracleDataReader dr = null;

                string[] Parametros = { "p_id" };
                object[] Valores = { ObjMensaje.IdMensaje };
                string[] ParametrosOut ={
                                          "p_centro_contable",
                                          "p_observaciones",                                          
                                          "p_fecha_inicial",
                                          "p_fecha_final",
                                          "p_status",
                                          "P_BANDERA"
                };
                cmm = CDDatos.GenerarOracleCommand("SEL_SAF_EDIT_informativa", ref Verificador, Parametros, Valores, ParametrosOut);
                if (Verificador == "0")
                {
                    ObjMensaje.Tipo_Usuario = (Convert.ToString(cmm.Parameters["p_centro_contable"].Value)== "99999") ? "1" : "3";
                    ObjMensaje.Dependencia = Convert.ToString(cmm.Parameters["p_centro_contable"].Value);
                    ObjMensaje.TMensaje = Convert.ToString(cmm.Parameters["p_observaciones"].Value);
                    ObjMensaje.Fecha_inicial = Convert.ToString(cmm.Parameters["p_fecha_inicial"].Value);
                    ObjMensaje.Fecha_final = Convert.ToString(cmm.Parameters["p_fecha_final"].Value);
                    ObjMensaje.Status = Convert.ToString(cmm.Parameters["p_status"].Value);
                }
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
        public void MensajeInsertar(Mensaje ObjMensaje, ref string Verificador)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand Cmd = null;
            try
            {
                String[] Parametros = { "P_DESCRIPCION", "P_CENTRO_CONTABLE", "P_FECHA_INICIAL", "P_FECHA_FINAL", "P_STATUS", "P_ID_SISTEMA" };
                object[] Valores = { ObjMensaje.TMensaje, ObjMensaje.Dependencia, ObjMensaje.Fecha_inicial, ObjMensaje.Fecha_final, ObjMensaje.Status, 14 };
                String[] ParametrosOut = { "p_Bandera" };
                Cmd = CDDatos.GenerarOracleCommand("INS_SAF_INFORMATIVA", ref Verificador, Parametros, Valores, ParametrosOut);
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
        public void MensajeEditar(Mensaje ObjMensaje, ref string Verificador)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand Cmd = null;
            try
            {
                String[] Parametros = { "P_ID", "P_DESCRIPCION", "P_CENTRO_CONTABLE", "P_FECHA_INICIAL", "P_FECHA_FINAL", "P_STATUS" };
                object[] Valores = {ObjMensaje.IdMensaje, ObjMensaje.TMensaje, ObjMensaje.Dependencia, ObjMensaje.Fecha_inicial, ObjMensaje.Fecha_final, ObjMensaje.Status };
                String[] ParametrosOut = { "p_Bandera" };
                Cmd = CDDatos.GenerarOracleCommand("UPD_SAF_INFORMATIVA", ref Verificador, Parametros, Valores, ParametrosOut);
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
        public void MensajeEliminar(Mensaje ObjMensaje, ref string Verificador)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand Cmd = null;
            try
            {
                String[] Parametros = { "P_ID" };
                object[] Valores = { ObjMensaje.IdMensaje };
                String[] ParametrosOut = { "p_Bandera" };
                Cmd = CDDatos.GenerarOracleCommand("DEL_SAF_INFORMATIVA", ref Verificador, Parametros, Valores, ParametrosOut);
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
