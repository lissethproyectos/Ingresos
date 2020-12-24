using System;
using System.Collections.Generic;
using System.Text;
using System.Data.OracleClient;
using System.Data;
using CapaEntidad;
using System.Web.UI.WebControls;
using System.IO;
#region Hecho por
//Nombre:      Melissa Alejandra Rodríguez González
//Correo:      melissargz@hotmail.com
//Institución: Unach
#endregion
namespace CapaDatos
{
    public class CD_Factura
    {
        public void Status_Carga(ref DataTable _tabla)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand cmm = null;
            try
            {
                OracleDataReader dr = null;

                string[] Parametros = { };
                object[] Valores = { };
                cmm = CDDatos.GenerarOracleCommandCursor("PKG_FELECTRONICA.Obt_Status_Carga", ref dr, Parametros, Valores);
                OracleDataAdapter adaptador = new OracleDataAdapter();
                adaptador.SelectCommand = cmm;
                adaptador.Fill(_tabla);

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
        public void Obt_Grid_Status_Bancos_Usu(Comun ObjComun, ref List<Comun> List)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand cmm = null;
            try
            {
                OracleDataReader dr = null;

                cmm = CDDatos.GenerarOracleCommandCursor("PKG_FELECTRONICA_2016.Obt_Grid_Status_Bancos_Usu", ref dr);
                while (dr.Read())
                {
                    ObjComun = new Comun();
                    ObjComun.Etiqueta = Convert.ToString(dr.GetValue(0));
                    ObjComun.EtiquetaDos = Convert.ToString(dr.GetValue(1));
                    ObjComun.EtiquetaTres = Convert.ToString(dr.GetValue(2));
                    ObjComun.EtiquetaCuatro = Convert.ToString(dr.GetValue(3));
                    ObjComun.EtiquetaCinco = Convert.ToString(dr.GetValue(4));
                    ObjComun.EtiquetaSeis = Convert.ToString(dr.GetValue(5));
                    ObjComun.EtiquetaSiete = Convert.ToString(dr.GetValue(6));
                    List.Add(ObjComun);

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
        public void Obt_Grid_Status_Bancos(Comun ObjComun, ref List<Comun> List)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand cmm = null;
            try
            {
                OracleDataReader dr = null;

                cmm = CDDatos.GenerarOracleCommandCursor("PKG_FELECTRONICA_2016.Obt_Grid_Status_Bancos", ref dr);
                while (dr.Read())
                {
                    ObjComun = new Comun();
                    ObjComun.Etiqueta = Convert.ToString(dr.GetValue(0));
                    List.Add(ObjComun);

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
        public void FacturaTempConsultaGrid(ref DataTable _tabla)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand cmm = null;
            try
            {
                OracleDataReader dr = null;

                string[] Parametros = { };
                object[] Valores = { };
                cmm = CDDatos.GenerarOracleCommandCursor("PKG_FELECTRONICA.Obt_Grid_Fact_Temp", ref dr, Parametros, Valores);
                OracleDataAdapter adaptador = new OracleDataAdapter();
                adaptador.SelectCommand = cmm;
                adaptador.Fill(_tabla);

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
        public void ErroresConsultaGrid(string Usuario, ref List<Comun> List)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand cmm = null;
            try
            {
                OracleDataReader dr = null;

                string[] Parametros = { "p_usuario" };
                object[] Valores = { Usuario  };
                cmm = CDDatos.GenerarOracleCommandCursor("PKG_FELECTRONICA.Obt_Grid_Errores", ref dr, Parametros, Valores);
                while (dr.Read())
                {
                    Comun ObjComun = new Comun();
                    ObjComun.Descripcion = Convert.ToString(dr.GetValue(0));
                    ObjComun.Habil = Convert.ToString(dr.GetValue(1)) == "1" ? true : false;
                    ObjComun.Inhabil= Convert.ToString(dr.GetValue(1)) == "1" || Convert.ToString(dr.GetValue(1)) == "3" ? false : true;
                    ObjComun.EtiquetaDos = Convert.ToString(dr.GetValue(1));
                    ObjComun.EtiquetaTres = Convert.ToString(dr.GetValue(2));
                    List.Add(ObjComun);
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
        public void FacturaConsultaGrid(Usuario ObjUsuario, ref Factura ObjFactura, String Dependencia, String FechaInicial, String FechaFinal, string Referencia, ref List<Factura> List)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand cmm = null;
            try
            {
                OracleDataReader dr = null;

                String[] Parametros = { "p_tipo_usuario", "p_usuario", "p_dependencia", "p_fecha_inicial", "p_fecha_final", "p_contrasena", "p_referencia" };
                String[] Valores = { ObjUsuario.Usu_TipoUsu.ToString(), ObjUsuario.Usu_Nombre, Dependencia, FechaInicial, FechaFinal, ObjUsuario.Usu_NoControl, Referencia };

                cmm = CDDatos.GenerarOracleCommandCursor("PKG_FELECTRONICA_2016.Obt_Grid_Facturas", ref dr, Parametros, Valores);
                while (dr.Read())
                {
                    ObjFactura = new Factura();
                    ObjFactura.ID_FACT = Convert.ToString(dr.GetValue(0));
                    ObjFactura.FACT_FOLIO = Convert.ToString(dr.GetValue(1));
                    ObjFactura.FACT_REFERENCIA = Convert.ToString(dr.GetValue(6));
                    ObjFactura.FACT_FECHA_FACTURA = Convert.ToString(dr.GetValue(2));
                    ObjFactura.FACT_TOTAL = Convert.ToString(dr.GetValue(3));
                    ObjFactura.FACT_NOMBRE = Convert.ToString(dr.GetValue(4));
                    ObjFactura.FACT_DEPENDENCIA = Convert.ToString(dr.GetValue(5));
                    ObjFactura.FACT_MATRICULA = Convert.ToString(dr.GetValue(7));
                    ObjFactura.ID_CODIGO_QR = Convert.ToInt32(dr.GetValue(8));
                    ObjFactura.VISIBLE1= Convert.ToInt32(dr.GetValue(9))==0?false:true;
                    ObjFactura.VISIBLE2 = Convert.ToInt32(dr.GetValue(9)) == 0 ? true : false;
                    ObjFactura.RUTA_ADJUNTO= Convert.ToInt32(dr.GetValue(9)) == 0 ? "" : "~/Imagenes/fact_xml.png";
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
        public void FacturaEventosConsultaGrid(ref Factura ObjFactura, Usuario objUsuario, string Evento, string Busqueda, ref List<Factura> List)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand cmm = null;
            try
            {
                OracleDataReader dr = null;

                String[] Parametros = { "P_EVENTO", "P_TIPO_USUARIO", "P_USUARIO", "p_referencia" };
                String[] Valores = { Evento, Convert.ToString(objUsuario.Usu_TipoUsu), objUsuario.Usu_Nombre, Busqueda };

                cmm = CDDatos.GenerarOracleCommandCursor("PKG_FELECTRONICA_2016.Obt_Grid_Facturas_Eventos", ref dr, Parametros, Valores);
                while (dr.Read())
                {
                    ObjFactura = new Factura();
                    ObjFactura.ID_FACT = Convert.ToString(dr.GetValue(0));
                    ObjFactura.FACT_FOLIO = Convert.ToString(dr.GetValue(1));
                    ObjFactura.FACT_REFERENCIA = Convert.ToString(dr.GetValue(2));
                    ObjFactura.FACT_FECHA_FACTURA = Convert.ToString(dr.GetValue(3));
                    ObjFactura.FACT_TOTAL = Convert.ToString(dr.GetValue(4));
                    ObjFactura.FACT_NOMBRE = Convert.ToString(dr.GetValue(5));
                    ObjFactura.FACT_DEPENDENCIA = Convert.ToString(dr.GetValue(6));
                    ObjFactura.FACT_MATRICULA = Convert.ToString(dr.GetValue(7));
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

        public void FacturaProductosConsultaGrid(string Dependencia, string Pagado, string FechaInicial, string FechaFinal, string Buscar, int TipoUsuario, string CveCliente, ref List<Factura> List)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand cmm = null;            
            try
            {
                OracleDataReader dr = null;

                if (TipoUsuario == 6)
                {
                    String[] Parametros = { "p_dependencia", "p_pagado", "p_fecha_inicial", "p_fecha_final", "p_busca", "p_ClaveSysweb" };
                    String[] Valores = { Dependencia, Pagado, FechaInicial, FechaFinal, Buscar, CveCliente };
                    cmm = CDDatos.GenerarOracleCommandCursor("PKG_FELECTRONICA_2016.Obt_Grid_Fact_Prod_Clientes", ref dr, Parametros, Valores);
                }
                else
                {
                    String[] Parametros = { "p_dependencia", "p_pagado", "p_fecha_inicial", "p_fecha_final", "p_busca"};
                    String[] Valores = { Dependencia, Pagado, FechaInicial, FechaFinal, Buscar };
                    cmm = CDDatos.GenerarOracleCommandCursor("PKG_FELECTRONICA_2016.Obt_Grid_Facturas_Productos", ref dr, Parametros, Valores);
                }


                while (dr.Read())
                {
                    Factura ObjFactura = new Factura();
                    ObjFactura.ID_FACT = Convert.ToString(dr.GetValue(0));
                    ObjFactura.FACT_FOLIO = Convert.ToString(dr.GetValue(1));
                    ObjFactura.FACT_REFERENCIA = Convert.ToString(dr.GetValue(2));
                    ObjFactura.FACT_FECHA_FACTURA = Convert.ToString(dr.GetValue(3));
                    ObjFactura.FACT_TOTAL = Convert.ToString(dr.GetValue(4));
                    ObjFactura.FACT_NOMBRE = Convert.ToString(dr.GetValue(5));
                    ObjFactura.FACT_DEPENDENCIA = Convert.ToString(dr.GetValue(6));
                    ObjFactura.FACT_MATRICULA = Convert.ToString(dr.GetValue(7));
                    ObjFactura.PAGADO= Convert.ToString(dr.GetValue(8));
                    ObjFactura.VISIBLE1 = (Convert.ToString(dr.GetValue(8)) == "N") ? true : false;
                    ObjFactura.VISIBLE2 = (Convert.ToString(dr.GetValue(8)) == "N") ? false : true;
                    ObjFactura.ID_FICHA_BANCARIA = Convert.ToInt32(dr.GetValue(9));
                    ObjFactura.ID_CODIGO_QR = Convert.ToInt32(dr.GetValue(10));

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
        public void FacturaConsultaGridRetenciones(Usuario ObjUsuario, ref Factura ObjFactura, String Dependencia, String FechaInicial, String FechaFinal, string Referencia, string MesPago, ref List<Factura> List)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand cmm = null;
            try
            {
                OracleDataReader dr = null;

                String[] Parametros = { "p_usuario", "p_dependencia", "p_fecha_inicial", "p_fecha_final", "p_referencia", "p_mes_pago" };
                String[] Valores = { ObjUsuario.Usu_Nombre, Dependencia, FechaInicial, FechaFinal,Referencia, MesPago };

                cmm = CDDatos.GenerarOracleCommandCursor("PKG_FELECTRONICA_2016.Obt_Grid_Facturas_Retenciones", ref dr, Parametros, Valores);
                while (dr.Read())
                {
                    ObjFactura = new Factura();
                    ObjFactura.ID_FACT = Convert.ToString(dr.GetValue(0));
                    ObjFactura.FACT_FOLIO = Convert.ToString(dr.GetValue(1));
                    ObjFactura.FACT_REFERENCIA = Convert.ToString(dr.GetValue(6));
                    ObjFactura.FACT_FECHA_FACTURA = Convert.ToString(dr.GetValue(2));
                    ObjFactura.FACT_TOTAL = Convert.ToString(dr.GetValue(3));
                    ObjFactura.FACT_NOMBRE = Convert.ToString(dr.GetValue(4));
                    ObjFactura.FACT_DEPENDENCIA = Convert.ToString(dr.GetValue(5));
                    ObjFactura.FACT_MATRICULA = Convert.ToString(dr.GetValue(7));
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
        public void FacturaConsultaPago_Sauce(ref Factura ObjFactura, String Ciclo_Escolar, ref string Verificador)
        {
            CD_Datos CDDatos = new CD_Datos("INGRESOS");
            OracleCommand Cmd = null;
            try
            {


                string[] ParametrosIn = { "p_ciclo_escolar",
                                          "p_matricula"};
                object[] Valores = { Ciclo_Escolar,
                                     ObjFactura.FACT_MATRICULA
            };
                string[] ParametrosOut ={
                                        
                                          "p_confirmado","p_bandera"
                };

                Cmd = CDDatos.GenerarOracleCommand("VAL_PAGO_SAUCE", ref Verificador, ParametrosIn, Valores, ParametrosOut);
                if (Verificador == "0")
                {
                    ObjFactura = new Factura();
                    ObjFactura.FACT_CONFIRMADO = Convert.ToString(Cmd.Parameters["p_confirmado"].Value);

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
        public void FacturaConsultaGrid_Ref_Sauce(Factura ObjFactura, String Ciclo_Escolar, ref List<Factura> List)
        {
            CD_Datos CDDatos = new CD_Datos("INGRESOS");
            OracleCommand cmm = null;
            try
            {
                OracleDataReader dr = null;

                String[] Parametros = { "p_ciclo_escolar", "p_matricula"};
                String[] Valores = { Ciclo_Escolar, ObjFactura.FACT_MATRICULA};

                cmm = CDDatos.GenerarOracleCommandCursor("pkg_pagos.Obt_Grid_Referencias_Sauce", ref dr, Parametros, Valores);
                while (dr.Read())
                {
                    ObjFactura = new Factura();
                    ObjFactura.FACT_REFERENCIA = Convert.ToString(dr.GetValue(0));
                    ObjFactura.FACT_DEPENDENCIA = Convert.ToString(dr.GetValue(1));
                    ObjFactura.FACT_TOTAL = Convert.ToString(dr.GetValue(2));
                    ObjFactura.FACT_FOLIO = Convert.ToString(dr.GetValue(3));
                    ObjFactura.FACT_BANCO = Convert.ToString(dr.GetValue(4));
                    ObjFactura.FACT_FECHA_FACTURA = Convert.ToString(dr.GetValue(5));
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
        public void FichaRefConsultaGrid(Factura ObjFactura, string Busca, ref List<Factura> List)
        {
            CD_Datos CDDatos = new CD_Datos("INGRESOS");
            OracleCommand cmm = null;
            try
            {
                OracleDataReader dr = null;

                String[] Parametros = { "p_Busca" };
                String[] Valores = { Busca };

                cmm = CDDatos.GenerarOracleCommandCursor("PKG_PAGOS_2016.Obt_Grid_FichasRef_Generadas", ref dr, Parametros, Valores);
                while (dr.Read())
                {
                    ObjFactura = new Factura();
                    ObjFactura.FACT_NOTAS = Convert.ToString(dr.GetValue(0));
                    ObjFactura.FACT_REFERENCIA = Convert.ToString(dr.GetValue(1));
                    ObjFactura.FACT_OBSERVACIONES = Convert.ToString(dr.GetValue(2));
                    ObjFactura.FACT_FECHA_CAPTURA = Convert.ToString(dr.GetValue(3));
                    ObjFactura.FACT_NOMBRE = Convert.ToString(dr.GetValue(4));
                    ObjFactura.FACT_TOTAL = Convert.ToString(dr.GetValue(5));                    
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

        public void ConsultarRefAspirantes(Factura ObjFactura, string Busqueda, ref List<Factura> List)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand cmm = null;
            try
            {
                OracleDataReader dr = null;

                String[] Parametros = { "p_escuela", "p_pagado", "p_Busca" };
                String[] Valores = { ObjFactura.FACT_DEPENDENCIA, ObjFactura.FACT_CONFIRMADO, Busqueda };

                cmm = CDDatos.GenerarOracleCommandCursor("PKG_FELECTRONICA_2016.Obt_Grid_RefAspirantes", ref dr, Parametros, Valores);
                while (dr.Read())
                {
                    ObjFactura = new Factura();
                    ObjFactura.CICLO_ESCOLAR = Convert.ToString(dr.GetValue(0));
                    ObjFactura.FACT_DEPENDENCIA = Convert.ToString(dr.GetValue(1));
                    ObjFactura.FACT_CARRERA = Convert.ToString(dr.GetValue(2));
                    ObjFactura.FACT_MATRICULA = Convert.ToString(dr.GetValue(3));
                    ObjFactura.FACT_REFERENCIA = Convert.ToString(dr.GetValue(4));
                    ObjFactura.FACT_FOLIO = Convert.ToString(dr.GetValue(5));
                    ObjFactura.FACT_BANCO = Convert.ToString(dr.GetValue(6));
                    ObjFactura.ID_FICHA_BANCARIA = Convert.ToInt32(dr.GetValue(7));
                    ObjFactura.FACT_CONFIRMADO = Convert.ToString(dr.GetValue(8));
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


        public void FacturaDetalleConsultaGrid(ref DetFactura ObjDetFactura, ref List<DetFactura> List)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand cmm = null;
            try
            {
                OracleDataReader dr = null;

                String[] Parametros = { "p_id_factura" };
                String[] Valores = { ObjDetFactura.ID_FACT };

                cmm = CDDatos.GenerarOracleCommandCursor("pkg_felectronica.Obt_Grid_Factura_Detalle", ref dr, Parametros, Valores);
                while (dr.Read())
                {
                    ObjDetFactura = new DetFactura();
                    ObjDetFactura.IdDetFact = Convert.ToInt32(dr.GetValue(0));
                    ObjDetFactura.ClaveConcepto = Convert.ToString(dr.GetValue(1));
                    ObjDetFactura.DescConcepto = Convert.ToString(dr.GetValue(2));
                    ObjDetFactura.Cantidad = Convert.ToInt32(dr.GetValue(3));
                    ObjDetFactura.ValorUnitario = Convert.ToString(dr.GetValue(4));
                    ObjDetFactura.Importe = Convert.ToString(dr.GetValue(5));                    
                    List.Add(ObjDetFactura);
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
        public void FacturaConsulta(ref Factura ObjFactura, ref string Verificador)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand Cmd = null;
            try
            {


                String[] Parametros = { "p_id_factura" };
                Object[] Valores = { ObjFactura.ID_FACT };
                String[] ParametrosOut = { "p_nombre", "p_carrera", "p_matricula", "p_observaciones", "p_referencia", "p_fecha", "p_importe", "p_folio_recibo", "p_banco", "p_folio_bancario", "p_Bandera" };
                Cmd = CDDatos.GenerarOracleCommand("SEL_FACTURA", ref Verificador, Parametros, Valores, ParametrosOut);
                if (Verificador == "0")
                {
                    ObjFactura.FACT_NOMBRE = Convert.ToString(Cmd.Parameters["p_nombre"].Value);
                    ObjFactura.FACT_CARRERA = Convert.ToString(Cmd.Parameters["p_carrera"].Value);
                    ObjFactura.FACT_MATRICULA = Convert.ToString(Cmd.Parameters["p_matricula"].Value);
                    ObjFactura.FACT_OBSERVACIONES = Convert.ToString(Cmd.Parameters["p_observaciones"].Value);
                    ObjFactura.FACT_REFERENCIA = Convert.ToString(Cmd.Parameters["p_referencia"].Value);
                    ObjFactura.FACT_FECHA_FACTURA = Convert.ToString(Cmd.Parameters["p_fecha"].Value);
                    ObjFactura.FACT_TOTAL = Convert.ToString(Cmd.Parameters["p_importe"].Value);
                    ObjFactura.FACT_FOLIO = Convert.ToString(Cmd.Parameters["p_folio_recibo"].Value);
                    ObjFactura.FACT_BANCO = Convert.ToString(Cmd.Parameters["p_banco"].Value);
                    ObjFactura.FACT_FOLIOBANCARIO = Convert.ToString(Cmd.Parameters["p_folio_bancario"].Value);
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


        public void ConsultarRFC(ref Factura ObjFactura, ref string Verificador)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand Cmd = null;
            try
            {


                String[] Parametros = { "P_RFC" };
                Object[] Valores = { ObjFactura.FACT_RECEPTOR_RFC };
                String[] ParametrosOut = { "p_nombre", "p_carrera", "p_matricula", "p_observaciones", "p_referencia", "p_fecha", "p_importe", "p_folio_recibo", "p_banco", "p_folio_bancario", "p_Bandera" };
                Cmd = CDDatos.GenerarOracleCommand("SEL_FACTURA", ref Verificador, Parametros, Valores, ParametrosOut);
                if (Verificador == "0")
                {
                    ObjFactura.FACT_NOMBRE = Convert.ToString(Cmd.Parameters["p_nombre"].Value);
                    ObjFactura.FACT_CARRERA = Convert.ToString(Cmd.Parameters["p_carrera"].Value);
                    ObjFactura.FACT_MATRICULA = Convert.ToString(Cmd.Parameters["p_matricula"].Value);
                    ObjFactura.FACT_OBSERVACIONES = Convert.ToString(Cmd.Parameters["p_observaciones"].Value);
                    ObjFactura.FACT_REFERENCIA = Convert.ToString(Cmd.Parameters["p_referencia"].Value);
                    ObjFactura.FACT_FECHA_FACTURA = Convert.ToString(Cmd.Parameters["p_fecha"].Value);
                    ObjFactura.FACT_TOTAL = Convert.ToString(Cmd.Parameters["p_importe"].Value);
                    ObjFactura.FACT_FOLIO = Convert.ToString(Cmd.Parameters["p_folio_recibo"].Value);
                    ObjFactura.FACT_BANCO = Convert.ToString(Cmd.Parameters["p_banco"].Value);
                    ObjFactura.FACT_FOLIOBANCARIO = Convert.ToString(Cmd.Parameters["p_folio_bancario"].Value);
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

        public void FacturaConsultaDatos(ref Factura ObjFactura, ref string Verificador)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand Cmd = null;
            try
            {

                String[] Parametros = { "p_id_factura" };
                Object[] Valores = { ObjFactura.ID_FACT };
                String[] ParametrosOut = { "p_receptor_nombre", "p_receptor_rfc", "p_receptor_domicilio", "p_receptor_colonia", "p_receptor_lugar", "p_matricula", "p_carrera", "p_dependencia", 
                                           "p_expedido_domicilio", "p_expedido_colonia", "p_expedido_pais","p_fecha_cfd","p_total_letras","p_notas","p_certificado",
                                           "p_subtotal","p_impuesto_tasa","p_total","p_sello_digital","p_folio","p_no_certificado","p_anio_aprobacion","p_status","p_status_notas","p_receptor_municipio","p_fecha_dispersion", "p_modificable", "p_Bandera" };
                Cmd = CDDatos.GenerarOracleCommand("Sel_Factura_Datos", ref Verificador, Parametros, Valores, ParametrosOut);
                if (Verificador == "0")
                {
                    ObjFactura.FACT_NOMBRE = Convert.ToString(Cmd.Parameters["p_receptor_nombre"].Value);
                    ObjFactura.FACT_RECEPTOR_RFC = Convert.ToString(Cmd.Parameters["p_receptor_rfc"].Value);
                    ObjFactura.FACT_RECEPTOR_DOMICILIO = Convert.ToString(Cmd.Parameters["p_receptor_domicilio"].Value);
                    ObjFactura.FACT_RECEPTOR_COLONIA = Convert.ToString(Cmd.Parameters["p_receptor_colonia"].Value);
                    ObjFactura.FACT_RECEPTOR_LUGAR = Convert.ToString(Cmd.Parameters["p_receptor_lugar"].Value);
                    ObjFactura.FACT_MATRICULA = Convert.ToString(Cmd.Parameters["p_matricula"].Value);
                    ObjFactura.FACT_CARRERA = Convert.ToString(Cmd.Parameters["p_carrera"].Value);
                    ObjFactura.FACT_DEPENDENCIA = Convert.ToString(Cmd.Parameters["p_dependencia"].Value);
                    ObjFactura.FACT_EXPEDIDO_DOMICILIO= Convert.ToString(Cmd.Parameters["p_expedido_domicilio"].Value);
                    ObjFactura.FACT_EXPEDIDO_COLONIA = Convert.ToString(Cmd.Parameters["p_expedido_colonia"].Value);
                    ObjFactura.FACT_EXPEDIDO_PAIS = Convert.ToString(Cmd.Parameters["p_expedido_pais"].Value);
                    ObjFactura.FACT_FECHA_CFD = Convert.ToString(Cmd.Parameters["p_fecha_cfd"].Value);
                    ObjFactura.FACT_OBSERVACIONES = Convert.ToString(Cmd.Parameters["p_notas"].Value);
                    ObjFactura.FACT_CERTIFICADO = Convert.ToString(Cmd.Parameters["p_certificado"].Value);
                    ObjFactura.FACT_SUBTOTAL = Convert.ToString(Cmd.Parameters["p_subtotal"].Value);
                    ObjFactura.FACT_IMPUESTO_TASA = Convert.ToString(Cmd.Parameters["p_impuesto_tasa"].Value);
                    ObjFactura.FACT_TOTAL = Convert.ToString(Cmd.Parameters["p_total"].Value);
                    ObjFactura.FACT_SELLO_DIGITAL = Convert.ToString(Cmd.Parameters["p_sello_digital"].Value);
                    ObjFactura.FACT_FOLIO = Convert.ToString(Cmd.Parameters["p_folio"].Value);
                    ObjFactura.FACT_NO_CERTIFICADO = Convert.ToString(Cmd.Parameters["p_no_certificado"].Value);
                    ObjFactura.FACT_ANIO_APROBACION = Convert.ToString(Cmd.Parameters["p_anio_aprobacion"].Value);
                    ObjFactura.FACT_STATUS = Convert.ToString(Cmd.Parameters["p_status"].Value);
                    ObjFactura.FACT_STATUS_NOTAS = Convert.ToString(Cmd.Parameters["p_status_notas"].Value);
                    ObjFactura.FACT_RECEPTOR_MUNICIPIO = Convert.ToString(Cmd.Parameters["p_receptor_municipio"].Value);
                    ObjFactura.FACT_FECHA_DISPERSION = Convert.ToString(Cmd.Parameters["p_fecha_dispersion"].Value);
                    ObjFactura.FACT_MODIFICABLE = Convert.ToString(Cmd.Parameters["p_modificable"].Value);
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
        public void FacturaConsultaDatosFiscales(ref Factura ObjFactura, ref string Verificador)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand Cmd = null;
            try
            {

                String[] Parametros = { "p_id_factura" };
                Object[] Valores = { Convert.ToInt32(ObjFactura.ID_FACT) };
                String[] ParametrosOut = { "p_dependencia","p_receptor_nombre", "p_receptor_rfc", "p_receptor_domicilio", "p_receptor_colonia", "p_receptor_estado",
                                           "p_receptor_municipio","p_receptor_tipo_persona","p_receptor_telefono","p_receptor_correo",
                                           "p_receptor_metodo_pago","p_receptor_cp","p_receptor_status","p_receptor_status_notas","P_CFDI","P_RECEPTOR_TIPO_SERVICIO","P_RECEPTOR_OBSERVACIONES","P_CONFIRMADO","P_RECEPTOR_FORMA_PAGO","p_Bandera" };
                Cmd = CDDatos.GenerarOracleCommand("SEL_INF_FACTURA_CAJA", ref Verificador, Parametros, Valores, ParametrosOut);
                if (Verificador == "0")
                {
                    ObjFactura.FACT_DEPENDENCIA = Convert.ToString(Cmd.Parameters["p_dependencia"].Value);
                    ObjFactura.FACT_NOMBRE = Convert.ToString(Cmd.Parameters["p_receptor_nombre"].Value);
                    ObjFactura.FACT_RECEPTOR_TIPO_PERS = Convert.ToString(Cmd.Parameters["p_receptor_tipo_persona"].Value);
                    ObjFactura.FACT_RECEPTOR_RFC = Convert.ToString(Cmd.Parameters["p_receptor_rfc"].Value);
                    ObjFactura.FACT_RECEPTOR_DOMICILIO = Convert.ToString(Cmd.Parameters["p_receptor_domicilio"].Value);
                    ObjFactura.FACT_RECEPTOR_COLONIA = Convert.ToString(Cmd.Parameters["p_receptor_colonia"].Value);
                    ObjFactura.FACT_RECEPTOR_ESTADO = Convert.ToString(Cmd.Parameters["p_receptor_estado"].Value);
                    ObjFactura.FACT_RECEPTOR_MUNICIPIO = Convert.ToString(Cmd.Parameters["p_receptor_municipio"].Value);
                    ObjFactura.FACT_RECEPTOR_TELEFONO = Convert.ToString(Cmd.Parameters["p_receptor_telefono"].Value);
                    ObjFactura.FACT_RECEPTOR_CORREO = Convert.ToString(Cmd.Parameters["p_receptor_correo"].Value);
                    ObjFactura.FACT_RECEPTOR_METODO_PAGO = Convert.ToString(Cmd.Parameters["p_receptor_metodo_pago"].Value);
                    ObjFactura.FACT_RECEPTOR_CP = Convert.ToString(Cmd.Parameters["p_receptor_cp"].Value);
                    ObjFactura.FACT_RECEPTOR_STATUS= Convert.ToString(Cmd.Parameters["p_receptor_status"].Value);
                    ObjFactura.FACT_RECEPTOR_STATUS_NOTAS = Convert.ToString(Cmd.Parameters["p_receptor_status_notas"].Value);
                    ObjFactura.CFDI = Convert.ToString(Cmd.Parameters["P_CFDI"].Value);
                    ObjFactura.FACT_TIPO_SERVICIO = Convert.ToString(Cmd.Parameters["P_RECEPTOR_TIPO_SERVICIO"].Value);
                    ObjFactura.FACT_OBSERVACIONES = Convert.ToString(Cmd.Parameters["P_RECEPTOR_OBSERVACIONES"].Value);
                    ObjFactura.FACT_CONFIRMADO = Convert.ToString(Cmd.Parameters["P_CONFIRMADO"].Value);
                    ObjFactura.FACT_RECEPTOR_FORMA_PAGO = Convert.ToString(Cmd.Parameters["P_RECEPTOR_FORMA_PAGO"].Value);


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
        public void FacturaEfectConsultaDatosFiscales(ref Factura ObjFactura, ref string Verificador)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand Cmd = null;
            try
            {

                String[] Parametros = { "p_id_factura" };
                Object[] Valores = { Convert.ToInt32(ObjFactura.ID_FACT) };
                String[] ParametrosOut = { "p_receptor_nombre", "p_receptor_rfc", "p_receptor_domicilio", "p_receptor_colonia", "p_receptor_estado",
                    "p_receptor_municipio","p_receptor_tipo_persona","p_receptor_telefono","p_receptor_correo",
                    "p_receptor_metodo_pago","p_receptor_cp","p_receptor_status","p_subtotal","p_total","p_iva",
                    "p_folio","p_dependencia","p_receptor_status_notas","p_ruta_adjunto","p_ruta_adjunto_oficio",
                    "p_fecha","p_oficio","P_RUTA_ADJUNTO_CONVENIO","p_notas","p_importe_convenio",
                    "P_CFDI","P_RECEPTOR_TIPO_SERVICIO","P_RECEPTOR_OBSERVACIONES","P_CONFIRMADO","P_RECEPTOR_FORMA_PAGO",
                    "P_FECHA_OFICIO", "P_STATUS_REF_ANT",
                    "p_Bandera" };
                Cmd = CDDatos.GenerarOracleCommand("SEL_FACT_EFECT_DATOS_FISCALES", ref Verificador, Parametros, Valores, ParametrosOut);
                if (Verificador == "0")
                {
                    ObjFactura.FACT_NOMBRE = Convert.ToString(Cmd.Parameters["p_receptor_nombre"].Value);
                    ObjFactura.FACT_RECEPTOR_TIPO_PERS = Convert.ToString(Cmd.Parameters["p_receptor_tipo_persona"].Value);
                    ObjFactura.FACT_RECEPTOR_RFC = Convert.ToString(Cmd.Parameters["p_receptor_rfc"].Value);
                    ObjFactura.FACT_RECEPTOR_DOMICILIO = Convert.ToString(Cmd.Parameters["p_receptor_domicilio"].Value);
                    ObjFactura.FACT_RECEPTOR_COLONIA = Convert.ToString(Cmd.Parameters["p_receptor_colonia"].Value);
                    ObjFactura.FACT_RECEPTOR_ESTADO = Convert.ToString(Cmd.Parameters["p_receptor_estado"].Value);
                    ObjFactura.FACT_RECEPTOR_MUNICIPIO = Convert.ToString(Cmd.Parameters["p_receptor_municipio"].Value);
                    ObjFactura.FACT_RECEPTOR_TELEFONO = Convert.ToString(Cmd.Parameters["p_receptor_telefono"].Value);
                    ObjFactura.FACT_RECEPTOR_CORREO = Convert.ToString(Cmd.Parameters["p_receptor_correo"].Value);
                    ObjFactura.FACT_RECEPTOR_METODO_PAGO = Convert.ToString(Cmd.Parameters["p_receptor_metodo_pago"].Value);
                    ObjFactura.FACT_RECEPTOR_CP = Convert.ToString(Cmd.Parameters["p_receptor_cp"].Value);
                    ObjFactura.FACT_RECEPTOR_STATUS = Convert.ToString(Cmd.Parameters["p_receptor_status"].Value);
                    ObjFactura.FACT_SUBTOTAL = Convert.ToString(Cmd.Parameters["p_subtotal"].Value);
                    ObjFactura.FACT_TOTAL = Convert.ToString(Cmd.Parameters["p_total"].Value);
                    ObjFactura.FACT_IMPUESTO_TASA = Convert.ToString(Cmd.Parameters["p_iva"].Value);
                    ObjFactura.FACT_FOLIO = Convert.ToString(Cmd.Parameters["p_folio"].Value);
                    ObjFactura.FACT_DEPENDENCIA = Convert.ToString(Cmd.Parameters["p_dependencia"].Value);
                    ObjFactura.FACT_RECEPTOR_STATUS_NOTAS = Convert.ToString(Cmd.Parameters["p_receptor_status_notas"].Value);
                    ObjFactura.RUTA_ADJUNTO = Convert.ToString(Cmd.Parameters["p_ruta_adjunto"].Value);
                    ObjFactura.RUTA_ADJUNTO_OFICIO = Convert.ToString(Cmd.Parameters["p_ruta_adjunto_oficio"].Value);
                    ObjFactura.FACT_FECHA_FACTURA = Convert.ToString(Cmd.Parameters["p_fecha"].Value);
                    ObjFactura.OFICIO= Convert.ToString(Cmd.Parameters["p_oficio"].Value);
                    ObjFactura.RUTA_ADJUNTO_CONVENIO = Convert.ToString(Cmd.Parameters["P_RUTA_ADJUNTO_CONVENIO"].Value);
                    ObjFactura.FACT_NOTAS= Convert.ToString(Cmd.Parameters["p_notas"].Value);
                    ObjFactura.FACT_IMPORTE_CONVENIO = Convert.ToDouble(Cmd.Parameters["p_importe_convenio"].Value);

                    ObjFactura.CFDI = Convert.ToString(Cmd.Parameters["P_CFDI"].Value);
                    ObjFactura.FACT_TIPO_SERVICIO = Convert.ToString(Cmd.Parameters["P_RECEPTOR_TIPO_SERVICIO"].Value);
                    ObjFactura.FACT_OBSERVACIONES = Convert.ToString(Cmd.Parameters["P_RECEPTOR_OBSERVACIONES"].Value);
                    ObjFactura.FACT_CONFIRMADO = Convert.ToString(Cmd.Parameters["P_CONFIRMADO"].Value);
                    ObjFactura.FACT_RECEPTOR_FORMA_PAGO = Convert.ToString(Cmd.Parameters["P_RECEPTOR_FORMA_PAGO"].Value);
                    ObjFactura.FACT_DEPENDENCIA = Convert.ToString(Cmd.Parameters["p_dependencia"].Value);
                    ObjFactura.FECHA_OFICIO = Convert.ToString(Cmd.Parameters["P_FECHA_OFICIO"].Value);
                    ObjFactura.STATUS_REF_ANTICIPADA = Convert.ToString(Cmd.Parameters["P_STATUS_REF_ANT"].Value);

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
        public void FacturaConsultaId(ref Factura ObjFactura, ref string Verificador)
        {
            CD_Datos CDDatos = new CD_Datos("INGRESOS");
            OracleCommand Cmd = null;
            try
            {
                String[] Parametros = { "P_REFERENCIA" };
                object[] Valores = { ObjFactura.FACT_REFERENCIA };
                String[] ParametrosOut = { "P_ID_FACTURA", "P_BANDERA" };

                Cmd = CDDatos.GenerarOracleCommand("OBT_ID_FACTURA_DESCUENTO", ref Verificador, Parametros, Valores, ParametrosOut);
                ObjFactura.ID_FACT = Convert.ToString(Cmd.Parameters["P_ID_FACTURA"].Value);

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
        public void FacturaEditar(Factura ObjFactura, string UsuarioNombre, ref string Verificador)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand cmm = null;
            try
            {

                

                String[] Parametros = { "p_id_factura", "p_nombre", "p_carrera", "p_matricula", "p_observaciones", "p_usuario" };
                Object[] Valores = { ObjFactura.ID_FACT, ObjFactura.FACT_NOMBRE, ObjFactura.FACT_CARRERA, ObjFactura.FACT_MATRICULA, ObjFactura.FACT_OBSERVACIONES, UsuarioNombre };
                String[] ParametrosOut = { "p_bandera" };
                cmm= CDDatos.GenerarOracleCommand("UPD_FACTURA", ref Verificador, Parametros, Valores, ParametrosOut);
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

        public void FacturaEliminar(Factura ObjFactura, ref string Verificador)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand cmm = null;
            try
            {



                String[] Parametros = { "p_id_factura" };
                Object[] Valores = { ObjFactura.ID_FACT };
                String[] ParametrosOut = { "p_bandera" };
                cmm = CDDatos.GenerarOracleCommand("DEL_FACTURA", ref Verificador, Parametros, Valores, ParametrosOut);
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


        public void FacturaEditarDatos(Factura ObjFactura, string UsuarioNombre, ref string Verificador)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand cmm = null;
            try
            {



                String[] Parametros = { "p_id_factura", "p_receptor_nombre", "p_receptor_rfc", "p_receptor_domicilio", 
                                        "p_receptor_colonia", "p_receptor_pais", 
                                        "p_matricula", "p_carrera", "p_dependencia", "p_expedido_domicilio",
                                        "p_expedido_colonia", "p_expedido_pais", "p_notas", "p_subtotal",
                                         "p_impuesto_tasa", "p_total","p_status","p_status_notas", "p_fecha_cfd", "p_fecha_dispersion", "p_usuario"};
                Object[] Valores = {ObjFactura.ID_FACT, ObjFactura.FACT_NOMBRE, ObjFactura.FACT_RECEPTOR_RFC, ObjFactura.FACT_RECEPTOR_DOMICILIO, 
                                     ObjFactura.FACT_RECEPTOR_COLONIA, ObjFactura.FACT_RECEPTOR_LUGAR,
                                     ObjFactura.FACT_MATRICULA, ObjFactura.FACT_CARRERA,ObjFactura.FACT_DEPENDENCIA, ObjFactura.FACT_EXPEDIDO_DOMICILIO,
                                     ObjFactura.FACT_EXPEDIDO_COLONIA,ObjFactura.FACT_EXPEDIDO_PAIS,ObjFactura.FACT_OBSERVACIONES,ObjFactura.FACT_SUBTOTAL,
                                     ObjFactura.FACT_IMPUESTO_TASA,ObjFactura.FACT_TOTAL,ObjFactura.FACT_STATUS,ObjFactura.FACT_STATUS_NOTAS,ObjFactura.FACT_FECHA_CFD,ObjFactura.FACT_FECHA_DISPERSION, UsuarioNombre};
                String[] ParametrosOut = { "p_bandera" };
                cmm = CDDatos.GenerarOracleCommand("UPD_DATOS_FACTURA_2016", ref Verificador, Parametros, Valores, ParametrosOut);
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
        public void FacturasConfirmadas(string id_facturas, string confirmadas, string Tipo, ref string Verificador)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand cmm = null;
            try
            {



                String[] Parametros = { "P_ID_FACTURAS", "P_CONFIRMADO", "P_TIPO" };
                Object[] Valores = { id_facturas, confirmadas, Tipo };
                String[] ParametrosOut = { "p_bandera" };
                cmm = CDDatos.GenerarOracleCommand("UPD_FACTURAS_CONFIRMADAS", ref Verificador, Parametros, Valores, ParametrosOut);
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
        public void FacturaConsultarCancelados(ref Factura ObjFactura, ref List<Factura> List)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand cmm = null;
            try
            {
                OracleDataReader dr = null;

                String[] Parametros = { "p_buscar" };
                String[] Valores = { ObjFactura.FACT_FOLIO };

                cmm = CDDatos.GenerarOracleCommandCursor("pkg_felectronica.Obt_Grid_Cancelados", ref dr, Parametros, Valores);
                while (dr.Read())
                {
                    ObjFactura = new Factura();
                    ObjFactura.ID_FACT = Convert.ToString(dr.GetValue(0));
                    ObjFactura.FACT_MATRICULA = Convert.ToString(dr.GetValue(1));
                    ObjFactura.FACT_NOMBRE = Convert.ToString(dr.GetValue(2));
                    ObjFactura.FACT_REFERENCIA = Convert.ToString(dr.GetValue(3));
                    ObjFactura.FACT_FOLIO = Convert.ToString(dr.GetValue(4));
                    ObjFactura.FACT_FECHA_FACTURA = Convert.ToString(dr.GetValue(5));
                    ObjFactura.Status_Carga = Convert.ToString(dr.GetValue(7));
                    ObjFactura.FACT_BANCO = Convert.ToString(dr.GetValue(8));
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
        public void FacturaEditarEstatus(Factura ObjFactura, string UsuarioNombre, ref string Verificador)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand cmm = null;
            try
            {
                String[] Parametros = { "p_id", "p_status", "p_usuario" };
                Object[] Valores = { ObjFactura.ID_FACT, ObjFactura.Status_Carga, UsuarioNombre };
                String[] ParametrosOut = { "p_bandera" };
                cmm = CDDatos.GenerarOracleCommand("UPD_STATUS", ref Verificador, Parametros, Valores, ParametrosOut);
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
        public void FacturaEditarEstatusRevisado(string Observaciones, string Usuario, ref string Verificador)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand cmm = null;
            try
            {
                String[] Parametros = { "P_OBSERVACIONES", "P_USUARIO" };
                Object[] Valores = { Observaciones, Usuario };
                String[] ParametrosOut = { "P_BANDERA" };
                cmm = CDDatos.GenerarOracleCommand("UPD_STATUS_REVISADO", ref Verificador, Parametros, Valores, ParametrosOut);
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

        public void Obt_Mensaje(ref string Verificador)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand cmm = null;
            try
            {

               
                String[] Pain = { };
                object[] valores = { };
                String[] Parametros = { "p_Bandera" };
                cmm= CDDatos.GenerarOracleCommand("OBT_MENSAJE", ref Verificador, Pain, valores, Parametros);
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


        public void Generar_Recibo_OnLine(Factura ObjFactura, ref string Verificador)
        {
            CD_Datos CDDatos = new CD_Datos("INGRESOS");
            OracleCommand cmm = null;
            try
            {


                String[] Parametros = { "p_id_ficha_bancaria", "p_mp_order" };
                Object[] Valores = { ObjFactura.ID_FICHA_BANCARIA, ObjFactura.multipago.Order };
                String[] ParametrosOut = { "p_Bandera" };
                cmm = CDDatos.GenerarOracleCommand("GNR_RECIBO_ONLINE", ref Verificador, Parametros, Valores, ParametrosOut);
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

        public void Generar_Recibo_Apirante(Factura ObjFactura, ref string Verificador)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand cmm = null;
            try
            {


                String[] Parametros = { "p_id_ficha_bancaria" };
                Object[] Valores = { ObjFactura.ID_FICHA_BANCARIA };
                String[] ParametrosOut = { "p_Bandera" };
                cmm = CDDatos.GenerarOracleCommand("GNR_RECIBO_ASPIRANTES", ref Verificador, Parametros, Valores, ParametrosOut);
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

        public void FacturaEditarDatosCaja(Factura ObjFactura, string UsuarioNombre, ref string Verificador)
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
                Object[] Valores = {ObjFactura.ID_FACT, ObjFactura.FACT_RECEPTOR_RFC, ObjFactura.FACT_NOMBRE, ObjFactura.FACT_RECEPTOR_DOMICILIO,
                                    ObjFactura.FACT_RECEPTOR_COLONIA, ObjFactura.FACT_RECEPTOR_CP, ObjFactura.FACT_RECEPTOR_ESTADO, ObjFactura.FACT_RECEPTOR_MUNICIPIO,
                                    ObjFactura.FACT_RECEPTOR_METODO_PAGO, ObjFactura.FACT_RECEPTOR_TELEFONO, ObjFactura.FACT_RECEPTOR_CORREO, ObjFactura.FACT_RECEPTOR_TIPO_PERS,
                                    ObjFactura.FACT_RECEPTOR_STATUS, ObjFactura.FACT_RECEPTOR_STATUS_NOTAS, ObjFactura.FACT_CONFIRMADO, UsuarioNombre, ObjFactura.CFDI, ObjFactura.FACT_TIPO_SERVICIO, ObjFactura.FACT_OBSERVACIONES,
                                    ObjFactura.FACT_RECEPTOR_FORMA_PAGO
                };
                String[] ParametrosOut = { "p_bandera" };
                cmm = CDDatos.GenerarOracleCommand("UPD_INF_FACTURA_CAJA", ref Verificador, Parametros, Valores, ParametrosOut);
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
        public void FacturaEditarDatosEfect(Factura ObjFactura, string UsuarioNombre, ref string Verificador)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand cmm = null;
            try
            {



                String[] Parametros = { "P_ID_FACTURA", "P_RECEPTOR_RFC", "P_RECEPTOR_NOMBRE", "P_RECEPTOR_DOMICILIO", "P_RECEPTOR_COLONIA",
                                        "P_RECEPTOR_CP", "P_RECEPTOR_ESTADO", "P_RECEPTOR_MUNICIPIO", "P_RECEPTOR_METODO_PAGO", "P_RECEPTOR_TELEFONO",
                                        "P_RECEPTOR_CORREO", "P_USUARIO", "P_RECEPTOR_TIPO_PERS", "P_RECEPTOR_STATUS", "P_RECEPTOR_STATUS_NOTAS", "P_CONFIRMADO",
                                        "P_FOLIO", "P_IMPORTE", "P_IVA", "P_TOTAL", "P_RUTA_ADJUNTO_VOUCHER","P_RUTA_ADJUNTO_OFICIO","P_RUTA_ADJUNTO_CONVENIO","P_OFICIO","P_FECHA", "P_TIPO", "P_NOTAS", "P_IMPORTE_CONVENIO",
                                        "P_CFDI", "P_RECEPTOR_TIPO_SERVICIO", "P_RECEPTOR_OBSERVACIONES", "P_RECEPTOR_FORMA_PAGO", "P_OFICIO_FECHA"
                };
                Object[] Valores = {ObjFactura.ID_FACT, ObjFactura.FACT_RECEPTOR_RFC, ObjFactura.FACT_NOMBRE, ObjFactura.FACT_RECEPTOR_DOMICILIO,
                                    ObjFactura.FACT_RECEPTOR_COLONIA, ObjFactura.FACT_RECEPTOR_CP, ObjFactura.FACT_RECEPTOR_ESTADO, ObjFactura.FACT_RECEPTOR_MUNICIPIO,
                                    ObjFactura.FACT_RECEPTOR_METODO_PAGO, ObjFactura.FACT_RECEPTOR_TELEFONO, ObjFactura.FACT_RECEPTOR_CORREO, UsuarioNombre, ObjFactura.FACT_RECEPTOR_TIPO_PERS,
                                    ObjFactura.FACT_RECEPTOR_STATUS, ObjFactura.FACT_RECEPTOR_STATUS_NOTAS, ObjFactura.FACT_CONFIRMADO,
                                    ObjFactura.FACT_FOLIO, ObjFactura.FACT_SUBTOTAL, ObjFactura.FACT_IMPUESTO_TASA, ObjFactura.FACT_TOTAL, ObjFactura.RUTA_ADJUNTO, ObjFactura.RUTA_ADJUNTO_OFICIO, ObjFactura.RUTA_ADJUNTO_CONVENIO, ObjFactura.OFICIO, ObjFactura.FACT_FECHA_FACTURA, ObjFactura.FACT_TIPO, ObjFactura.FACT_NOTAS, ObjFactura.FACT_IMPORTE_CONVENIO,
                                    ObjFactura.CFDI, ObjFactura.FACT_TIPO_SERVICIO, ObjFactura.FACT_OBSERVACIONES, 
                                    ObjFactura.FACT_RECEPTOR_FORMA_PAGO, ObjFactura.FECHA_OFICIO
                };
                String[] ParametrosOut = { "p_bandera" };
                cmm = CDDatos.GenerarOracleCommand("UPD_DATOS_FACTURA_EFECTIVO", ref Verificador, Parametros, Valores, ParametrosOut);
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
        public void FacturaAgregarDatosCaja(ref Factura ObjFactura, string UsuarioNombre, ref string Verificador)
        //public void FacturaAgregarDatosCaja(ref Factura ObjFactura, string UsuarioNombre, ref string Verificador)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand cmm = null;
            try
            {



                String[] Parametros = { 
                    "P_RECEPTOR_RFC", "P_RECEPTOR_NOMBRE", "P_RECEPTOR_DOMICILIO", "P_RECEPTOR_COLONIA",
                    "P_RECEPTOR_CP", "P_RECEPTOR_ESTADO", "P_RECEPTOR_MUNICIPIO", "P_RECEPTOR_METODO_PAGO", "P_RECEPTOR_TELEFONO",
                    "P_RECEPTOR_CORREO", "P_RECEPTOR_TIPO_PERS",  "P_RECEPTOR_STATUS", "P_USUARIO", "P_FOLIO", "P_IMPORTE", "P_IVA", 
                    "P_TOTAL", "P_DEPENDENCIA", "P_RUTA_ADJUNTO_VOUCHER", "P_RUTA_ADJUNTO_OFICIO",
                    "P_RUTA_ADJUNTO_CONVENIO", "P_OFICIO", "P_FECHA", "P_TIPO", "P_NOTAS", "P_IMPORTE_CONVENIO",
                    "P_CFDI", "P_RECEPTOR_TIPO_SERVICIO", "P_RECEPTOR_OBSERVACIONES", "P_CONFIRMADO","P_FORMA_PAGO"
                };
                Object[] Valores = {ObjFactura.FACT_RECEPTOR_RFC, ObjFactura.FACT_NOMBRE, ObjFactura.FACT_RECEPTOR_DOMICILIO, ObjFactura.FACT_RECEPTOR_COLONIA,
                                    ObjFactura.FACT_RECEPTOR_CP, ObjFactura.FACT_RECEPTOR_ESTADO, ObjFactura.FACT_RECEPTOR_MUNICIPIO,
                                    ObjFactura.FACT_RECEPTOR_METODO_PAGO, ObjFactura.FACT_RECEPTOR_TELEFONO, ObjFactura.FACT_RECEPTOR_CORREO,
                                    ObjFactura.FACT_RECEPTOR_TIPO_PERS, ObjFactura.FACT_RECEPTOR_STATUS, UsuarioNombre,
                                    ObjFactura.FACT_FOLIO, ObjFactura.FACT_SUBTOTAL, ObjFactura.FACT_IMPUESTO_TASA, ObjFactura.FACT_TOTAL, ObjFactura.FACT_DEPENDENCIA, ObjFactura.RUTA_ADJUNTO, ObjFactura.RUTA_ADJUNTO_OFICIO,ObjFactura.RUTA_ADJUNTO_CONVENIO,ObjFactura.OFICIO, ObjFactura.FACT_FECHA_FACTURA, ObjFactura.FACT_TIPO, ObjFactura.FACT_NOTAS, ObjFactura.FACT_IMPORTE_CONVENIO,
                                    ObjFactura.CFDI, ObjFactura.FACT_TIPO_SERVICIO, ObjFactura.FACT_OBSERVACIONES, ObjFactura.FACT_CONFIRMADO,ObjFactura.FACT_RECEPTOR_FORMA_PAGO
                };
                String[] ParametrosOut = { "P_BANDERA", "P_ID_FACT_EFECT" };
                //cmm = CDDatos.GenerarOracleCommand_Adjunto("INS_DATOS_FACTURA_CAJA", ref Verificador, Parametros, Valores, ParametrosOut);
                cmm = CDDatos.GenerarOracleCommand("INS_INF_FACTURA_CAJA", ref Verificador, Parametros, Valores, ParametrosOut);
                ObjFactura.ID_FACT = Convert.ToString(cmm.Parameters["P_ID_FACT_EFECT"].Value);
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
        //public void FacturaReporteExcel(Factura ObjFactura, string fecha_ini, string fecha_fin, string dependencia, string concepto, ref DataTable _tabla)
        //{
        //    CD_Datos CDDatos = new CD_Datos();
        //    OracleCommand cmm = null;
        //    try
        //    {
        //        OracleDataReader dr = null;

        //        String[] Parametros = { "p_fecha_inicio", "p_fecha_final", "p_dependencia", "p_concepto" };
        //        String[] Valores = { fecha_ini, fecha_fin, dependencia, concepto };

        //        cmm = CDDatos.GenerarOracleCommandCursor("pkg_felectronica.Obt_Reporte_Ref_Pagadas", ref dr, Parametros, Valores);
        //        while (dr.Read())
        //        {
        //            ObjFactura = new Factura();
        //            ObjFactura.FACT_MATRICULA = Convert.ToString(dr.GetValue(0));
        //            ObjFactura.FACT_NOMBRE = Convert.ToString(dr.GetValue(1));
        //            ObjFactura.FACT_REFERENCIA = Convert.ToString(dr.GetValue(2));
        //            ObjFactura.FACT_OBSERVACIONES = Convert.ToString(dr.GetValue(3));
        //            ObjFactura.FACT_TOTAL = Convert.ToString(dr.GetValue(4));
        //            ObjFactura.FACT_DEPENDENCIA = Convert.ToString(dr.GetValue(5));
        //            ObjFactura.FACT_CARRERA = Convert.ToString(dr.GetValue(6));
        //            ObjFactura.FACT_BANCO = Convert.ToString(dr.GetValue(7));
        //            ObjFactura.FACT_FECHA_FACTURA = Convert.ToString(dr.GetValue(8));
        //            ObjFactura.FACT_FOLIO = Convert.ToString(dr.GetValue(9));
        //            List.Add(ObjFactura);
        //        }
        //        dr.Close();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message);
        //    }
        //    finally
        //    {
        //        CDDatos.LimpiarOracleCommand(ref cmm);
        //    }
        //}
        public void FacturaReporteExcel(Factura ObjFactura, string fecha_ini, string fecha_fin, string dependencia, string concepto, ref DataTable _tabla)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand cmm = null;
            try
            {
                OracleDataReader dr = null;
                String[] Parametros = { "p_fecha_ini", "p_fecha_fin", "p_dependencia", "p_concepto" };
                String[] Valores = { fecha_ini, fecha_fin, dependencia, concepto };
                cmm = CDDatos.GenerarOracleCommandCursor("PKG_FELECTRONICA.Obt_Reporte_Ref_Pagadas", ref dr, Parametros, Valores);
                OracleDataAdapter adaptador = new OracleDataAdapter();
                adaptador.SelectCommand = cmm;
                adaptador.Fill(_tabla);

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
