﻿using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data.OracleClient;
using System.Linq;
using System.Text;

namespace CapaDatos
{
    public class CD_Control_Cierre
    {
        public void Control_CierreConsultaGrid(ref Control_Cierre ObjControl_Cierre, string Buscar, ref List<Control_Cierre> List)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand cmm = null;
            try
            {
                OracleDataReader dr = null;

                string[] Parametros = { "p_ejercicio", "p_sistema", "p_Busca" };
                object[] Valores = { ObjControl_Cierre.Ejercicio, ObjControl_Cierre.sistema, Buscar};

                cmm = CDDatos.GenerarOracleCommandCursor("pkg_contabilidad.Obt_Grid_Control_Cierre", ref dr, Parametros, Valores);
                while (dr.Read())
                {
                    ObjControl_Cierre = new Control_Cierre();
                    ObjControl_Cierre.Id_Control_Cierre = Convert.ToInt32(dr.GetValue(0));
                    ObjControl_Cierre.Dependencia = Convert.ToString(dr.GetValue(1));
                    ObjControl_Cierre.Mes_anio = Convert.ToString(dr.GetValue(2));
                    ObjControl_Cierre.Cierre_Definitivo = Convert.ToString(dr.GetValue(8));
                    ObjControl_Cierre.DescDependencia = Convert.ToString(dr.GetValue(9));
                    List.Add(ObjControl_Cierre);
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
        public void Control_CierreEditar(ref Control_Cierre ObjControl_Cierre, ref string Verificador)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand cmm = null;
            try
            {
                string[] ParametrosIn = { "P_ID_CONTROL_CIERRE", "P_MES_ANIO", "P_CIERRE_DEFINITIVO" };
                object[] Valores = { ObjControl_Cierre.Id_Control_Cierre, ObjControl_Cierre.Mes_anio, ObjControl_Cierre.Cierre_Definitivo };
                string[] ParametrosOut ={
                                          "p_Bandera"
                };

                OracleCommand Cmd = CDDatos.GenerarOracleCommand("UPD_SAF_CONTROL_CIERRE", ref Verificador, ParametrosIn, Valores, ParametrosOut);

                CDDatos.LimpiarOracleCommand(ref Cmd);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Control_CierreGral(ref Control_Cierre ObjControl_Cierre, ref string Verificador)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand cmm = null;
            try
            {
                string[] ParametrosIn = { "P_MES_ANIO", "P_SISTEMA", "P_EJERCICIO" };
                object[] Valores = { ObjControl_Cierre.Mes_anio, "INGRESOS", ObjControl_Cierre.Ejercicio };
                string[] ParametrosOut ={
                                          "p_Bandera"
                };

                OracleCommand Cmd = CDDatos.GenerarOracleCommand("UPD_SAF_CONTROL_CIERRE_GRAL", ref Verificador, ParametrosIn, Valores, ParametrosOut);

                CDDatos.LimpiarOracleCommand(ref Cmd);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
