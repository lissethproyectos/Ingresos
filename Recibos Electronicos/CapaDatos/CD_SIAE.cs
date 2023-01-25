using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CapaDatos;
using CapaEntidad;
using System.Data.OracleClient;

namespace CapaDatos
{
    public class CD_SIAE
    {
        public void ConsultaGridInscripciones(Factura ObjFactura, ref List<Factura> List)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand cmm = null;
            try
            {
                OracleDataReader dr = null;

                String[] Parametros = { "P_Ciclo_Escolar", "p_referencia" };
                String[] Valores = { ObjFactura.CICLO_ESCOLAR.ToString(), ObjFactura.FACT_REFERENCIA };

                cmm = CDDatos.GenerarOracleCommandCursor("PKG_FELECTRONICA_2016.Obt_Grid_Ref_Inscripcion", ref dr, Parametros, Valores);
                while (dr.Read())
                {
                    ObjFactura = new Factura();
                    ObjFactura.ID_FACT = Convert.ToString(dr.GetValue(0));
                    ObjFactura.FACT_DEPENDENCIA = Convert.ToString(dr.GetValue(1));
                    ObjFactura.FACT_MATRICULA = Convert.ToString(dr.GetValue(2));
                    ObjFactura.FACT_NOMBRE = Convert.ToString(dr.GetValue(3));
                    ObjFactura.FACT_REFERENCIA = Convert.ToString(dr.GetValue(4));
                    ObjFactura.FACT_TOTAL = Convert.ToString(dr.GetValue(5));
                    ObjFactura.FACT_FECHA_FACTURA = Convert.ToString(dr.GetValue(6));
                    ObjFactura.FACT_RECEPTOR_STATUS = "../Imagenes/" + Convert.ToString(dr.GetValue(8)) + ".PNG";
                    ObjFactura.FACT_STATUS_NOTAS= Convert.ToString(dr.GetValue(9));
                    ObjFactura.CICLO_ESCOLAR = Convert.ToString(dr.GetValue(7));
                    List.Add(ObjFactura);

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
        public void ConsultaGridRefSIAE(Factura ObjFactura, ref List<Factura> List)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand cmm = null;
            try
            {
                OracleDataReader dr = null;

                String[] Parametros = { "P_Nivel", "P_Ciclo_Escolar", "P_Escuela", "p_referencia" };
                String[] Valores = { ObjFactura.FACT_NIVEL, ObjFactura.CICLO_ESCOLAR.ToString(), ObjFactura.FACT_DEPENDENCIA, ObjFactura.FACT_REFERENCIA };

                cmm = CDDatos.GenerarOracleCommandCursor("PKG_FELECTRONICA_2016.Obt_Grid_Ref_SIAE", ref dr, Parametros, Valores);
                while (dr.Read())
                {
                    ObjFactura = new Factura();
                    ObjFactura.ID_FACT = Convert.ToString(dr.GetValue(0));
                    ObjFactura.FACT_DEPENDENCIA = Convert.ToString(dr.GetValue(1));
                    ObjFactura.FACT_MATRICULA = Convert.ToString(dr.GetValue(2));
                    ObjFactura.FACT_NOMBRE = Convert.ToString(dr.GetValue(3));
                    ObjFactura.FACT_REFERENCIA = Convert.ToString(dr.GetValue(4));
                    ObjFactura.FACT_TOTAL = Convert.ToString(dr.GetValue(5));
                    ObjFactura.FACT_FECHA_FACTURA = Convert.ToString(dr.GetValue(6));
                    ObjFactura.FACT_RECEPTOR_STATUS = "../Imagenes/" + Convert.ToString(dr.GetValue(8)) + ".PNG";
                    ObjFactura.FACT_STATUS_NOTAS = Convert.ToString(dr.GetValue(9));
                    ObjFactura.CICLO_ESCOLAR = Convert.ToString(dr.GetValue(7));
                    ObjFactura.FACT_TIPO_SERVICIO = Convert.ToString(dr.GetValue(9));
                    ObjFactura.FACT_STATUS = Convert.ToString(dr.GetValue(10));
                    ObjFactura.FACT_TIPO = Convert.ToString(dr.GetValue(11));
                    int id = Convert.ToInt32(dr.GetValue(13));
                    ObjFactura.VISIBLE1 = Convert.ToInt32(dr.GetValue(13)) == 0 ? true : false;
                    ObjFactura.VISIBLE2 = Convert.ToInt32(dr.GetValue(13)) == 0 ? false : true;
                    ObjFactura.ID_FICHA_BANCARIA = Convert.ToInt32(dr.GetValue(12));
                    ObjFactura.ID_FACT_EFEC = Convert.ToString(dr.GetValue(0));
                    ObjFactura.ID_RECIBO = Convert.ToInt32(dr.GetValue(13));
                    List.Add(ObjFactura);

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
        public void ConsultaGridRefSysweb(Factura ObjFactura,  string FechaIni, string FechFin, string TipoBusqueda,  ref List<Factura> List)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand cmm = null;
            try
            {
                OracleDataReader dr = null;

                String[] Parametros = { "P_Nivel", "P_Fecha_Inicial", "P_Fecha_Final", "P_Escuela", "p_referencia", "p_tipo_busqueda" };
                String[] Valores = { ObjFactura.FACT_NIVEL, FechaIni, FechFin, ObjFactura.FACT_DEPENDENCIA, ObjFactura.FACT_REFERENCIA, TipoBusqueda };

                cmm = CDDatos.GenerarOracleCommandCursor("PKG_FELECTRONICA_2016.Obt_Grid_Ref_SysWeb", ref dr, Parametros, Valores);
                while (dr.Read())
                {
                    ObjFactura = new Factura();
                    ObjFactura.ID_FACT = Convert.ToString(dr.GetValue(0));
                    ObjFactura.FACT_DEPENDENCIA = Convert.ToString(dr.GetValue(1));
                    ObjFactura.FACT_MATRICULA = Convert.ToString(dr.GetValue(2));
                    ObjFactura.FACT_NOMBRE = Convert.ToString(dr.GetValue(3));
                    ObjFactura.FACT_REFERENCIA = Convert.ToString(dr.GetValue(4));
                    ObjFactura.FACT_TOTAL = Convert.ToString(dr.GetValue(5));
                    ObjFactura.FACT_FECHA_FACTURA = Convert.ToString(dr.GetValue(6));
                    ObjFactura.FACT_RECEPTOR_STATUS = "../Imagenes/" + Convert.ToString(dr.GetValue(8)) + ".PNG";
                    ObjFactura.FACT_STATUS_NOTAS = Convert.ToString(dr.GetValue(9));
                    ObjFactura.CICLO_ESCOLAR = Convert.ToString(dr.GetValue(7));
                    ObjFactura.FACT_TIPO_SERVICIO = Convert.ToString(dr.GetValue(9));
                    ObjFactura.FACT_STATUS = Convert.ToString(dr.GetValue(10));
                    ObjFactura.FACT_TIPO = Convert.ToString(dr.GetValue(11));
                    ObjFactura.VISIBLE1 = Convert.ToInt32(dr.GetValue(0)) == 0 ? true : false;
                    ObjFactura.VISIBLE2 = Convert.ToInt32(dr.GetValue(0)) == 0 ? false : true ;
                    ObjFactura.ID_FICHA_BANCARIA = Convert.ToInt32(dr.GetValue(12));
                    ObjFactura.ID_RECIBO = Convert.ToInt32(dr.GetValue(13));
                    List.Add(ObjFactura);

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

        public void ActualizarStatusSIAE(Factura ObjFactura, string Usuario, ref string Verificador)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand Cmd = null;
            try
            {
                String[] Parametros = { "P_ID", "P_MOVIMIENTO", "P_USUARIO" };
                object[] Valores = { ObjFactura.ID_FACT, ObjFactura.FACT_STATUS, Usuario };
                String[] ParametrosOut = { "p_Bandera" };
                Cmd = CDDatos.GenerarOracleCommand("UPD_SCE_INSCRIPCIONES", ref Verificador, Parametros, Valores, ParametrosOut);
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

        public void ConfirmarPagoSIAE(Factura ObjFactura, string Usuario, ref string Verificador)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand Cmd = null;
            try
            {
                String[] Parametros = { "P_ID", "P_STATUS_PAGO", "P_USUARIO" };
                object[] Valores = { ObjFactura.ID_FACT, ObjFactura.FACT_STATUS, Usuario };
                String[] ParametrosOut = { "p_Bandera" };
                Cmd = CDDatos.GenerarOracleCommand("UPD_PAGO_CONFIRMADO_SIAE", ref Verificador, Parametros, Valores, ParametrosOut);
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

        public void ActualizarDatosSIAE(Factura ObjFactura, string ReferenciaPagada, string Usuario, ref string Verificador)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand Cmd = null;
            try
            {
                String[] Parametros = { "P_ID", "P_FOLIO", "P_FECHA_PAGO", "P_BANCO", "P_REFERENCIA_PAGADA", "P_PAGO_CONFIRMADO", "P_CICLO", "P_USUARIO", "P_ESCUELA", "P_CARRERA", "P_SEMESTRE", "P_MATRICULA" };
                object[] Valores = { ObjFactura.ID_FACT, ObjFactura.FACT_FOLIOBANCARIO, ObjFactura.FACT_FECHA_FACTURA, ObjFactura.FACT_BANCO, ReferenciaPagada, ObjFactura.FACT_CONFIRMADO, ObjFactura.CICLO_ESCOLAR, Usuario, ObjFactura.FACT_DEPENDENCIA, ObjFactura.FACT_CARRERA, ObjFactura.FACT_SEMESTRE, ObjFactura.FACT_MATRICULA };
                String[] ParametrosOut = { "p_Bandera" };
                Cmd = CDDatos.GenerarOracleCommand("UPD_DATOS_PAGO_SIAE", ref Verificador, Parametros, Valores, ParametrosOut);
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


        public void SIAEConsultaDatosPago(ref Factura ObjFactura, ref string Verificador)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand Cmd = null;
            try
            {
                String[] Parametros = { "P_ID" };
                object[] Valores = { ObjFactura.ID_FACT };
                String[] ParametrosOut = { "P_FOLIO", "P_FECHA_PAGO", "P_BANCO", "P_REFERENCIA_PAGADA", "P_PAGO_CONFIRMADO", "P_CICLO", "P_ESCUELA", "P_CARRERA", "P_SEMESTRE", "P_MATRICULA", "P_BANDERA" };
                Cmd = CDDatos.GenerarOracleCommand("OBT_DATOS_PAGO_SIAE", ref Verificador, Parametros, Valores, ParametrosOut);
                if (Verificador == "0")
                {
                    ObjFactura = new Factura();
                    ObjFactura.FACT_FOLIOBANCARIO = Convert.ToString(Cmd.Parameters["P_FOLIO"].Value);
                    ObjFactura.FACT_FECHA_FACTURA = Convert.ToString(Cmd.Parameters["P_FECHA_PAGO"].Value);
                    ObjFactura.FACT_BANCO = Convert.ToString(Cmd.Parameters["P_BANCO"].Value);
                    //ObjFactura.FACT_REFERENCIA = Convert.ToString(Cmd.Parameters["P_REFERENCIA"].Value);
                    ObjFactura.FACT_CONFIRMADO = Convert.ToString(Cmd.Parameters["P_PAGO_CONFIRMADO"].Value);
                    ObjFactura.CICLO_ESCOLAR = Convert.ToString(Cmd.Parameters["P_CICLO"].Value);
                    ObjFactura.FACT_DEPENDENCIA = Convert.ToString(Cmd.Parameters["P_ESCUELA"].Value);
                    ObjFactura.FACT_CARRERA = Convert.ToString(Cmd.Parameters["P_CARRERA"].Value);
                    ObjFactura.FACT_SEMESTRE = Convert.ToString(Cmd.Parameters["P_SEMESTRE"].Value);
                    ObjFactura.FACT_MATRICULA = Convert.ToString(Cmd.Parameters["P_MATRICULA"].Value);
                    ObjFactura.FACT_REFERENCIA_PAGADA = Convert.ToString(Cmd.Parameters["P_REFERENCIA_PAGADA"].Value);
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
        public void SysWebConsultaDatosPago(ref Factura ObjFactura, ref string Verificador)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand Cmd = null;
            try
            {
                String[] Parametros = { "P_ID" };
                object[] Valores = { ObjFactura.ID_FACT };
                String[] ParametrosOut = { "P_FOLIO", "P_FECHA_PAGO", "P_BANCO", "P_REFERENCIA", "P_PAGO_CONFIRMADO", "P_CICLO", "P_ESCUELA", "P_CARRERA", "P_SEMESTRE", "P_MATRICULA", "P_EVENTO", "P_NOMBRE", "P_BANDERA" };
                Cmd = CDDatos.GenerarOracleCommand("OBT_DATOS_PAGO_SYSWEB", ref Verificador, Parametros, Valores, ParametrosOut);
                if (Verificador == "0")
                {
                    ObjFactura = new Factura();
                    ObjFactura.FACT_FOLIOBANCARIO = Convert.ToString(Cmd.Parameters["P_FOLIO"].Value);
                    ObjFactura.FACT_FECHA_FACTURA = Convert.ToString(Cmd.Parameters["P_FECHA_PAGO"].Value);
                    ObjFactura.FACT_BANCO = Convert.ToString(Cmd.Parameters["P_BANCO"].Value);
                    ObjFactura.FACT_REFERENCIA = Convert.ToString(Cmd.Parameters["P_REFERENCIA"].Value);
                    ObjFactura.FACT_CONFIRMADO = Convert.ToString(Cmd.Parameters["P_PAGO_CONFIRMADO"].Value);
                    ObjFactura.CICLO_ESCOLAR = Convert.ToString(Cmd.Parameters["P_CICLO"].Value);
                    ObjFactura.FACT_DEPENDENCIA = Convert.ToString(Cmd.Parameters["P_ESCUELA"].Value);
                    ObjFactura.FACT_CARRERA = Convert.ToString(Cmd.Parameters["P_CARRERA"].Value);
                    ObjFactura.FACT_SEMESTRE = Convert.ToString(Cmd.Parameters["P_SEMESTRE"].Value);
                    ObjFactura.FACT_MATRICULA = Convert.ToString(Cmd.Parameters["P_MATRICULA"].Value);
                    ObjFactura.FACT_EVENTO = Convert.ToString(Cmd.Parameters["P_EVENTO"].Value);
                    ObjFactura.FACT_NOMBRE = Convert.ToString(Cmd.Parameters["P_NOMBRE"].Value);
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


    }
}
