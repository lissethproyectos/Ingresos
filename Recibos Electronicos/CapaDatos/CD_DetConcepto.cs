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
    public class CD_DetConcepto
    {
        public void ConsultarDetConcepto(ref DetConcepto ObjDetConcepto, ref List<DetConcepto> List)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand cmm = null;
            try
            {

                OracleDataReader dr = null;
              
                string[] ParametrosIn ={
                                           "p_evento",
                                           "p_concepto",
                                           "p_carrera"
                                           
                                        };
                Object[] Valores ={
                                      ObjDetConcepto.Evento,
                                      ObjDetConcepto.IdConcepto,
                                      Convert.ToInt32(ObjDetConcepto.TipoPersonaStr)
                                    
                    
                };
                cmm = CDDatos.GenerarOracleCommandCursor("pkg_pagos.Obt_Grid_Materias", ref dr, ParametrosIn, Valores);//text

                while (dr.Read())
                {
                    ObjDetConcepto = new DetConcepto();

                    ObjDetConcepto.IdDetConcepto = Convert.ToInt32(dr["id_materia"]);
                    ObjDetConcepto.DescripcionDetalle = Convert.ToString(dr["descripcion"]);
                    ObjDetConcepto.ImporteDetalle = Convert.ToDouble(dr["costo"]);
                   

                    List.Add(ObjDetConcepto);

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
        public void ValidarMateria(ref DetConcepto ObjDetConcepto, ref string Verificador)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand Cmd = null;
            try
            {

             


                string[] ParametrosIn = {
                                            "p_id_ficha_detalle_concepto",
                                            "p_id_materia" 
                                        };
                object[] Valores = {
                                   ObjDetConcepto.IdConcepto,
                                   ObjDetConcepto.IdDetConcepto
                                   };
                string[] ParametrosOut ={                                        
                                          "p_Resultado"
                };

                 Cmd = CDDatos.GenerarOracleCommand("val_materias", ParametrosIn, Valores, ParametrosOut);

                Verificador = Convert.ToString(Cmd.Parameters["p_Resultado"].Value);

              

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
        public void InsertarDetConcepto(ref string Verificador, ref DetConcepto ObjDetConcepto)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand OracleCmd = null;
            try
            {
           

                string[] Parametros = { "p_ID_MATERIA", 
                                        "p_CICLO_ESCOLAR",
                                        "p_SEMESTRE",
                                        "p_GRUPO",
                                        "p_ID_FICHA_DET_CONCEPTO",
                                        "P_Importe",
                                        "p_Evento"
                                      };
                string[] ParametrosOut = { "p_BANDERA" };

                object[] Valores = {
                                       ObjDetConcepto.IdDetConcepto,
                                       ObjDetConcepto.CicloEscolar,
                                       ObjDetConcepto.Semestre,
                                       ObjDetConcepto.Grupo,
                                       ObjDetConcepto.IdConcepto,
                                       ObjDetConcepto.ImporteDetalle,
                                       ObjDetConcepto.Evento
                                       };
                    OracleCmd = CDDatos.GenerarOracleCommand("INS_FICHA_DETALLE_MATERIAS", ref Verificador, Parametros, Valores, ParametrosOut);
                    if (Verificador != "0")
                        throw new Exception(Verificador);
       
              
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
        public void EliminarDetConcepto(ref string Verificador, ref DetConcepto ObjDetConcepto)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand OracleCmd = null;
            try
            {
               

                string[] Parametros = {
                                        "p_id_ficha_detalle_concepto",
                                        "p_id_materia",
                                         "p_tipo_registro"
                                      };
                string[] ParametrosOut = { "p_BANDERA"
                                         };

                object[] Valores = {
                                       ObjDetConcepto.IdConcepto,
                                       ObjDetConcepto.IdDetConcepto,
                                       ObjDetConcepto.TipoRegistro
                                   };


                OracleCmd = CDDatos.GenerarOracleCommand("DEL_FICHA_DETALLE_MATERIA_ARBL", ref Verificador, Parametros, Valores, ParametrosOut);



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
        public void InsertarDetDescuento(List<DetConcepto> ListDetConc, Alumno ObjAlumno, ref string Verificador)
        {
            CD_Datos CDDatos = new CD_Datos("INGRESOS");
            OracleCommand Cmd = null;
            try
            {
                CDDatos.StartTrans();
                for (int i = 0; i < ListDetConc.Count; i++)
                {
                    String[] Parametros = { "p_id_descuento", "p_clave_concepto", "p_tipo", "p_descripcion", "p_importe" };
                    object[] Valores = { ObjAlumno.IdPersona, ListDetConc[i].ClaveDetalle, ListDetConc[i].TipoRegistro, ListDetConc[i].DescripcionDetalle, ListDetConc[i].ImporteDetalle };
                    String[] ParametrosOut = { "p_Bandera" };
                    Cmd = CDDatos.GenerarOracleCommand("INS_DESCUENTOS_DETALLE", ref Verificador, Parametros, Valores, ParametrosOut);
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
        public void EliminarDetDescuento(Alumno ObjAlumno, ref string Verificador)
        {
            CD_Datos CDDatos = new CD_Datos("INGRESOS");
            OracleCommand OracleCmd = null;
            try
            {
                string[] Parametros = { "P_ID_DESCUENTO" };
                string[] ParametrosOut = { "P_BANDERA" };
                object[] Valores = {ObjAlumno.IdPersona};
                OracleCmd = CDDatos.GenerarOracleCommand("DEL_DESCUENTOS_DETALLE", ref Verificador, Parametros, Valores, ParametrosOut);
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
        public void ConsultarDetDescuento(DetConcepto ObjDetConcepto, int IdDescuento, ref List<DetConcepto> List)
        {
            CD_Datos CDDatos = new CD_Datos("INGRESOS");
            OracleCommand cmm = null;
            try
            {

                OracleDataReader dr = null;

                string[] ParametrosIn ={"p_id_descuento"};
                Object[] Valores ={ IdDescuento };
                cmm = CDDatos.GenerarOracleCommandCursor("pkg_pagos.Obt_Grid_Descuentos_Conceptos", ref dr, ParametrosIn, Valores);//text

                while (dr.Read())
                {
                    ObjDetConcepto = new DetConcepto();
                    ObjDetConcepto.ClaveDetalle = Convert.ToString(dr["clave_concepto"]);
                    ObjDetConcepto.DescripcionDetalle = Convert.ToString(dr["descripcion_concepto"]);
                    ObjDetConcepto.ImporteDetalle = Convert.ToDouble(dr["importe"]);
                    ObjDetConcepto.TipoRegistro = Convert.ToString(dr["clasificacion"]);
                    List.Add(ObjDetConcepto);
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
        public void ConsultarCatConceptoDescuento(DetConcepto ObjDetConcepto, string TipoDescuento, ref List<DetConcepto> List)
        {
            CD_Datos CDDatos = new CD_Datos("INGRESOS");
            OracleCommand cmm = null;
            try
            {

                OracleDataReader dr = null;

                string[] ParametrosIn = { "p_nivel", "p_tipo_desc", "p_escuela", "p_carrera" };
                Object[] Valores = { ObjDetConcepto.Nivel, TipoDescuento, ObjDetConcepto.Dependencia, ObjDetConcepto.Carrera };
                cmm = CDDatos.GenerarOracleCommandCursor("PKG_PAGOS_2016.Obt_Conceptos_Descuentos", ref dr, ParametrosIn, Valores);//text
                string Nivel = ObjDetConcepto.Nivel;
                string[] NivelesPosgrado = { "M", "E", "D" };
                var ExisteNivelPos = Array.FindAll(NivelesPosgrado, s => s.Equals(ObjDetConcepto.Nivel));
                string[] ConceptosPosgrado = { "M0205", "E0205", "D0205", "M0203", "E0203", "D0203", "M0201", "E0201", "D0201", "M0301", "E0301", "D0301" };
                //var ExisteConceptosPos=string.Empty;
                while (dr.Read())
                {
                    ObjDetConcepto = new DetConcepto();
                    ObjDetConcepto.ClaveDetalle = Convert.ToString(dr[0]);
                    ObjDetConcepto.DescripcionDetalle = Convert.ToString(dr[1]);
                    ObjDetConcepto.ImporteDetalle = Convert.ToDouble(dr[2]);
                    ObjDetConcepto.Habilita = (Convert.ToDouble(dr[2]) == 0) ? true : false;
                    var ExisteConceptosPos = Array.FindAll(ConceptosPosgrado, s => s.Equals(Convert.ToString(dr[0])));                    
                    if (Nivel == "L" && (Convert.ToDouble(dr[2]) == 0) && (ObjDetConcepto.ClaveDetalle.Substring(2) == "201" || ObjDetConcepto.ClaveDetalle.Substring(2) == "203"))
                    {
                        ObjDetConcepto.VisibleTxtImporte = false;
                        ObjDetConcepto.VisibleLblImporte = true;
                    }
                    else if (ExisteNivelPos.Length > 0 && (Convert.ToDouble(dr[2]) == 0) && ExisteConceptosPos.Length > 0 && TipoDescuento=="DESCUENTO")
                    {
                        ObjDetConcepto.VisibleTxtImporte = false;
                        ObjDetConcepto.VisibleLblImporte = true;
                    }
                    else
                    {
                        ObjDetConcepto.VisibleTxtImporte = true;
                        ObjDetConcepto.VisibleLblImporte = false;
                    }

                    //ObjDetConcepto.VisibleTxtImporte = (Convert.ToDouble(dr[2]) == 0 && Nivel == "L" && (ObjDetConcepto.ClaveDetalle== "L0201" || (ObjDetConcepto.ClaveDetalle == "L0203")) ? false : true);
                    //ObjDetConcepto.VisibleLblImporte = (Convert.ToDouble(dr[2]) == 0 && Nivel == "L" && (ObjDetConcepto.ClaveDetalle == "L0201" || (ObjDetConcepto.ClaveDetalle == "L0203")) ? true : false);
                    List.Add(ObjDetConcepto);
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
