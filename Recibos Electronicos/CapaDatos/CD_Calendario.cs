using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data.OracleClient;
using System.Linq;
using System.Text;

namespace CapaDatos
{
    public class CD_Calendario
    {
        public void CalendarioConsultaGrid(Calendario ObjCalendario, ref List<Calendario> List)
        {
            CD_Datos CDDatos = new CD_Datos("INGRESOS");
            OracleCommand cmm = null;
            try
            {
                OracleDataReader dr = null;

                String[] Parametros = { "p_mes" };
                String[] Valores = { ObjCalendario.NumMes };

                cmm = CDDatos.GenerarOracleCommandCursor("PKG_PAGOS_2016.Obt_Grid_Cal_Pagos", ref dr, Parametros, Valores);
                while (dr.Read())
                {
                    ObjCalendario = new Calendario();
                    ObjCalendario.Mes = Convert.ToString(dr.GetValue(1));
                    ObjCalendario.Lun = Convert.ToString(dr.GetValue(4));
                    ObjCalendario.Mar = Convert.ToString(dr.GetValue(5));
                    ObjCalendario.Mie = Convert.ToString(dr.GetValue(6));
                    ObjCalendario.Jue = Convert.ToString(dr.GetValue(7));
                    ObjCalendario.Vie = Convert.ToString(dr.GetValue(8));
                    ObjCalendario.Sab = Convert.ToString(dr.GetValue(9));
                    ObjCalendario.Dom = Convert.ToString(dr.GetValue(3));
                    List.Add(ObjCalendario);
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
