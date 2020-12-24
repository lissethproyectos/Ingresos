  using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OracleClient;
using System.IO;
using CapaEntidad;
#region Hecho por
//Nombre:      Melissa Alejandra Rodríguez González
//Correo:      melissargz@hotmail.com
//Institución: Unach
#endregion
namespace CapaDatos
{
    public class CD_ConceptoPago
    {
        public void ConceptoConsultaGrid(ref ConceptoPago ObjConceptoPago, string Orden, bool Habilitado, string Buscar, ref List<ConceptoPago> List)
        {
            CD_Datos CDDatos = new CD_Datos("INGRESOS");
            OracleCommand cmm = null;
            try
            {

                OracleDataReader dr = null;

                string[] ParametrosIn ={
                                           "p_nivel",
                                           "p_status",
                                           "p_orden",
                                           "p_Busca"
                                        };
                Object[] Valores ={
                                    ObjConceptoPago.Nivel,
                                    ObjConceptoPago.Status,
                                    Orden,
                                    Buscar

                };
                cmm = CDDatos.GenerarOracleCommandCursor("PKG_PAGOS_2016.Obt_Grid_Conceptos", ref dr, ParametrosIn, Valores);

                while (dr.Read())
                {
                    ObjConceptoPago = new ConceptoPago();

                    ObjConceptoPago.ClaveConcepto = Convert.ToString(dr["clave"]);
                    ObjConceptoPago.Descripcion = Convert.ToString(dr["descripcion"]);
                    ObjConceptoPago.Nivel = Convert.ToString(dr["Nivel"]);
                    ObjConceptoPago.Habilita = Habilitado;
                    List.Add(ObjConceptoPago);

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
        public void ConsultarConceptoPago(ref ConceptoPago ObjConceptoPago, string Orden, bool Habilitado, string Tipo, string Busca, ref List<ConceptoPago> List)
        {
            CD_Datos CDDatos = new CD_Datos("INGRESOS");
            OracleCommand cmm = null;
            try
            {

                OracleDataReader dr = null;
              
                string[] ParametrosIn ={
                                           "p_nivel",
                                           "p_status",
                                           "p_orden",
                                           "p_tipo",
                                           "p_Busqueda"
                                        };
                Object[] Valores ={
                                    ObjConceptoPago.Nivel,
                                    ObjConceptoPago.Status,
                                    Orden,
                                    Tipo,
                                    Busca

                };
                cmm = CDDatos.GenerarOracleCommandCursor("pkg_pagos.Obt_Grid_Cat_Conceptos", ref dr, ParametrosIn, Valores);

                while (dr.Read())
                {
                    ObjConceptoPago = new ConceptoPago();

                    ObjConceptoPago.Id = Convert.ToInt32(dr["id"]);
                    ObjConceptoPago.ClaveConcepto = Convert.ToString(dr["clave"]);
                    ObjConceptoPago.Descripcion = Convert.ToString(dr["descripcion"]);
                    ObjConceptoPago.ImporteConcepto = Convert.ToDouble(dr["importe"]);
                    ObjConceptoPago.StatusStr = Convert.ToString(dr["DescStatus"]);
                    ObjConceptoPago.CobroXMateriaStr = Convert.ToString(dr["Cobro_x_Materia"]);
                    ObjConceptoPago.DescNivel= Convert.ToString(dr["DescNivel"]);
                    ObjConceptoPago.Nivel = Convert.ToString(dr["Nivel"]);
                    ObjConceptoPago.Status = Convert.ToChar(dr["Status"]);
                    ObjConceptoPago.Habilita = Habilitado;
                    ObjConceptoPago.Seleccionable= Convert.ToString(dr["seleccionable"]);
                    List.Add(ObjConceptoPago);

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
        public void ConsultarConceptoPago(ref string Verificador, ref ConceptoPago ObjConceptoPago)
        {
            CD_Datos CDDatos = new CD_Datos("INGRESOS");
            OracleCommand cmm = null;
            try
            {

                string[] ParametrosIn ={
                                           "p_id"
                                        };
                Object[] Valores ={
                                    ObjConceptoPago.IdConcepto
                                  };
                string[] ParametrosOut ={
                                           "P_clave",
                                           "p_descripcion",
                                           "p_importe",
                                           "p_bloqueado",
                                           "p_status",
                                           "p_emitir_Via_Web",
                                           "p_cobro_X_Materia",
                                           "p_maximo_materias",
                                           "p_Bandera",
                                           "p_fecha_inicial",
                                           "p_fecha_final",
                                           "p_permite_duplicidad",
                                           "p_aplica_descuento",
                                           "p_seleccionable",
                                           "p_porcentaje",
                                           "p_observaciones"
                                        };
                cmm = CDDatos.GenerarOracleCommand("SEL_CONCEPTOS", ref Verificador, ParametrosIn, Valores, ParametrosOut);

               
                   ObjConceptoPago = new ConceptoPago();
                    if (Verificador == "0")
                    {
                        ObjConceptoPago.ClaveConcepto = cmm.Parameters["P_clave"].Value.ToString();
                        ObjConceptoPago.Descripcion = cmm.Parameters["p_descripcion"].Value.ToString();
                        ObjConceptoPago.ImporteConcepto = Convert.ToDouble(cmm.Parameters["p_importe"].Value);
                        ObjConceptoPago.Status = Convert.ToChar(cmm.Parameters["p_status"].Value);
                        ObjConceptoPago.EmitirWeb = Convert.ToChar(cmm.Parameters["p_emitir_Via_Web"].Value);
                        ObjConceptoPago.CobroXMateria = Convert.ToChar(cmm.Parameters["p_cobro_X_Materia"].Value);
                        ObjConceptoPago.MaxMateria = cmm.Parameters["p_maximo_materias"].Value.ToString();
                        ObjConceptoPago.FechaInicial = cmm.Parameters["p_fecha_inicial"].Value.ToString();
                        ObjConceptoPago.FechaFinal = cmm.Parameters["p_fecha_final"].Value.ToString();
                        ObjConceptoPago.PermiteDuplicidad = Convert.ToChar(cmm.Parameters["p_permite_duplicidad"].Value);
                        ObjConceptoPago.AplicaDescuento = Convert.ToChar(cmm.Parameters["p_aplica_descuento"].Value);
                        ObjConceptoPago.Bloqueado = Convert.ToChar(cmm.Parameters["p_seleccionable"].Value);
                        ObjConceptoPago.Porcentaje = cmm.Parameters["p_porcentaje"].Value.ToString();
                        ObjConceptoPago.Observaciones = cmm.Parameters["p_observaciones"].Value.ToString();
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
        public void InsertarConceptoPago(ref string Verificador, ConceptoPago objConcepto)
        {
            CD_Datos CDDatos = new CD_Datos("INGRESOS");
            OracleCommand OracleCmd = null;
            try
            {
                string[] Parametros = { "p_accion",
                                        "p_id",
                                        "P_clave",
                                        "p_descripcion",
                                        "p_importe",
                                        "p_bloqueado",
                                        "p_status",
                                        "p_emitir_Via_Web",
                                        "p_cobro_X_Materia",
                                        "p_maximo_materias",
                                        "p_fecha_inicial",
                                        "p_fecha_final",
                                        "p_permite_duplicidad",
                                        "p_aplica_descuento",
                                        "p_seleccionable",
                                        "p_porcentaje",
                                        "p_observaciones"
                                      };
                string[] ParametrosOut = { "p_Bandera",
                                           "p_id_concepto_gen"};


                object[] Valores = {
                                        "I",
                                        0,
                                        objConcepto.ClaveConcepto,
                                        objConcepto.Descripcion,
                                        objConcepto.ImporteConcepto,
                                        objConcepto.Bloqueado,
                                        objConcepto.Status,
                                        objConcepto.EmitirWeb,
                                        objConcepto.CobroXMateria,
                                        objConcepto.MaxMateria,
                                        objConcepto.FechaInicial,
                                        objConcepto.FechaFinal,
                                        objConcepto.PermiteDuplicidad,
                                        objConcepto.AplicaDescuento,
                                        objConcepto.Bloqueado,
                                        objConcepto.Porcentaje,
                                        objConcepto.Observaciones

                                       };
                OracleCmd = CDDatos.GenerarOracleCommand("REG_CONCEPTOS", ref Verificador, Parametros, Valores, ParametrosOut);

                objConcepto.IdConcepto = Convert.ToInt32(OracleCmd.Parameters["p_id_concepto_gen"].Value);
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
        public void ActualizaConceptoPago(ref string Verificador, ref ConceptoPago objConcepto)
        {
            CD_Datos CDDatos = new CD_Datos("INGRESOS");
            OracleCommand OracleCmd = null;
            try
            {


                string[] Parametros = { "p_accion", 
                                        "p_id",
                                        "P_clave",
                                         "p_descripcion",
                                        "p_importe",
                                        "p_bloqueado",
                                        "p_status",
                                        "p_emitir_Via_Web",
                                        "p_cobro_X_Materia",
                                        "p_maximo_materias",
                                        "p_fecha_inicial",
                                        "p_fecha_final",
                                        "p_permite_duplicidad",
                                        "p_aplica_descuento",
                                        "p_seleccionable",
                                        "p_porcentaje",
                                        "p_observaciones",
                                        "p_usuario_modificacion"
                                      };
                string[] ParametrosOut = { "p_Bandera",
                                           "p_id_concepto_gen"};


                object[] Valores = {
                                        "U",
                                        objConcepto.IdConcepto,
                                        objConcepto.ClaveConcepto,
                                        objConcepto.Descripcion,
                                        objConcepto.ImporteConcepto,
                                        objConcepto.Bloqueado,
                                        objConcepto.Status,
                                        objConcepto.EmitirWeb,
                                        objConcepto.CobroXMateria,
                                        Convert.ToInt32(objConcepto.MaxMateria),
                                        objConcepto.FechaInicial,
                                        objConcepto.FechaFinal,
                                        objConcepto.PermiteDuplicidad,
                                        objConcepto.AplicaDescuento,
                                        objConcepto.Bloqueado,
                                        objConcepto.Porcentaje,
                                        objConcepto.Observaciones,
                                        objConcepto.Usu_Nombre
                                       };
                OracleCmd = CDDatos.GenerarOracleCommand("REG_CONCEPTOS", ref Verificador, Parametros, Valores, ParametrosOut);

             //   objConcepto.IdConcepto = Convert.ToInt32(OracleCmd.Parameters["p_id_concepto_gen"].Value);


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
        public void ClonarConcepto(ConceptoPago objConcepto, string Usuario, ref string Verificador)
        {
            CD_Datos CDDatos = new CD_Datos("INGRESOS");
            OracleCommand OracleCmd = null;
            try
            {
                string[] Parametros = { "P_ID_CONCEPTO",
                                        "P_CONCEPTO",
                                        "P_TIPO",
                                        "P_USUARIO"
                                      };
                string[] ParametrosOut = { "P_BANDERA" };


                object[] Valores = {objConcepto.Id,
                                    objConcepto.ClaveConcepto,
                                    objConcepto.Seleccionable,
                                    Usuario};
                OracleCmd = CDDatos.GenerarOracleCommand("CLON_CONCEPTO", ref Verificador, Parametros, Valores, ParametrosOut);
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

        public void ConfigurarConceptoPago(ref ConceptoPago ObjConceptoPago, ref string Verificador)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand Cmd = null;
            try
            {
                OracleDataReader dr = null;
                
                string[] ParametrosIn = { 
                                          "p_id_concepto", 
                                          "p_id_escuela", 
                                          "p_id_carrera", 
                                          "p_imp_patrocinador",
                                          "p_evento"
                                        };
                object[] Valores = { 
                                     ObjConceptoPago.IdConcepto,
                                     ObjConceptoPago.Dependencia,
                                     ObjConceptoPago.TipoPersonaStr,
                                     ObjConceptoPago.Donativo,
                                     ObjConceptoPago.Evento
                                    };


               Cmd = CDDatos.GenerarOracleCommandCursor("pkg_pagos.Obt_Importe_Concepto", ref dr, ParametrosIn, Valores);
                Verificador = "1";
                while (dr.Read())
                {
                    ObjConceptoPago.IdConcepto = Convert.ToInt32(dr["id"]);
                    ObjConceptoPago.Descripcion = Convert.ToString(dr["concepto"]);
                    ObjConceptoPago.ClaveConcepto = Convert.ToString(dr["clave"]);
                    ObjConceptoPago.ImporteConcepto = Convert.ToDouble(dr["importe"]);
                    ObjConceptoPago.CobroXMateria = Convert.ToChar(dr["cobro_x_materia"]);
                    ObjConceptoPago.MaxMateria = Convert.ToString(dr["maximo_materias"]);
                    ObjConceptoPago.DiasVigencia = Convert.ToInt32(dr["dias_vigencia"]);
                    ObjConceptoPago.CicloEscolar = Convert.ToInt32(dr["ciclo_escolar_actual"]);
                    ObjConceptoPago.Anexo = Convert.ToString(dr["observaciones"]);
                    ObjConceptoPago.FechaVigencia = Convert.ToString(dr["Fecha_Vigencia"]);
                    Verificador = "0";  
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
        public void ValidarConcepto(ref ConceptoPago ObjConceptoPago, ref string Verificador, ref string Mensaje)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand Cmd = null;
            try
            {

                

                string[] ParametrosIn = {
                                            "p_id_ficha_bancaria",
                                            "p_id_concepto"
                                        };
                object[] Valores = {
                                   ObjConceptoPago.IdFichaBancaria,
                                   ObjConceptoPago.IdConcepto
                                   };
                string[] ParametrosOut ={                                        
                                          "p_Resultado",
                                          "p_id_registro",
                                          "p_mensaje"
                };

                 Cmd = CDDatos.GenerarOracleCommand("VAL_CONFLICTOS_ARBOL", ParametrosIn, Valores, ParametrosOut);

                Verificador = Convert.ToString(Cmd.Parameters["p_Resultado"].Value);
                ObjConceptoPago.Id = Convert.ToInt32(Cmd.Parameters["p_id_registro"].Value);
                Mensaje = Convert.ToString(Cmd.Parameters["p_mensaje"].Value);

               

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
        public void EliminarConceptoPago(ref string Verificador, ref ConceptoPago ObjConcepto)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand OracleCmd = null;
            try
            {
                

                string[] Parametros = {
                                        "p_id_ficha_detalle_concepto"
                                      };
                string[] ParametrosOut = { "p_BANDERA" };

                object[] Valores = {
                                       ObjConcepto.Id
                                   };


                OracleCmd = CDDatos.GenerarOracleCommand("DEL_FICHA_DETALLE_CONCEPTO_CAS", ref Verificador, Parametros, Valores, ParametrosOut);

           }
            catch (Exception ex)
            {
             
               
                throw new Exception(ex.Message);
            }
            finally {
                CDDatos.LimpiarOracleCommand(ref OracleCmd);
            }

        }
        public void ConsultarVigenciasSIAE(ConceptoPago ObjVigencias, ref List<ConceptoPago> List)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand cmm = null;
            try
            {

                OracleDataReader dr = null;

                string[] ParametrosIn ={ "P_NIVEL" };
                Object[] Valores ={
                                    ObjVigencias.Nivel

                };

                if (ObjVigencias.Tipo == "SYSWEB")
                {
                    cmm = CDDatos.GenerarOracleCommandCursor("PKG_FELECTRONICA_2016.Obt_Grid_Vigencias_SYSWEB", ref dr);
                    while (dr.Read())
                    {
                        ObjVigencias = new ConceptoPago();
                        ObjVigencias.CicloEscolar = Convert.ToInt32(dr[0]);
                        ObjVigencias.DiasVigencia = Convert.ToInt32(dr[1]);
                        List.Add(ObjVigencias);

                    }
                }
                else if (ObjVigencias.Tipo == "SIAE_ACT")
                {
                    cmm = CDDatos.GenerarOracleCommandCursor("PKG_FELECTRONICA_2016.Obt_Grid_Vigencias", ref dr, ParametrosIn, Valores);
                    while (dr.Read())
                    {
                        ObjVigencias = new ConceptoPago();
                        ObjVigencias.Descripcion = Convert.ToString(dr[0]);
                        ObjVigencias.FechaInicial = Convert.ToString(dr[1]);
                        ObjVigencias.FechaFinal = Convert.ToString(dr[2]);
                        ObjVigencias.Periodo = Convert.ToChar(dr[3]);
                        ObjVigencias.Nivel = Convert.ToString(dr[4]);
                        ObjVigencias.ClaveConcepto = Convert.ToString(dr[5]);
                        List.Add(ObjVigencias);
                    }
                }
                else
                {
                    cmm = CDDatos.GenerarOracleCommandCursor("PKG_FELECTRONICA_2016.Obt_Grid_Vigencias_Ciclo", ref dr, ParametrosIn, Valores);
                    while (dr.Read())
                    {
                        ObjVigencias = new ConceptoPago();
                        ObjVigencias.Descripcion = Convert.ToString(dr[0]);
                        ObjVigencias.FechaInicial = Convert.ToString(dr[1]);
                        ObjVigencias.FechaFinal = Convert.ToString(dr[2]);
                        ObjVigencias.Periodo = Convert.ToChar(dr[3]);
                        ObjVigencias.Nivel = Convert.ToString(dr[4]);
                        ObjVigencias.ClaveConcepto = Convert.ToString(dr[5]);
                        List.Add(ObjVigencias);
                    }
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
        public void ConsultarVigenciasActSIAE(ConceptoPago ObjVigencias, ref List<ConceptoPago> List)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand cmm = null;
            try
            {

                OracleDataReader dr = null;               
                cmm = CDDatos.GenerarOracleCommandCursor("PKG_FELECTRONICA_2016.Obt_Grid_Fechas_Vigentes", ref dr);

                while (dr.Read())
                {
                    ObjVigencias = new ConceptoPago();
                    ObjVigencias.Descripcion = Convert.ToString(dr[0]);
                    ObjVigencias.FechaInicial = Convert.ToString(dr[1]);
                    ObjVigencias.FechaFinal = Convert.ToString(dr[2]);
                    ObjVigencias.Periodo = Convert.ToChar(dr[3]);
                    ObjVigencias.Nivel = Convert.ToString(dr[4]);
                    ObjVigencias.ClaveConcepto = Convert.ToString(dr[5]);
                    List.Add(ObjVigencias);

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

        public void ConsultarExcpcionesVigenciasSIAE(ConceptoPago ObjVigencias, ref List<ConceptoPago> List)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand cmm = null;
            try
            {

                OracleDataReader dr = null;

                string[] ParametrosIn ={
                                           "P_ESCUELA"
                                        };
                Object[] Valores ={
                                    ObjVigencias.Dependencia

                };
                cmm = CDDatos.GenerarOracleCommandCursor("PKG_FELECTRONICA_2016.Obt_Grid_ExpVigencias", ref dr, ParametrosIn, Valores);

                while (dr.Read())
                {
                    ObjVigencias = new ConceptoPago();
                    ObjVigencias.Descripcion = Convert.ToString(dr[0]);
                    ObjVigencias.FechaInicial = Convert.ToString(dr[1]);
                    ObjVigencias.FechaFinal = Convert.ToString(dr[2]);
                    ObjVigencias.Dependencia = Convert.ToString(dr[4]);
                    ObjVigencias.Carrera = Convert.ToString(dr[5]);
                    ObjVigencias.ClaveConcepto = Convert.ToString(dr[3]);
                    List.Add(ObjVigencias);

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

        public void ActualizarVigenciasSIAE(ConceptoPago ObjVigencias, string TipoCarrera, ref string Verificador)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand OracleCmd = null;
            try
            {


                string[] Parametros = {"P_TIPO", "P_CONCEPTO", "P_FECHA_INICIAL", "P_FECHA_FINAL", "P_EXTEMPORANEO", "P_TIPO_CARRERA"};
                string[] ParametrosOut = { "p_BANDERA" };

                object[] Valores = { ObjVigencias.Nivel, ObjVigencias.ClaveConcepto, ObjVigencias.FechaInicial, ObjVigencias.FechaFinal, ObjVigencias.Periodo, TipoCarrera };


                OracleCmd = CDDatos.GenerarOracleCommand("UPD_SCE_VIGENCIAS", ref Verificador, Parametros, Valores, ParametrosOut);

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
        public void ActualizarVigenciasSYSWEB(ConceptoPago ObjVigencias, ref string Verificador)
        {
            CD_Datos CDDatos = new CD_Datos("INGRESOS");
            OracleCommand OracleCmd = null;
            try
            {


                string[] Parametros = { "P_CICLO", "P_DIAS_VIGENCIA" };
                string[] ParametrosOut = { "p_BANDERA" };

                object[] Valores = { ObjVigencias.CicloEscolar, ObjVigencias.DiasVigencia };


                OracleCmd = CDDatos.GenerarOracleCommand("UPD_VIGENCIAS_SYSWEB", ref Verificador, Parametros, Valores, ParametrosOut);

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

        public void ActualizarVigenciasSIAECiclo(ConceptoPago ObjVigencias, string TipoCarrera, ref string Verificador)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand OracleCmd = null;
            try
            {


                string[] Parametros = { "P_TIPO", "P_CONCEPTO", "P_FECHA_INICIAL", "P_FECHA_FINAL", "P_EXTEMPORANEO", "P_TIPO_CARRERA" };
                string[] ParametrosOut = { "p_BANDERA" };

                object[] Valores = { ObjVigencias.Nivel, ObjVigencias.ClaveConcepto, ObjVigencias.FechaInicial, ObjVigencias.FechaFinal, ObjVigencias.Periodo, TipoCarrera };


                OracleCmd = CDDatos.GenerarOracleCommand("UPD_SCE_VIGENCIAS_CICLO", ref Verificador, Parametros, Valores, ParametrosOut);

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

        public void InsertarExcepcionesVigenciasSIAE(ConceptoPago ObjVigencias, ref string Verificador)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand OracleCmd = null;
            try
            {


                string[] Parametros = { "P_CONCEPTO", "P_FECHA_INICIO", "P_FECHA_FIN", "P_DESCRIPCION", "P_ESCUELA", "P_ID_CARRERA" };
                string[] ParametrosOut = { "p_BANDERA" };

                object[] Valores = { ObjVigencias.ClaveConcepto, ObjVigencias.FechaInicial, ObjVigencias.FechaFinal, ObjVigencias.Descripcion, ObjVigencias.Dependencia, ObjVigencias.Carrera };


                OracleCmd = CDDatos.GenerarOracleCommand("INS_SCE_EXCEPCIONES_VIGENCIAS", ref Verificador, Parametros, Valores, ParametrosOut);

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

        public void ConsultarCuotasSIAE(DetConcepto ObjCuotas, string Tipo, string SubTipo, ref List<DetConcepto> List)
        {
            CD_Datos CDDatos = new CD_Datos("INGRESOS");
            OracleCommand cmm = null;
            try
            {

                OracleDataReader dr = null;

                
                if (Tipo == "LNG")
                {
                    string[] ParametrosIn = { "p_dependencia", "p_tipo" };
                    Object[] Valores = { ObjCuotas.Dependencia, SubTipo };
                    cmm = CDDatos.GenerarOracleCommandCursor("PKG_PAGOS_2016.Obt_Grid_Cuotas_SIAE_Lenguas", ref dr, ParametrosIn, Valores);
                }
                else
                {
                    string[] ParametrosIn = { "p_dependencia", "p_tipo" };
                    Object[] Valores = { ObjCuotas.Dependencia, ObjCuotas.TipoRegistro };
                    cmm = CDDatos.GenerarOracleCommandCursor("PKG_PAGOS_2016.Obt_Grid_Cuotas_SIAE", ref dr, ParametrosIn, Valores);
                }

                while (dr.Read())
                {
                    ObjCuotas = new DetConcepto();
                    ObjCuotas.Dependencia = Convert.ToString(dr[0]);                    
                    ObjCuotas.CicloEscolar = Convert.ToInt32(dr[1]);
                    ObjCuotas.ImporteConcepto = Convert.ToDouble(dr[2]);                    
                    ObjCuotas.ImporteDetalle = Convert.ToDouble(dr[3]);
                    ObjCuotas.Porcentaje = Convert.ToString(dr[4]);
                    ObjCuotas.TipoRegistro = Convert.ToString(dr[7]);
                    ObjCuotas.Descripcion = Convert.ToString(dr[8]);
                    ObjCuotas.Anexo = Convert.ToString(dr[9]);
                    List.Add(ObjCuotas);

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
        public void InsertarCuotasSIAE(ref string Verificador, DetConcepto objCuotas)
        {
            CD_Datos CDDatos = new CD_Datos("INGRESOS");
            OracleCommand OracleCmd = null;
            try
            {
                string[] Parametros = { "p_dependencia",
                                        "p_semestre",
                                        "p_importe",
                                        "p_extemporaneo",
                                        "p_descuento",                                        
                                      };
                string[] ParametrosOut = { "p_Bandera" };


                object[] Valores = {objCuotas.Dependencia,
                                    objCuotas.Semestre,
                                    objCuotas.ImporteConcepto,
                                    objCuotas.ImporteDetalle,
                                    objCuotas.Porcentaje
                                   };
                OracleCmd = CDDatos.GenerarOracleCommand("INS_CUOTAS_SIAE", ref Verificador, Parametros, Valores, ParametrosOut);

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
        public void InsertarCuotasLenguasSIAE(ref string Verificador, string Tipo, DetConcepto objCuotas)
        {
            CD_Datos CDDatos = new CD_Datos("INGRESOS");
            OracleCommand OracleCmd = null;
            try
            {
                string[] Parametros = { "p_dependencia",
                                        "p_semestre",
                                        "p_importe",
                                        "p_extemporaneo",
                                        "p_descuento",
                                        "p_tipo"
                                      };
                string[] ParametrosOut = { "p_Bandera" };


                object[] Valores = {objCuotas.Dependencia,
                                    objCuotas.Semestre,
                                    objCuotas.ImporteConcepto,
                                    objCuotas.ImporteDetalle,
                                    objCuotas.Porcentaje,
                                    Tipo
                                   };
                OracleCmd = CDDatos.GenerarOracleCommand("INS_CUOTAS_LENGUAS_SIAE", ref Verificador, Parametros, Valores, ParametrosOut);

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
        public void ActualizarCuotasLenguasSIAE(ref string Verificador, string Tipo, DetConcepto objCuotas)
        {
            CD_Datos CDDatos = new CD_Datos("INGRESOS");
            OracleCommand OracleCmd = null;
            try
            {
                string[] Parametros = { "p_dependencia",
                                        "p_semestre",
                                        "p_importe",
                                        "p_extemporaneo",
                                        "p_descuento",
                                        "p_tipo"
                                      };
                string[] ParametrosOut = { "p_Bandera" };


                object[] Valores = {objCuotas.Dependencia,
                                    objCuotas.Semestre,
                                    objCuotas.ImporteConcepto,
                                    objCuotas.ImporteDetalle,
                                    objCuotas.Porcentaje,
                                    Tipo
                                   };
                OracleCmd = CDDatos.GenerarOracleCommand("UPD_CUOTAS_LENGUAS_SIAE", ref Verificador, Parametros, Valores, ParametrosOut);

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

        public void ObtenerCuotasSIAE(ref string Verificador, DetConcepto objCuotas)
        {
            CD_Datos CDDatos = new CD_Datos("INGRESOS");
            OracleCommand OracleCmd = null;
            try
            {
                string[] Parametros = { "p_dependencia",
                                        "p_semestre",
                                        "p_tipo"
                                      };
                string[] ParametrosOut = { "P_IMPORTE", "P_EXTEMPORANEO", "P_DESCUENTO", "P_BANDERA" };


                object[] Valores = {objCuotas.Dependencia,
                                    objCuotas.Semestre,
                                    objCuotas.TipoRegistro
                                   };
                OracleCmd = CDDatos.GenerarOracleCommand("OBT_CUOTAS_SIAE", ref Verificador, Parametros, Valores, ParametrosOut);
                objCuotas.ImporteConcepto = Convert.ToDouble(OracleCmd.Parameters["P_IMPORTE"].Value);
                objCuotas.ImporteDetalle = Convert.ToDouble(OracleCmd.Parameters["P_EXTEMPORANEO"].Value);
                objCuotas.Porcentaje = Convert.ToString(OracleCmd.Parameters["P_DESCUENTO"].Value);

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
        public void ActualizarCuotasSIAE(DetConcepto objCuotas, ref string Verificador)
        {
            CD_Datos CDDatos = new CD_Datos("INGRESOS");
            OracleCommand OracleCmd = null;
            try
            {


                string[] Parametros = { "P_DEPENDENCIA", "P_SEMESTRE", "P_IMPORTE", "P_EXTEMPORANEO", "P_DESCUENTO" };
                string[] ParametrosOut = { "p_BANDERA" };

                object[] Valores = { objCuotas.Dependencia, objCuotas.Semestre, objCuotas.ImporteConcepto, objCuotas.ImporteDetalle, objCuotas.Porcentaje };


                OracleCmd = CDDatos.GenerarOracleCommand("UPD_CUOTAS_SIAE", ref Verificador, Parametros, Valores, ParametrosOut);

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
        public void EliminarCuotasSIAE(ref string Verificador, DetConcepto objCuotas)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand OracleCmd = null;
            try
            {


                string[] Parametros = {
                                        "P_DEPENDENCIA", "P_SEMESTRE"
                                      };
                string[] ParametrosOut = { "p_BANDERA" };

                object[] Valores = {
                                       objCuotas.Dependencia, objCuotas.Semestre
                                   };


                OracleCmd = CDDatos.GenerarOracleCommand("DEL_CUOTAS_SIAE ", ref Verificador, Parametros, Valores, ParametrosOut);

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
}
