using System;
using System.Collections.Generic;
using System.Data.OracleClient;
using System.Linq;
using System.Text;
using CapaEntidad;

namespace CapaDatos
{
    public class CD_Retencion
    {
        public void ConsultarBeneficiarios(ref Retencion ObjRetenciones, ref List<Retencion> List, string Busqueda)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand cmm = null;
            try
            {

                OracleDataReader dr = null;
                String[] Parametros = { "p_dependencia", "p_anio", "p_mes", "p_busqueda" };
                Object[] Valores = { ObjRetenciones.Dependencia, ObjRetenciones.Anio, ObjRetenciones.Mes, Busqueda };
                cmm = CDDatos.GenerarOracleCommandCursor("PKG_RETENCIONES.Obt_Grid_Beneficiarios", ref dr, Parametros, Valores);

                while (dr.Read())
                {
                    ObjRetenciones = new Retencion();
                    ObjRetenciones.Dependencia = Convert.ToString(dr[0]);
                    ObjRetenciones.Tipo_Beneficiario = Convert.ToString(dr[1]);
                    ObjRetenciones.Beneficiario = Convert.ToString(dr[2]);
                    ObjRetenciones.Poliza = Convert.ToString(dr[3]);
                    ObjRetenciones.Cedula = Convert.ToString(dr[4]);
                    ObjRetenciones.Cargo = Convert.ToString(dr[6]);
                    ObjRetenciones.Abono = Convert.ToString(dr[7]);
                    ObjRetenciones.MesAnio = Convert.ToString(dr[5]);
                    List.Add(ObjRetenciones);
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
        public void ConsultarConceptos(ref Retencion ObjRetenciones, ref List<Retencion> List)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand cmm = null;
            try
            {

                OracleDataReader dr = null;
                String[] Parametros = { "p_dependencia", "p_poliza", "p_cedula", "p_mes_anio" };
                Object[] Valores = { ObjRetenciones.Dependencia, ObjRetenciones.Poliza, ObjRetenciones.Cedula, ObjRetenciones.MesAnio };
                cmm = CDDatos.GenerarOracleCommandCursor("PKG_RETENCIONES.Obt_Grid_Conceptos", ref dr, Parametros, Valores);

                while (dr.Read())
                {
                    ObjRetenciones = new Retencion();
                    ObjRetenciones.Cuenta = Convert.ToString(dr[0]);
                    ObjRetenciones.Concepto = Convert.ToString(dr[1]);
                    ObjRetenciones.Cargo = Convert.ToString(dr[2]);
                    ObjRetenciones.Abono = Convert.ToString(dr[3]);
                    List.Add(ObjRetenciones);
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
