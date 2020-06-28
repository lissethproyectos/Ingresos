using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data.OracleClient;
using System.Linq;
using System.Text;

namespace CapaDatos
{
    public class CD_Bien
    {
        public void ConsultarGrid(string Tipo_Bien, Bien Parametro, string Buscar, string Grupo, ref List<Bien> List)
        {
            Bien ObjBien;
            CD_Datos CDDatos = new CD_Datos("INGRESOS");
            OracleCommand cmm = null;
            try
            {
                OracleDataReader dr = null;

                String[] Parametros = { "p_tipo_venta", "p_cta_mayor", "p_dependencia", "p_Busqueda", "p_Grupo" };
                String[] Valores = { Tipo_Bien, Parametro.Cta_Mayor, Parametro.Dependencia, Buscar, Grupo };

                cmm = CDDatos.GenerarOracleCommandCursor("PKG_PAGOS_2016.Obt_Grid_Inventario", ref dr, Parametros, Valores);
                while (dr.Read())
                {
                    ObjBien = new Bien();
                    ObjBien.Id_Inventario = Convert.ToString(dr.GetValue(0));
                    ObjBien.No_Inventario = Convert.ToString(dr.GetValue(1));
                    ObjBien.Clave = Convert.ToString(dr.GetValue(2));
                    ObjBien.Descripcion = Convert.ToString(dr.GetValue(3))+" "+ Convert.ToString(dr.GetValue(4))+" "+ Convert.ToString(dr.GetValue(5));
                    ObjBien.Poliza = Convert.ToString(dr.GetValue(6));
                    ObjBien.Costo = Convert.ToDouble(dr.GetValue(7));
                    ObjBien.Id_Concepto = Convert.ToInt32(dr.GetValue(8));
                    List.Add(ObjBien);
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
        public void ConsultarGridCatProductosServicios(string Tipo_Bien, ref List<Bien> List)
        {
            Bien ObjBien;
            CD_Datos CDDatos = new CD_Datos("INGRESOS");
            OracleCommand cmm = null;
            try
            {
                OracleDataReader dr = null;

                String[] Parametros = { "P_TIPO" };
                String[] Valores = { Tipo_Bien };

                cmm = CDDatos.GenerarOracleCommandCursor("PKG_PAGOS_2016.Obt_Grid_Productos", ref dr, Parametros, Valores);
                while (dr.Read())
                {
                    ObjBien = new Bien();
                    ObjBien.Id_Inventario = Convert.ToString(dr.GetValue(0));
                    ObjBien.Descripcion = Convert.ToString(dr.GetValue(1));
                    ObjBien.Tipo = Convert.ToString(dr.GetValue(2));
                    List.Add(ObjBien);
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
        public void ConsultarGridServicios(string Dependencia, string Buscar, ref List<Bien> List)
        {
            Bien ObjBien;
            CD_Datos CDDatos = new CD_Datos("INGRESOS");
            OracleCommand cmm = null;
            try
            {
                OracleDataReader dr = null;

                String[] Parametros = { "p_dependencia", "p_Busca" };
                String[] Valores = { Dependencia, Buscar };

                cmm = CDDatos.GenerarOracleCommandCursor("PKG_PAGOS_2016.Obt_Grid_Servicios", ref dr, Parametros, Valores);
                while (dr.Read())
                {
                    ObjBien = new Bien();
                    ObjBien.Id_Inventario = Convert.ToString(dr.GetValue(0));
                    ObjBien.Dependencia = Convert.ToString(dr.GetValue(1));
                    ObjBien.Clave = Convert.ToString(dr.GetValue(3));
                    ObjBien.Descripcion= Convert.ToString(dr.GetValue(4));
                    ObjBien.Costo= Convert.ToDouble(dr.GetValue(5));
                    ObjBien.Estatus = Convert.ToString(dr.GetValue(6));
                    ObjBien.TipoGrupo = Convert.ToString(dr.GetValue(2));
                    ObjBien.Concepto = Convert.ToString(dr.GetValue(7));
                    ObjBien.Id_Concepto = Convert.ToInt32(dr.GetValue(8));
                    ObjBien.Grupo = Convert.ToString(dr.GetValue(9));
                    List.Add(ObjBien);
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


        public void ConsultarGridDetalle(Bien objBien, ref List<Bien> List)
        {
            Bien ObjBien;
            CD_Datos CDDatos = new CD_Datos("INGRESOS");
            OracleCommand cmm = null;
            try
            {
                OracleDataReader dr = null;

                String[] Parametros = { "p_pagado", "p_id_ficha_bancaria" };
                String[] Valores = { objBien.Pagado, Convert.ToString(objBien.Id_Ficha_Bancaria), };

                cmm = CDDatos.GenerarOracleCommandCursor("PKG_PAGOS_2016.Obt_Grid_Inventario_Detalle", ref dr, Parametros, Valores);
                while (dr.Read())
                {
                    ObjBien = new Bien();
                    ObjBien.No_Inventario = Convert.ToString(dr.GetValue(0));
                    ObjBien.Descripcion = Convert.ToString(dr.GetValue(1));
                    ObjBien.Cantidad = Convert.ToInt32(dr.GetValue(2));
                    ObjBien.Unidad_Medida = Convert.ToString(dr.GetValue(3));
                    ObjBien.Costo = Convert.ToDouble(dr.GetValue(4));
                    ObjBien.Total = Convert.ToDouble(dr.GetValue(5));
                    List.Add(ObjBien);
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

        public void InsertarDetalleConceptoPago(int Id_Ficha_Bancaria, ref string Verificador, ref List<Bien> List)
        {
            FichaReferenciada ObjFichaReferenciada = new FichaReferenciada();

            foreach (Bien ListRecorre in List)
            {
                CD_Datos CDDatos = new CD_Datos("INGRESOS");
                OracleCommand OracleCmd = null;
                try
                {
                    ObjFichaReferenciada = new FichaReferenciada();
                    GenerarID(ref ObjFichaReferenciada);
                    string[] Parametros = { "p_ID",
                                        "p_ID_FICHA_BANCARIA",
                                        "p_ID_CONCEPTO",
                                        "p_IMPORTE",
                                        "p_ANEXO"
                                      };
                    string[] ParametrosOut = { "p_BANDERA" };

                    object[] Valores = {ObjFichaReferenciada.IdFichaBancaria, //ListRecorre.Id,
                                        Id_Ficha_Bancaria, 
                                        ListRecorre.Id_Concepto,
                                        ListRecorre.Total,
                                        ""
                                       };
                    OracleCmd = CDDatos.GenerarOracleCommand("INS_FICHA_DETALLE_CONCEPTOS", ref Verificador, Parametros, Valores, ParametrosOut);
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
        public void EditarConceptoPago(ConceptoPago ObjConceptoPago,  ref string Verificador)
        {
            
                CD_Datos CDDatos = new CD_Datos("INGRESOS");
                OracleCommand OracleCmd = null;
                try
                {
                    string[] Parametros = { "P_ID_FICHA_BANCARIA",
                                        "P_IMPORTE"
                                      };
                    string[] ParametrosOut = { "p_BANDERA" };

                    object[] Valores = {ObjConceptoPago.IdFichaBancaria,
                                        ObjConceptoPago.ImporteConcepto
                                       };
                    OracleCmd = CDDatos.GenerarOracleCommand("UPD_IMPORTE_FICHA_BANCARIA", ref Verificador, Parametros, Valores, ParametrosOut);
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
        public void InsertarBien(Bien ObjBien, ref string Verificador)
        {

            CD_Datos CDDatos = new CD_Datos("INGRESOS");
            OracleCommand OracleCmd = null;
            try
            {
                string[] Parametros = { "P_TIPO", "P_DESCRIPCION"
                                      };
                string[] ParametrosOut = { "P_BANDERA" };

                object[] Valores = {ObjBien.Tipo, ObjBien.Descripcion
                                       };
                OracleCmd = CDDatos.GenerarOracleCommand("INS_PRODUCTOS", ref Verificador, Parametros, Valores, ParametrosOut);
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
        public void InsertarServicio(Bien ObjServicio, ref string Verificador)
        {

            CD_Datos CDDatos = new CD_Datos("INGRESOS");
            OracleCommand OracleCmd = null;
            try
            {
                string[] Parametros = { "P_DEPENDENCIA", "P_CLAVE", "P_DESCRIPCION", "P_IMPORTE", "P_STATUS", "P_CLAVE_CONCEPTO", "P_RUBRO", "P_ID_CONCEPTO", "P_GRUPO"
                                      };
                string[] ParametrosOut = { "P_BANDERA" };

                object[] Valores = {ObjServicio.Dependencia, ObjServicio.Clave, ObjServicio.Descripcion, ObjServicio.Total, ObjServicio.Estatus, ObjServicio.Concepto, ObjServicio.TipoGrupo, ObjServicio.Id_Concepto, ObjServicio.Grupo
                                       };
                OracleCmd = CDDatos.GenerarOracleCommand("INS_SERVICIOS", ref Verificador, Parametros, Valores, ParametrosOut);
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

        public void EliminarBien(Bien ObjBien, ref string Verificador)
        {

            CD_Datos CDDatos = new CD_Datos("INGRESOS");
            OracleCommand OracleCmd = null;
            try
            {
                string[] Parametros = { "P_ID_BASICOS"
                                      };
                string[] ParametrosOut = { "P_BANDERA" };

                object[] Valores = {ObjBien.Id_Inventario
                                       };
                OracleCmd = CDDatos.GenerarOracleCommand("DEL_PRODUCTO", ref Verificador, Parametros, Valores, ParametrosOut);
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
        public void EditarBien(Bien ObjBien, ref string Verificador)
        {

            CD_Datos CDDatos = new CD_Datos("INGRESOS");
            OracleCommand OracleCmd = null;
            try
            {
                string[] Parametros = { "P_ID", "P_DEPENDENCIA", "P_RUBRO", "P_CLAVE", "P_DESCRIPCION", "P_IMPORTE", "P_CLAVE_CONCEPTO", "P_ID_CONCEPTO", "P_GRUPO"
                                      };
                string[] ParametrosOut = { "P_BANDERA" };

                object[] Valores = { ObjBien.Id_Inventario, ObjBien.Dependencia, ObjBien.TipoGrupo, ObjBien.Clave, ObjBien.Descripcion, ObjBien.Total, ObjBien.Concepto, ObjBien.Id_Concepto, ObjBien.Grupo };
                OracleCmd = CDDatos.GenerarOracleCommand("UPD_SERVICIO", ref Verificador, Parametros, Valores, ParametrosOut);
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

        public void EliminarServicio(Bien ObjBien, ref string Verificador)
        {

            CD_Datos CDDatos = new CD_Datos("INGRESOS");
            OracleCommand OracleCmd = null;
            try
            {
                string[] Parametros = { "P_ID_SERVICIO"
                                      };
                string[] ParametrosOut = { "P_BANDERA" };

                object[] Valores = {ObjBien.Id_Inventario
                                       };
                OracleCmd = CDDatos.GenerarOracleCommand("DEL_SERVICIOS", ref Verificador, Parametros, Valores, ParametrosOut);
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

        public void EditarServicio(Bien ObjBien, ref string Verificador)
        {

            CD_Datos CDDatos = new CD_Datos("INGRESOS");
            OracleCommand OracleCmd = null;
            try
            {
                string[] Parametros = { "P_ID_SERVICIO"
                                      };
                string[] ParametrosOut = { "P_BANDERA" };

                object[] Valores = {ObjBien.Id_Inventario
                                       };
                OracleCmd = CDDatos.GenerarOracleCommand("UPD_SERVICIOS", ref Verificador, Parametros, Valores, ParametrosOut);
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

        public void ConsultarServicio(ref Bien ObjBien, ref string Verificador)
        {
            CD_Datos CDDatos = new CD_Datos("INGRESOS");
            OracleCommand cmm = null;
            try
            {
                string[] ParametrosIn = { "P_ID" };
                object[] Valores = { ObjBien.Id_Inventario };
                string[] ParametrosOut = { "P_DEPENDENCIA", "P_RUBRO", "P_CLAVE", "P_DESCRIPCION", "P_IMPORTE", "P_CLAVE_CONCEPTO", "P_GRUPO", "P_BANDERA" };
                cmm = CDDatos.GenerarOracleCommand("SEL_SERVICIO", ref Verificador, ParametrosIn, Valores, ParametrosOut);
                if (Verificador == "0")
                {
                    ObjBien = new Bien();
                    ObjBien.Dependencia = Convert.ToString(cmm.Parameters["P_DEPENDENCIA"].Value);
                    ObjBien.TipoGrupo = Convert.ToString(cmm.Parameters["P_RUBRO"].Value);
                    ObjBien.Clave = Convert.ToString(cmm.Parameters["P_CLAVE"].Value);
                    ObjBien.Descripcion = Convert.ToString(cmm.Parameters["P_DESCRIPCION"].Value);
                    ObjBien.Costo = Convert.ToDouble(cmm.Parameters["P_IMPORTE"].Value);
                    ObjBien.Concepto = Convert.ToString(cmm.Parameters["P_CLAVE_CONCEPTO"].Value);
                    ObjBien.Grupo = Convert.ToString(cmm.Parameters["P_GRUPO"].Value);
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



        public void InsertarDetallePago_Ventas(int Id_Ficha_Bancaria, ref string Verificador, List<Bien> List)
        {
            foreach (Bien ListRecorre in List)
            {

                CD_Datos CDDatos = new CD_Datos("INGRESOS");
                OracleCommand OracleCmd = null;
                try
                {


                    string[] Parametros = { "P_ID_FICHA_BANCARIA",
                                        "P_TIPO",
                                        "P_ID_INVENTARIO",
                                        "P_UNIDAD_MEDIDA",
                                        "P_CANTIDAD",
                                        "P_PRODUCTO",
                                        "P_COSTO",
                                        "P_IMPORTE_TOTAL"
                                      };

                    string[] ParametrosOut = { "p_BANDERA" };

                    object[] Valores = {
                                        Id_Ficha_Bancaria,
                                        ListRecorre.Tipo,
                                        ListRecorre.Id_Inventario,
                                        ListRecorre.Unidad_Medida,
                                        ListRecorre.Cantidad,
                                        ListRecorre.Producto,
                                        ListRecorre.Costo,
                                        ListRecorre.Total
                                       };
                    OracleCmd = CDDatos.GenerarOracleCommand("INS_FICHA_BANCARIA_VENTAS", ref Verificador, Parametros, Valores, ParametrosOut);
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
        public void EliminarDetallePago_Ventas(int Ficha_Bancaria, ref string Verificador)
        {

            CD_Datos CDDatos = new CD_Datos("INGRESOS");
            OracleCommand OracleCmd = null;
            try
            {
                string[] Parametros = { "P_ID_FICHA_BANCARIA"
                                      };
                string[] ParametrosOut = { "p_BANDERA" };

                object[] Valores = {Ficha_Bancaria
                                       };
                OracleCmd = CDDatos.GenerarOracleCommand("DEL_FICHA_BANCARIA_VENTAS", ref Verificador, Parametros, Valores, ParametrosOut);
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

        public void EliminarDetalleConceptoPago(int Id_Ficha_Bancaria, ref string Verificador)
        {

            CD_Datos CDDatos = new CD_Datos("INGRESOS");
            OracleCommand OracleCmd = null;
            try
            {
                string[] Parametros = { "P_ID_FICHA_BANCARIA"
                                      };
                string[] ParametrosOut = { "P_BANDERA" };

                object[] Valores = { Id_Ficha_Bancaria };
                OracleCmd = CDDatos.GenerarOracleCommand("DEL_FICHA_DETALLE_CONCEPTOS", ref Verificador, Parametros, Valores, ParametrosOut);
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

        public void EliminarConceptoPago(int Ficha_Bancaria, ref string Verificador)
        {

            CD_Datos CDDatos = new CD_Datos("INGRESOS");
            OracleCommand OracleCmd = null;
            try
            {
                string[] Parametros = { "P_ID_FICHA_BANCARIA"
                                      };
                string[] ParametrosOut = { "p_BANDERA" };

                object[] Valores = {Ficha_Bancaria
                                       };
                OracleCmd = CDDatos.GenerarOracleCommand("DEL_FICHA_BANCARIA", ref Verificador, Parametros, Valores, ParametrosOut);
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

        public void InsertarFichaReferenciada(ref FichaReferenciada ObjFichaReferenciada, ref string Verificador)
        {
            CD_Datos CDDatos = new CD_Datos("INGRESOS");
            OracleCommand Cmd = null;
            try
            {


                string[] ParametrosIn = { "p_ID",
                                          "p_MATRICULA",
                                          "p_SEMESTRE",
                                          "p_GRUPO",
                                          "p_CARRERA",
                                          "p_ESCUELA",
                                          "p_CICLO_ESCOLAR",
                                          "p_REFERENCIA",
                                          "p_OBSERVACIONES",
                                          "p_ALUMNO",
                                          "p_IMPORTE",
                                          "p_EVENTO",
                                          "p_USUARIO",
                                          "p_USUARIO_REGISTRA"};
                object[] Valores = {
                                        ObjFichaReferenciada.IdFichaBancaria,
                                        ObjFichaReferenciada.NoControl,
                                        ObjFichaReferenciada.Semestre,
                                        ObjFichaReferenciada.Grupo,
                                        ObjFichaReferenciada.Carrera,
                                        ObjFichaReferenciada.Dependencia,
                                        ObjFichaReferenciada.CicloEscolar,
                                        ObjFichaReferenciada.Referencia,
                                        ObjFichaReferenciada.ConceptoRef,
                                        ObjFichaReferenciada.Nombre,
                                        ObjFichaReferenciada.Importetotal,
                                        ObjFichaReferenciada.Evento,
                                        ObjFichaReferenciada.Usuario,
                                        ObjFichaReferenciada.UsuarioRegistra
            };
                string[] ParametrosOut ={
                                          "p_BANDERA",
                                          "p_Dias_Vigencia"
                };

                Cmd = CDDatos.GenerarOracleCommand("INS_FICHA_BANCARIA", ref Verificador, ParametrosIn, Valores, ParametrosOut);

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
        public void GenerarID(ref FichaReferenciada ObjFichaReferenciada)
        {
            CD_Datos CDDatos = new CD_Datos("INGRESOS");
            OracleCommand Cmd = null;
            try
            {


                string[] ParametrosIn = { };
                object[] Valores = { };
                string[] ParametrosOut ={
                                          "p_Id"
                };

                Cmd = CDDatos.GenerarOracleCommand("GNR_ID_FICHA_BANCARIA", ParametrosIn, Valores, ParametrosOut);

                ObjFichaReferenciada.IdFichaBancaria = Convert.ToInt32(Cmd.Parameters["p_Id"].Value);


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
        public void GenerarReferencia(ref FichaReferenciada ObjFichaReferenciada)
        {
            CD_Datos CDDatos = new CD_Datos("INGRESOS");
            OracleCommand Cmd = null;
            try
            {

                string[] ParametrosIn = { "p_matricula", "p_id_ficha" };
                object[] Valores = { ObjFichaReferenciada.NoControl, ObjFichaReferenciada.IdFichaBancaria };
                string[] ParametrosOut = { "p_matricula_ajustada", "p_id_ficha_ajustada" };

                Cmd = CDDatos.GenerarOracleCommand("gnr_matricula_ajustada", ParametrosIn, Valores, ParametrosOut);
                ObjFichaReferenciada.NoControl = Cmd.Parameters["p_matricula_ajustada"].Value.ToString();
                ObjFichaReferenciada.XMLCadena = Convert.ToString(Cmd.Parameters["p_id_ficha_ajustada"].Value);
                CDDatos.LimpiarOracleCommand(ref Cmd);



                //-----------OBTIENE LA DEPENDENCIA SEGUN EL NIVEL, EJ: 41101 A 41102 PARA POSGRADO-----------//

                CDDatos = new CD_Datos("INGRESOS");
                string[] ParametrosIn2 = { "p_depedencia", "p_nivel" };
                object[] Valores2 = { ObjFichaReferenciada.Dependencia, ObjFichaReferenciada.Nivel };
                string[] ParametrosOut2 = { "p_dependencia_ajustada", "p_bandera" };

                Cmd = CDDatos.GenerarOracleCommand("GNR_DEPENDENCIA_AJUSTADA_2016", ParametrosIn2, Valores2, ParametrosOut2);
                ObjFichaReferenciada.Dependencia = Cmd.Parameters["p_dependencia_ajustada"].Value.ToString();

                CDDatos.LimpiarOracleCommand(ref Cmd);

                //-----------OBTIENE LA REFERENCIA-----------//


                CDDatos = new CD_Datos("INGRESOS");
                string[] Parametro = { "p_Ref_Inicial", "p_DIAS_VIGENCIA", "p_Importe" };
                object[] Valor = {ObjFichaReferenciada.Dependencia + ObjFichaReferenciada.NoControl + ObjFichaReferenciada.XMLCadena,
                                  ObjFichaReferenciada.Vigencia,
                                  ObjFichaReferenciada.Importetotal};

                string[] ParametroOut = { "p_Referencia" };
                Cmd = CDDatos.GenerarOracleCommand("GNR_REFERENCIA", Parametro, Valor, ParametroOut);
                ObjFichaReferenciada.Referencia = Cmd.Parameters["p_Referencia"].Value.ToString();
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
