using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CapaEntidad;
using System.Data.OracleClient;
using System.IO;

namespace CapaDatos
{
    public class CD_Banco
    {
        public void InsertarPagado(ref Banco banco, ref string salida)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand Cmd = null;
            try
            {
                String[] Parametros = { "p_banco", "p_dependencia", "p_importe", "p_referencia", "p_ficha", "p_folio", "p_sucursal", "p_cajero", "p_pago_fecha", "p_notas", "p_forma_pago" };
                object[] Valores = { banco.Nombre, banco.Dependencia, banco.Importe, banco.Referencia, banco.Ficha, banco.Folio, banco.Sucursal, banco.Cajero, banco.Fecha, banco.Notas, banco.Pago_Tipo };
                String[] ParametrosOut = { "p_Bandera" };

                Cmd = CDDatos.GenerarOracleCommand("ins_pagos_layout", ref salida, Parametros, Valores, ParametrosOut);
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
        public void InsertarPagadoCaja(ref Banco banco, ref string salida)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand Cmd = null;
            try
            {
                String[] Parametros = { "P_CUENTA", "P_FECHA", "P_HORA", "P_SUCURSALC", "P_DESCRIPCION", "P_SIGNO", "P_CARGO", "P_ABONO", "P_REFERENCIA", "P_SALDO", "P_CONCEPTO" };
                object[] Valores = { banco.Cuenta, banco.Fechac, banco.Hora, banco.Sucursalc, banco.Descripcion, banco.Signo, banco.Cargo, banco.Abono, banco.Referencia, banco.Saldo, banco.Concepto };
                String[] ParametrosOut = { "p_Bandera" };

                Cmd = CDDatos.GenerarOracleCommand("INS_PAGADAS_CAJA", ref salida, Parametros, Valores, ParametrosOut);
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
        public void EliminarPagadoCaja(ref string salida)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand Cmd = null;
            try
            {
                Cmd = CDDatos.GenerarOracleCommand("DEL_PAGADAS_CAJA", ref salida);
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

        public void InsertarBitacora(ref BancoBitacora bitacora, ref string salida)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand Cmd = null;
            try
            {
                String[] Parametros = { "p_fecha_pago", "p_nombre_archivo", "p_nombre_banco", "p_total", "p_archivo_c" };
                object[] Valores = { bitacora.Fecha_pago, bitacora.Archivo_nombre, bitacora.Banco_nombre, bitacora.Total_registros, bitacora.Archivo_contenido };
                String[] ParametrosOut = { "p_Bandera" };
                Cmd = CDDatos.GenerarOracleCommand("ins_bitacora_control", ref salida, Parametros, Valores, ParametrosOut, true);
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
        public void ObtenerBitacora( ref List<BancoBitacora> lbb, ref string fecha_i, ref string fecha_f, string Fecha_Pago )
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand cmm = null;
            try
            {
                OracleDataReader dr = null;

                String[] Parametros = { "p_fecha_i", "p_fecha_f", "p_fecha_pago" };
                String[] Valores = { fecha_i, fecha_f, Fecha_Pago };

                cmm = CDDatos.GenerarOracleCommandCursor("PKG_FELECTRONICA_2016.Obt_Grid_BitacoraControl", ref dr, Parametros, Valores);
                while (dr.Read())
                {
                    BancoBitacora bb = new BancoBitacora();

                    bb.Id = Convert.ToString(dr.GetValue(0));
                    bb.Banco_nombre = Convert.ToString(dr.GetValue(3));
                    bb.Archivo_nombre = Convert.ToString(dr.GetValue(2));
                    bb.Fecha_pago = Convert.ToString(dr.GetValue(1));
                    bb.Fecha_registro = Convert.ToString(dr.GetValue(5));
                    bb.Total_registros = Convert.ToUInt16(dr.GetValue(4));

                    lbb.Add(bb);

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
        public void ConsultarArchivo(ref BancoBitacora ObjBanco)
        {
            OracleDataReader dr = null;
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand cmm = null;

            try
            {
                string SP = "";
                string Ruta = "";
                string IdBanco;
                string[] Parametros = { "P_Id_Banco" };
                object[] Valores = { ObjBanco.Id };

                Ruta = AppDomain.CurrentDomain.BaseDirectory + "/ArchivosBanco/";
                IdBanco = ObjBanco.Archivo_nombre;
                SP = "pkg_felectronica_2016.Obt_Archivo_Banco";

                string[] files = System.IO.Directory.GetFiles(Ruta);
                foreach (string s in files)
                {
                    System.IO.File.Delete(s);
                }



                cmm = CDDatos.GenerarOracleCommandCursor(SP, ref dr, Parametros, Valores);
                while (dr.Read())
                {

                    ObjBanco = new BancoBitacora();
                    if (dr[2] != DBNull.Value)
                    {
                        ObjBanco.Archivo_contenido = (byte[])dr[2];
                        FileStream FS = new FileStream(Ruta + dr.GetValue(0) + dr.GetValue(1), FileMode.OpenOrCreate, FileAccess.ReadWrite);
                        FS.Write(ObjBanco.Archivo_contenido, 0, ObjBanco.Archivo_contenido.Length);
                        FS.Close();
                        FS = null;
                    }

                    ObjBanco.Archivo_nombre = "" + dr.GetValue(0) + dr.GetValue(1);
                    
                }
                dr.Close();

                //CDDatos.LimpiarOracleCommand(ref cmm);

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
