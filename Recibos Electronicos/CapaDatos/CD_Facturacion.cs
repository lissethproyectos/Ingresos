using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data.OracleClient;
using System.Linq;
using System.Text;

namespace CapaDatos
{
    public class CD_Facturacion
    {
        public void FacturaConsultaDatosFiscales(ref Facturacion ObjFactura, ref string Verificador)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand Cmd = null;
            try
            {

                String[] Parametros = { "p_id_factura" };
                Object[] Valores = { Convert.ToInt32(ObjFactura.ID_FACT) };
                String[] ParametrosOut = { "p_dependencia","p_receptor_nombre", "p_receptor_rfc", "p_receptor_domicilio", "p_receptor_colonia", "p_receptor_estado",
                                           "p_receptor_municipio","p_receptor_tipo_persona","p_receptor_telefono","p_receptor_correo",
                                           "p_receptor_metodo_pago","p_receptor_cp","p_receptor_status","p_receptor_status_notas","P_CFDI","P_RECEPTOR_TIPO_SERVICIO","P_RECEPTOR_OBSERVACIONES","P_CONFIRMADO","P_RECEPTOR_FORMA_PAGO","P_CONCEPTOS", "P_TOTAL", "p_Bandera" };
                Cmd = CDDatos.GenerarOracleCommand("SEL_INF_FACTURA_CAJA", ref Verificador, Parametros, Valores, ParametrosOut);
                if (Verificador == "0")
                {
                    ObjFactura.DEPENDENCIA = Convert.ToString(Cmd.Parameters["p_dependencia"].Value);
                    ObjFactura.RECEPTOR_NOMBRE = Convert.ToString(Cmd.Parameters["p_receptor_nombre"].Value);
                    ObjFactura.RECEPTOR_TIPO_PERS = Convert.ToString(Cmd.Parameters["p_receptor_tipo_persona"].Value);
                    ObjFactura.RECEPTOR_RFC = Convert.ToString(Cmd.Parameters["p_receptor_rfc"].Value);
                    ObjFactura.RECEPTOR_DOMICILIO = Convert.ToString(Cmd.Parameters["p_receptor_domicilio"].Value);
                    ObjFactura.RECEPTOR_COLONIA = Convert.ToString(Cmd.Parameters["p_receptor_colonia"].Value);
                    ObjFactura.RECEPTOR_ESTADO = Convert.ToString(Cmd.Parameters["p_receptor_estado"].Value);
                    ObjFactura.RECEPTOR_MUNICIPIO = Convert.ToString(Cmd.Parameters["p_receptor_municipio"].Value);
                    ObjFactura.RECEPTOR_TELEFONO = Convert.ToString(Cmd.Parameters["p_receptor_telefono"].Value);
                    ObjFactura.RECEPTOR_CORREO = Convert.ToString(Cmd.Parameters["p_receptor_correo"].Value);
                    ObjFactura.RECEPTOR_METODO_PAGO = Convert.ToString(Cmd.Parameters["p_receptor_metodo_pago"].Value);
                    ObjFactura.RECEPTOR_CP = Convert.ToString(Cmd.Parameters["p_receptor_cp"].Value);
                    ObjFactura.RECEPTOR_STATUS = Convert.ToString(Cmd.Parameters["p_receptor_status"].Value);
                    ObjFactura.RECEPTOR_STATUS_NOTAS = Convert.ToString(Cmd.Parameters["p_receptor_status_notas"].Value);
                    ObjFactura.CFDI = Convert.ToString(Cmd.Parameters["P_CFDI"].Value);
                    ObjFactura.TIPO_SERVICIO = Convert.ToString(Cmd.Parameters["P_RECEPTOR_TIPO_SERVICIO"].Value);
                    ObjFactura.OBSERVACIONES = Convert.ToString(Cmd.Parameters["P_RECEPTOR_OBSERVACIONES"].Value);
                    ObjFactura.CONFIRMADO = Convert.ToString(Cmd.Parameters["P_CONFIRMADO"].Value);
                    ObjFactura.RECEPTOR_FORMA_PAGO = Convert.ToString(Cmd.Parameters["P_RECEPTOR_FORMA_PAGO"].Value);
                    ObjFactura.CONCEPTOS = Convert.ToString(Cmd.Parameters["P_CONCEPTOS"].Value);
                    //ObjFactura.TOTAL_PAGO = Convert.ToString(Cmd.Parameters["P_TOTAL"].Value);
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
        public void FacturaEfectConsultaDatosFiscales(ref Facturacion ObjFactura, ref string Verificador)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand Cmd = null;
            try
            {

                String[] Parametros = { "P_ID" };
                Object[] Valores = { Convert.ToInt32(ObjFactura.ID_FACT) };
                String[] ParametrosOut = { "P_DEPENDENCIA", "P_RECEPTOR_RFC", "P_RECEPTOR_TIPO_PERSONA", "P_RECEPTOR_NOMBRE", "P_RECEPTOR_DOMICILIO", "P_RECEPTOR_COLONIA",
                    "P_RECEPTOR_NUMERO_EXTERIOR", "P_RECEPTOR_NUMERO_INTERIOR", "P_RECEPTOR_ESTADO", "P_RECEPTOR_MUNICIPIO", "P_RECEPTOR_CP", "P_RECEPTOR_METODO_PAGO",
                    "P_FORMA_PAGO", "P_CFDI", "P_RECEPTOR_TELEFONO", "P_RECEPTOR_CORREO", "P_RECEPTOR_OBSERVACIONES", "P_CONFIRMADO", "P_FOLIO_PAGO",
                    "P_FECHA_PAGO", "P_IMPORTE_PAGO", "P_IVA_PAGO", "P_TOTAL_PAGO", "P_NUMERO_OFICIO",
                    "P_FECHA_OFICIO", "P_IMPORTE_CONVENIO", "P_IVA_CONVENIO", "P_TOTAL_CONVENIO", "P_NOTAS_CONVENIO", "P_RECEPTOR_STATUS",
                    "P_RECEPTOR_STATUS_NOTAS", "P_TIPO", "P_RUTA_ARCHIVO_CONVENIO", "P_RUTA_ARCHIVO_OFICIO", "P_RUTA_ADJUNTO_VOUCHER",
                    "P_RECEPTOR_METODO_PAGO_FA", "P_RECEPTOR_CODIGO", "P_RUTA_CONSTANCIA", "p_Bandera" };
                Cmd = CDDatos.GenerarOracleCommand("SEL_FACTURA_SOLICITUD", ref Verificador, Parametros, Valores, ParametrosOut);
                if (Verificador == "0")
                {
                    ObjFactura.TIPO = Convert.ToString(Cmd.Parameters["p_tipo"].Value);
                    ObjFactura.DEPENDENCIA = Convert.ToString(Cmd.Parameters["p_dependencia"].Value);
                    ObjFactura.RECEPTOR_RFC = Convert.ToString(Cmd.Parameters["p_receptor_rfc"].Value);
                    ObjFactura.RECEPTOR_TIPO_PERS = Convert.ToString(Cmd.Parameters["p_receptor_tipo_persona"].Value);
                    ObjFactura.RECEPTOR_NOMBRE = Convert.ToString(Cmd.Parameters["p_receptor_nombre"].Value);
                    ObjFactura.RECEPTOR_DOMICILIO = Convert.ToString(Cmd.Parameters["p_receptor_domicilio"].Value);
                    ObjFactura.RECEPTOR_COLONIA = Convert.ToString(Cmd.Parameters["p_receptor_colonia"].Value);
                    ObjFactura.NUMERO_EXTERIOR = Convert.ToString(Cmd.Parameters["P_RECEPTOR_NUMERO_EXTERIOR"].Value);
                    ObjFactura.NUMERO_INTERIOR = Convert.ToString(Cmd.Parameters["P_RECEPTOR_NUMERO_INTERIOR"].Value);
                    ObjFactura.RECEPTOR_ESTADO = Convert.ToString(Cmd.Parameters["p_receptor_estado"].Value);
                    ObjFactura.RECEPTOR_MUNICIPIO = Convert.ToString(Cmd.Parameters["p_receptor_municipio"].Value);
                    ObjFactura.RECEPTOR_CP = Convert.ToString(Cmd.Parameters["p_receptor_cp"].Value);
                    ObjFactura.RECEPTOR_METODO_PAGO = Convert.ToString(Cmd.Parameters["P_RECEPTOR_METODO_PAGO"].Value);
                    ObjFactura.RECEPTOR_METODO_PAGO_FA = Convert.ToString(Cmd.Parameters["P_RECEPTOR_METODO_PAGO_FA"].Value);
                    ObjFactura.RECEPTOR_FORMA_PAGO = Convert.ToString(Cmd.Parameters["P_FORMA_PAGO"].Value);
                    ObjFactura.CFDI = Convert.ToString(Cmd.Parameters["P_CFDI"].Value);
                    ObjFactura.RECEPTOR_TELEFONO = Convert.ToString(Cmd.Parameters["p_receptor_telefono"].Value);
                    ObjFactura.RECEPTOR_CORREO = Convert.ToString(Cmd.Parameters["p_receptor_correo"].Value);
                    ObjFactura.OBSERVACIONES = Convert.ToString(Cmd.Parameters["P_RECEPTOR_OBSERVACIONES"].Value);
                    ObjFactura.CONFIRMADO = Convert.ToString(Cmd.Parameters["P_CONFIRMADO"].Value);
                    ObjFactura.FOLIO_PAGO = Convert.ToString(Cmd.Parameters["P_FOLIO_PAGO"].Value);
                    ObjFactura.FECHA_PAGO = Convert.ToString(Cmd.Parameters["P_FECHA_PAGO"].Value);
                    ObjFactura.IMPORTE_PAGO = Convert.ToDouble(Cmd.Parameters["P_IMPORTE_PAGO"].Value);
                    ObjFactura.IVA_PAGO = Convert.ToDouble(Cmd.Parameters["P_IVA_PAGO"].Value);
                    ObjFactura.TOTAL_PAGO = Convert.ToDouble(Cmd.Parameters["P_TOTAL_PAGO"].Value);
                    ObjFactura.NUM_OFICIO = Convert.ToString(Cmd.Parameters["P_NUMERO_OFICIO"].Value);
                    ObjFactura.FECHA_OFICIO = Convert.ToString(Cmd.Parameters["P_FECHA_OFICIO"].Value);
                    ObjFactura.IMPORTE_CONVENIO = Convert.ToDouble(Cmd.Parameters["P_IMPORTE_CONVENIO"].Value);
                    ObjFactura.IVA_CONVENIO = Convert.ToDouble(Cmd.Parameters["P_IVA_CONVENIO"].Value);
                    ObjFactura.TOTAL_CONVENIO = Convert.ToDouble(Cmd.Parameters["P_TOTAL_CONVENIO"].Value);
                    ObjFactura.OBSERVACIONES_CONVENIO = Convert.ToString(Cmd.Parameters["P_NOTAS_CONVENIO"].Value);
                    ObjFactura.RECEPTOR_CODIGO = Convert.ToString(Cmd.Parameters["P_RECEPTOR_CODIGO"].Value);
                    ObjFactura.RUTA_ADJUNTO_CONSTANCIA = Convert.ToString(Cmd.Parameters["P_RUTA_CONSTANCIA"].Value);


                    ObjFactura.RECEPTOR_STATUS_NOTAS = Convert.ToString(Cmd.Parameters["p_receptor_status_notas"].Value);
                    //Datos del Voucher
                    ObjFactura.FOLIO_PAGO = Convert.ToString(Cmd.Parameters["P_FOLIO_PAGO"].Value);
                    ObjFactura.FECHA_PAGO = Convert.ToString(Cmd.Parameters["P_FECHA_PAGO"].Value);
                    ObjFactura.IMPORTE_PAGO = Convert.ToDouble(Cmd.Parameters["P_IMPORTE_PAGO"].Value);
                    ObjFactura.IVA_PAGO = Convert.ToDouble(Cmd.Parameters["P_IVA_PAGO"].Value);
                    ObjFactura.TOTAL_PAGO = Convert.ToDouble(Cmd.Parameters["P_TOTAL_PAGO"].Value);

                    //Datos del Oficio
                    ObjFactura.NUM_OFICIO = Convert.ToString(Cmd.Parameters["P_NUMERO_OFICIO"].Value);
                    ObjFactura.FECHA_OFICIO = Convert.ToString(Cmd.Parameters["P_FECHA_OFICIO"].Value);

                    //Importe/Convenio
                    ObjFactura.IMPORTE_CONVENIO = Convert.ToDouble(Cmd.Parameters["P_IMPORTE_CONVENIO"].Value);
                    ObjFactura.IVA_CONVENIO = Convert.ToDouble(Cmd.Parameters["P_IVA_CONVENIO"].Value);
                    ObjFactura.TOTAL_CONVENIO = Convert.ToDouble(Cmd.Parameters["P_TOTAL_CONVENIO"].Value);
                    ObjFactura.OBSERVACIONES_CONVENIO = Convert.ToString(Cmd.Parameters["P_NOTAS_CONVENIO"].Value);


                    ObjFactura.RUTA_ADJUNTO = Convert.ToString(Cmd.Parameters["P_RUTA_ADJUNTO_VOUCHER"].Value);
                    ObjFactura.RUTA_ADJUNTO_OFICIO = Convert.ToString(Cmd.Parameters["P_RUTA_ARCHIVO_OFICIO"].Value);
                    ObjFactura.RUTA_ADJUNTO_CONVENIO = Convert.ToString(Cmd.Parameters["P_RUTA_ARCHIVO_CONVENIO"].Value);

                    ObjFactura.OBSERVACIONES = Convert.ToString(Cmd.Parameters["P_RECEPTOR_OBSERVACIONES"].Value);
                    ObjFactura.CONFIRMADO = Convert.ToString(Cmd.Parameters["P_CONFIRMADO"].Value);

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
        public void FacturaActDatosCaja(Facturacion ObjFactura, string UsuarioNombre, ref string Verificador)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand cmm = null;
            try
            {



                String[] Parametros = { "P_ID_FACTURA", "P_RECEPTOR_RFC", "P_RECEPTOR_NOMBRE", "P_RECEPTOR_DOMICILIO", "P_RECEPTOR_COLONIA",
                                        "P_RECEPTOR_CP", "P_RECEPTOR_ESTADO", "P_RECEPTOR_MUNICIPIO", "P_RECEPTOR_METODO_PAGO", "P_RECEPTOR_TELEFONO",
                                        "P_RECEPTOR_CORREO", "P_RECEPTOR_TIPO_PERS", "P_RECEPTOR_STATUS", "P_RECEPTOR_STATUS_NOTAS", "P_CONFIRMADO",
                                        "p_usuario", "P_CFDI", "P_RECEPTOR_TIPO_SERVICIO", "P_RECEPTOR_OBSERVACIONES", "P_RECEPTOR_FORMA_PAGO"
                };
                Object[] Valores = {ObjFactura.ID_FACT, ObjFactura.RECEPTOR_RFC, ObjFactura.RECEPTOR_NOMBRE, ObjFactura.RECEPTOR_DOMICILIO,
                                    ObjFactura.RECEPTOR_COLONIA, ObjFactura.RECEPTOR_CP, ObjFactura.RECEPTOR_ESTADO, ObjFactura.RECEPTOR_MUNICIPIO,
                                    ObjFactura.RECEPTOR_METODO_PAGO, ObjFactura.RECEPTOR_TELEFONO, ObjFactura.RECEPTOR_CORREO, ObjFactura.RECEPTOR_TIPO_PERS,
                                    ObjFactura.RECEPTOR_STATUS, ObjFactura.RECEPTOR_STATUS_NOTAS, ObjFactura.CONFIRMADO, UsuarioNombre, ObjFactura.CFDI, ObjFactura.TIPO_SERVICIO, ObjFactura.OBSERVACIONES,
                                    ObjFactura.RECEPTOR_FORMA_PAGO
                };
                String[] ParametrosOut = { "p_bandera" };
                cmm = CDDatos.GenerarOracleCommand("ACT_FACTURA_CAJA", ref Verificador, Parametros, Valores, ParametrosOut);
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
        public void FacturaEditarDatosEfect2(Facturacion ObjFactura, string UsuarioNombre, ref string Verificador)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand cmm = null;
            try
            {



                String[] Parametros = {
                    "P_ID_FACT_EFECT", "P_RECEPTOR_RFC", "P_RECEPTOR_TIPO_PERS", "P_RECEPTOR_NOMBRE","P_RECEPTOR_DOMICILIO",
                    "P_RECEPTOR_COLONIA", "P_RECEPTOR_NUMERO_EXTERIOR", "P_RECEPTOR_NUMERO_INTERIOR", "P_RECEPTOR_ESTADO", "P_RECEPTOR_MUNICIPIO",
                    "P_RECEPTOR_CP","P_RECEPTOR_METODO_PAGO", "P_FORMA_PAGO", "P_CFDI", "P_RECEPTOR_TELEFONO", "P_RECEPTOR_CORREO", "P_RECEPTOR_OBSERVACIONES",
                    "P_CONFIRMADO", "P_FOLIO_PAGO", "P_FECHA_PAGO", "P_IMPORTE_PAGO", "P_IVA_PAGO", "P_TOTAL_PAGO", "P_NUMERO_OFICIO", "P_FECHA_OFICIO",
                    "P_IMPORTE_CONVENIO","P_IVA_CONVENIO","P_TOTAL_CONVENIO","P_NOTAS_CONVENIO",
                    "P_FECHA_REP","P_FOLIO_REP",
                    "P_RECEPTOR_STATUS","P_RECEPTOR_STATUS_NOTAS","P_TIPO",
                    "P_RUTA_ARCHIVO_CONVENIO","P_RUTA_ARCHIVO_OFICIO","P_RUTA_ADJUNTO_VOUCHER","P_RUTA_ADJUNTO_REP","P_USUARIO",
                    "P_RECEPTOR_METODO_PAGO_FA", "P_FOLIO_PAGADO",
                    "P_RECEPTOR_CODIGO", "P_RUTA_CONSTANCIA"
                };
                Object[] Valores = {ObjFactura.ID_FACT, ObjFactura.RECEPTOR_RFC, ObjFactura.RECEPTOR_TIPO_PERS, ObjFactura.RECEPTOR_NOMBRE, ObjFactura.RECEPTOR_DOMICILIO,
                    ObjFactura.RECEPTOR_COLONIA, ObjFactura.NUMERO_EXTERIOR, ObjFactura.NUMERO_INTERIOR,ObjFactura.RECEPTOR_ESTADO, ObjFactura.RECEPTOR_MUNICIPIO,
                    ObjFactura.RECEPTOR_CP, ObjFactura.RECEPTOR_METODO_PAGO, ObjFactura.RECEPTOR_FORMA_PAGO, ObjFactura.CFDI, ObjFactura.RECEPTOR_TELEFONO,
                    ObjFactura.RECEPTOR_CORREO, ObjFactura.OBSERVACIONES, ObjFactura.CONFIRMADO, ObjFactura.FOLIO_PAGO, ObjFactura.FECHA_PAGO, ObjFactura.IMPORTE_PAGO,
                    ObjFactura.IVA_PAGO, ObjFactura.TOTAL_PAGO, ObjFactura.NUM_OFICIO, ObjFactura.FECHA_OFICIO, ObjFactura.IMPORTE_CONVENIO,                    
                    ObjFactura.IVA_CONVENIO, ObjFactura.TOTAL_CONVENIO, ObjFactura.OBSERVACIONES_CONVENIO,
                    ObjFactura.FECHA_REP, ObjFactura.FOLIO_REP,
                    ObjFactura.RECEPTOR_STATUS, ObjFactura.RECEPTOR_STATUS_NOTAS, ObjFactura.TIPO, 
                    ObjFactura.RUTA_ADJUNTO_CONVENIO, ObjFactura.RUTA_ADJUNTO_OFICIO, ObjFactura.RUTA_ADJUNTO, ObjFactura.RUTA_ADJUNTO_REP, UsuarioNombre,
                    ObjFactura.RECEPTOR_METODO_PAGO_FA, ObjFactura.FOLIO_PAGADO,
                    ObjFactura.RECEPTOR_CODIGO,  ObjFactura.RUTA_ADJUNTO_CONSTANCIA
                };
                String[] ParametrosOut = { "p_bandera" };
                cmm = CDDatos.GenerarOracleCommand("UPD_FACTURA_SOLICITUD", ref Verificador, Parametros, Valores, ParametrosOut);
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
        public void FacturaAgregarDatosCaja2(ref Facturacion ObjFactura, string UsuarioNombre, ref string Verificador)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand cmm = null;
            try
            {



                String[] Parametros = {"P_DEPENDENCIA","P_RECEPTOR_RFC", "P_RECEPTOR_TIPO_PERS", "P_RECEPTOR_NOMBRE",
                    "P_RECEPTOR_DOMICILIO", "P_RECEPTOR_COLONIA", "P_RECEPTOR_NUMERO_EXTERIOR", "P_RECEPTOR_NUMERO_INTERIOR", "P_RECEPTOR_ESTADO",
                    "P_RECEPTOR_MUNICIPIO", "P_RECEPTOR_CP", "P_RECEPTOR_METODO_PAGO", "P_FORMA_PAGO", "P_CFDI",
                    "P_RECEPTOR_TELEFONO", "P_RECEPTOR_CORREO", "P_RECEPTOR_OBSERVACIONES", "P_CONFIRMADO", "P_FOLIO_PAGO",
                    "P_FECHA_PAGO", "P_IMPORTE_PAGO", "P_IVA_PAGO", "P_TOTAL_PAGO", "P_NUMERO_OFICIO",
                    "P_FECHA_OFICIO", "P_IMPORTE_CONVENIO", "P_IVA_CONVENIO", "P_TOTAL_CONVENIO", "P_NOTAS_CONVENIO",
                    "P_FECHA_REP", "P_FOLIO_REP",
                    "P_RECEPTOR_STATUS", "P_RECEPTOR_STATUS_NOTAS", "P_TIPO", "P_RUTA_ARCHIVO_CONVENIO", "P_RUTA_ARCHIVO_OFICIO",
                    "P_RUTA_ADJUNTO_VOUCHER","P_RUTA_ADJUNTO_REP","P_USUARIO", "P_RECEPTOR_METODO_PAGO_FA", "P_FOLIO_PAGADO",
                    "P_RECEPTOR_CODIGO","P_RUTA_CONSTANCIA"
                };
                Object[] Valores = {
                    ObjFactura.DEPENDENCIA, ObjFactura.RECEPTOR_RFC,
                    ObjFactura.RECEPTOR_TIPO_PERS, ObjFactura.RECEPTOR_NOMBRE,
                    ObjFactura.RECEPTOR_DOMICILIO, ObjFactura.RECEPTOR_COLONIA, ObjFactura.NUMERO_EXTERIOR, ObjFactura.NUMERO_INTERIOR,
                    ObjFactura.RECEPTOR_ESTADO, ObjFactura.RECEPTOR_MUNICIPIO, ObjFactura.RECEPTOR_CP, ObjFactura.RECEPTOR_METODO_PAGO,
                    ObjFactura.RECEPTOR_FORMA_PAGO, ObjFactura.CFDI,
                    ObjFactura.RECEPTOR_TELEFONO, ObjFactura.RECEPTOR_CORREO, ObjFactura.OBSERVACIONES, ObjFactura.CONFIRMADO,
                    ObjFactura.FOLIO_PAGO, ObjFactura.FECHA_PAGO, ObjFactura.IMPORTE_PAGO, ObjFactura.IVA_PAGO, ObjFactura.TOTAL_PAGO,
                    ObjFactura.NUM_OFICIO, 
                    ObjFactura.FECHA_OFICIO, ObjFactura.IMPORTE_CONVENIO, ObjFactura.IVA_CONVENIO, ObjFactura.TOTAL_CONVENIO, ObjFactura.OBSERVACIONES_CONVENIO,
                    ObjFactura.FECHA_REP, ObjFactura.FOLIO_REP,
                    ObjFactura.RECEPTOR_STATUS, ObjFactura.RECEPTOR_STATUS_NOTAS, ObjFactura.TIPO,
                    ObjFactura.RUTA_ADJUNTO_CONVENIO, ObjFactura.RUTA_ADJUNTO_OFICIO, ObjFactura.RUTA_ADJUNTO, ObjFactura.RUTA_ADJUNTO_REP,
                    UsuarioNombre, ObjFactura.RECEPTOR_METODO_PAGO_FA, ObjFactura.FOLIO_PAGADO,
                    ObjFactura.RECEPTOR_CODIGO, ObjFactura.RUTA_ADJUNTO_CONSTANCIA
                };
                String[] ParametrosOut = { "P_BANDERA", "P_ID_FACT_EFECT" };
                cmm = CDDatos.GenerarOracleCommand("INS_FACTURA_SOLICITUD", ref Verificador, Parametros, Valores, ParametrosOut);
                ObjFactura.ID_FACT = Convert.ToInt32(cmm.Parameters["P_ID_FACT_EFECT"].Value);
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
        public void FacturaDetInsertar(List<DetConcepto> ListDetConc, int idFactEfec, ref string Verificador)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand Cmd = null;
            try
            {
                CDDatos.StartTrans();
                for (int i = 0; i < ListDetConc.Count; i++)
                {
                    String[] Parametros = { "P_ID_FACT_SOL", "P_CLAVE_CONCEPTO", "P_DESCRIPCION" };
                    object[] Valores = { idFactEfec, ListDetConc[i].ClaveConcepto, ListDetConc[i].Descripcion };
                    String[] ParametrosOut = { "p_Bandera" };
                    Cmd = CDDatos.GenerarOracleCommand("INS_FACT_SOL_DETALLE", ref Verificador, Parametros, Valores, ParametrosOut);
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
        public void FacturaDetEliminar(int idFactEfec, ref string Verificador)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand Cmd = null;
            try
            {
                string[] Parametros = { "P_ID_FACT_EFEC" };
                string[] ParametrosOut = { "P_BANDERA" };
                object[] Valores = { idFactEfec };
                Cmd = CDDatos.GenerarOracleCommand("DEL_FACT_SOL_DETALLE", ref Verificador, Parametros, Valores, ParametrosOut);
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
        public void FacturaDetConsultar(ref List<DetConcepto> ListDetConc, int idFactEfec)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand cmm = null;
            try
            {

                OracleDataReader dr = null;

                string[] ParametrosIn = { "P_ID_FACT_EFEC" };
                Object[] Valores = { idFactEfec };
                cmm = CDDatos.GenerarOracleCommandCursor("PKG_FELECTRONICA_2016.Obt_Grid_Facturas_Sol_Detalle", ref dr, ParametrosIn, Valores);

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
        public void FacturaEfectStatusConsultar(Facturacion objFacturacion, ref List<Facturacion> ListDetConc)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand cmm = null;
            try
            {

                OracleDataReader dr = null;

                string[] ParametrosIn = { "P_ID_FACT_EFEC" };
                Object[] Valores = { objFacturacion.ID_FACT };
                cmm = CDDatos.GenerarOracleCommandCursor("PKG_FELECTRONICA_2016.Obt_Grid_Facturas_Status", ref dr, ParametrosIn, Valores);

                while (dr.Read())
                {
                    //DetConcepto ObjConceptoDet = new DetConcepto();
                    //ObjConceptoDet.ClaveConcepto = Convert.ToString(dr.GetValue(0));
                    //ObjConceptoDet.Descripcion = Convert.ToString(dr.GetValue(1));
                    //ListDetConc.Add(ObjConceptoDet);
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

        public void FacturaSolConsultaGrid(Usuario ObjUsuario, ref Facturacion objFacturacion, String Dependencia, String FechaInicial, String FechaFinal, string Referencia, string Status, string Confirmados, string Tipo, ref List<Facturacion> List)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand cmm = null;
            try
            {
                OracleDataReader dr = null;

                String[] Parametros = { "p_usuario", "p_dependencia", "p_fecha_inicial", "p_fecha_final", "p_referencia", "p_status", "p_confirmados", "p_tipo" };
                String[] Valores = { ObjUsuario.Usu_Nombre, Dependencia, FechaInicial, FechaFinal, Referencia, Status, Confirmados, Tipo };

                cmm = CDDatos.GenerarOracleCommandCursor("PKG_FELECTRONICA_2016.Obt_Grid_Solicitar_Fact_Efec", ref dr, Parametros, Valores);
                while (dr.Read())
                {
                    objFacturacion = new Facturacion();
                    objFacturacion.ID_FACT = Convert.ToInt32(dr.GetValue(0)); //Este obtiene el Id de la Tabla Factura o Factura_Caja
                    objFacturacion.DEPENDENCIA = Convert.ToString(dr.GetValue(1));
                    objFacturacion.RECEPTOR_RFC = Convert.ToString(dr.GetValue(2));
                    objFacturacion.RECEPTOR_NOMBRE = Convert.ToString(dr.GetValue(3));
                    objFacturacion.NUM_OFICIO = Convert.ToString(dr.GetValue(4));
                    objFacturacion.FECHA_OFICIO = Convert.ToString(dr.GetValue(5));

                    objFacturacion.FOLIO_PAGO = Convert.ToString(dr.GetValue(6));
                    objFacturacion.FECHA_PAGO = Convert.ToString(dr.GetValue(7));
                    objFacturacion.IMPORTE_PAGO = Convert.ToDouble(dr.GetValue(8));
                    objFacturacion.IVA_PAGO = Convert.ToDouble(dr.GetValue(9));
                    objFacturacion.TOTAL_PAGO = Convert.ToDouble(dr.GetValue(10));
                    objFacturacion.DIAS_SOLICITUD = Convert.ToInt32(dr.GetValue(11));
                    objFacturacion.RECEPTOR_CORREO = Convert.ToString(dr.GetValue(12));
                    objFacturacion.RECEPTOR_STATUS = Convert.ToString(dr.GetValue(13));
                    objFacturacion.RECHAZADO = "N";
                    objFacturacion.TIPO = Convert.ToString(dr.GetValue(14));
                    objFacturacion.COLOR = (objFacturacion.RECEPTOR_STATUS == "R") ? "RED" : Convert.ToString(dr.GetValue(16)) == "TRUE" ? "YELLOW" : "";
                    objFacturacion.RECEPTOR_FECHA_STATUS = Convert.ToString(dr.GetValue(17));
                    objFacturacion.IMPORTE_CONVENIO = Convert.ToDouble(dr.GetValue(18));
                    objFacturacion.IVA_CONVENIO = Convert.ToDouble(dr.GetValue(19));
                    objFacturacion.TOTAL_CONVENIO = Convert.ToDouble(dr.GetValue(20));
                    objFacturacion.FECHA_REP = Convert.ToString(dr.GetValue(21));
                    objFacturacion.FOLIO_REP = Convert.ToString(dr.GetValue(22));
                    objFacturacion.VISIBLE1 = true;
                    objFacturacion.VISIBLE2 = false;

                    if (objFacturacion.RECEPTOR_STATUS == "R")
                    {
                       
                        objFacturacion.DESC_RECEPTOR_STATUS = "RECHAZADO";
                    }
                    else if (objFacturacion.RECEPTOR_STATUS == "S")
                    {
                    
                        objFacturacion.DESC_RECEPTOR_STATUS = "SOLICITADO";
                    }
                    else if (objFacturacion.RECEPTOR_STATUS == "C")
                    {
                      
                        objFacturacion.DESC_RECEPTOR_STATUS = "FALTA CONFIRMAR";
                    }
                    else if (objFacturacion.RECEPTOR_STATUS == "P")
                        objFacturacion.DESC_RECEPTOR_STATUS = "PAGADO";
                    else if (objFacturacion.RECEPTOR_STATUS == "E")
                        objFacturacion.DESC_RECEPTOR_STATUS = "REP (CONCLUIDO)";
                    else if (objFacturacion.RECEPTOR_STATUS == "F")
                    {
                       
                        objFacturacion.DESC_RECEPTOR_STATUS = "FACTURADO";
                    }

                   

                    List.Add(objFacturacion);
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
        public void FacturaSolBorrar(Facturacion ObjFactura, ref string Verificador)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand Cmd = null;
            try
            {
                String[] Parametros = { "P_ID_FACTURA_EFEC"
                                      };
                object[] Valores = { ObjFactura.ID_FACT };
                String[] ParametrosOut = { "p_Bandera" };

                Cmd = CDDatos.GenerarOracleCommand("DEL_FACTURA_SOLICITUD", ref Verificador, Parametros, Valores, ParametrosOut);

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
        public void FacturaDoctoAgregar(string Usuario, ref List<CajaFactura> Archivos, int IdFactura, string RutaServ, string Tipo, ref string Verificador)
        {
            for (int i = 0; i < Archivos.Count; i++)
            {
                CD_Datos CDDatos = new CD_Datos();
                OracleCommand OracleCmd = null;

                try
                {

                    if (Archivos[i].Ruta != null)
                    {
                        string[] Parametros = { "P_ID_FACTURA",
                                        "P_TIPO",
                                        "P_USUARIO",
                                        "P_FECHA_FACT",
                                        "P_FOLIO_FACT",
                                        "P_EXTENSION",
                                        "P_RUTA",
                                        "P_NOMBRE_ARCHIVO"
                                      };
                        string[] ParametrosOut = { "P_BANDERA" };


                        object[] Valores = {
                                        IdFactura,
                                        Tipo,
                                        Usuario,
                                        Archivos[i].Fecha_Fact_Cja,
                                        Archivos[i].Folio_Fact_Cja,
                                        Archivos[i].ExtensionArchivo,
                                        Archivos[i].Ruta,
                                        Archivos[i].NombreArchivo
                                       };
                        OracleCmd = CDDatos.GenerarOracleCommand("INS_FACTURA_DOCTO", ref Verificador, Parametros, Valores, ParametrosOut);
                        string OrigenArchivo = RutaServ + Archivos[i].NombreArchivo; // + Archivos[i].ExtensionArchivo;
                        string DestinoArchivo;
                        //DestinoArchivo = RutaServ.Replace("ArchivosFacturasTemp", "ArchivosFacturas") + Archivos[i].Folio_Fact_Cja + Archivos[i].ExtensionArchivo;
                        //DestinoArchivo = RutaServ.Replace("ArchivosFacturasTemp", "ArchivosFacturas") + Archivos[i].NombreArchivo + Archivos[i].ExtensionArchivo;
                        DestinoArchivo = RutaServ.Replace("ArchivosFacturasTemp", "ArchivosFacturas") + Archivos[i].NombreArchivo;

                        if (System.IO.File.Exists(OrigenArchivo))
                        {
                            System.IO.File.Copy(OrigenArchivo, DestinoArchivo, true);
                            System.IO.File.Delete(OrigenArchivo);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
                finally
                {
                    CDDatos.LimpiarOracleCommand(ref OracleCmd);
                }
            }
        }
        public void FacturaDoctoBorrar(Facturacion ObjFactura, ref string Verificador)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand Cmd = null;
            try
            {
                String[] Parametros = { "P_ID_FACTURA", "P_TIPO"
                                      };
                object[] Valores = { ObjFactura.ID_FACT, ObjFactura.TIPO };
                String[] ParametrosOut = { "p_Bandera" };

                Cmd = CDDatos.GenerarOracleCommand("DEL_FACTURA_CAJA", ref Verificador, Parametros, Valores, ParametrosOut);

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
        public void FacturaHistSolConsultaGrid(Facturacion objFacturacion, ref List<Facturacion> List)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand cmm = null;
            try
            {
                OracleDataReader dr = null;

                String[] Parametros = { "P_Id_Solicitud" };
                String[] Valores = { Convert.ToString(objFacturacion.ID_FACT) };

                cmm = CDDatos.GenerarOracleCommandCursor("PKG_FELECTRONICA_2016.Obt_Grid_Hist_Fact_Solicitud", ref dr, Parametros, Valores);
                while (dr.Read())
                {
                    objFacturacion = new Facturacion();
                    objFacturacion.DESC_RECEPTOR_STATUS = Convert.ToString(dr.GetValue(0)); //Este obtiene el Id de la Tabla Factura o Factura_Caja
                    objFacturacion.RECEPTOR_FECHA_STATUS = Convert.ToString(dr.GetValue(1));
                    List.Add(objFacturacion);
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
        public void FacturaDoctosConsultaGrid(Facturacion ObjFactura, ref List<Facturacion> List)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand cmm = null;
            try
            {
                OracleDataReader dr = null;

                String[] Parametros = { "P_Id_Factura" };
                String[] Valores = { Convert.ToString(ObjFactura.ID_FACT) };

                cmm = CDDatos.GenerarOracleCommandCursor("PKG_FELECTRONICA_2016.Obt_Grid_Doctos_Facturacion", ref dr, Parametros, Valores);
                while (dr.Read())
                {
                    ObjFactura = new Facturacion();
                    ObjFactura.TIPO = Convert.ToString(dr.GetValue(0)); //Este obtiene el Id de la Tabla Factura o Factura_Caja
                    ObjFactura.RUTA_ADJUNTO = Convert.ToString(dr.GetValue(1));
                    ObjFactura.NUM_OFICIO = Convert.ToString(dr.GetValue(2));
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


    }
}
