using System;
using System.Collections.Generic;
using System.Text;
using System.Data.OracleClient;
using System.Data;
using CapaEntidad;
using System.Web.UI.WebControls;
using System.IO;
#region Hecho por
//Nombre:      Lisseth Gtz. Gómez
//Correo:      lis_go82@hotmail.com
//Institución: Unach
#endregion

namespace CapaDatos
{
    public class CD_Curso
    {
        public void CursoConsultaGrid(Curso ObjCurso, string Busqueda, ref List<Curso> List)
        {
            CD_Datos CDDatos = new CD_Datos("INGRESOS");
            OracleCommand cmm = null;
            try
            {
                OracleDataReader dr = null;

                String[] Parametros = { "p_dependencia", "p_ciclo_escolar", "p_evento", "p_status", "p_carrera","p_Busqueda"};
                String[] Valores = { ObjCurso.Dependencia, ObjCurso.CicloEscolar, ObjCurso.Evento,Convert.ToString(ObjCurso.Status),ObjCurso.IdCarrera,Busqueda};

                cmm = CDDatos.GenerarOracleCommandCursor("pkg_pagos.Obt_Grid_Cursos_Disponibles", ref dr, Parametros, Valores);
                while (dr.Read())
                {
                    ObjCurso = new Curso();
                    ObjCurso.Dependencia = Convert.ToString(dr.GetValue(1));
                    //ObjCurso.Evento = Convert.ToString(dr.GetValue(10)); //Este obtiene el Id de la Tabla Factura o Factura_Caja
                    ObjCurso.DescCarrera = Convert.ToString(dr.GetValue(2));
                    ObjCurso.DescMateria = Convert.ToString(dr.GetValue(3));
                    ObjCurso.DescConcepto = Convert.ToString(dr.GetValue(4));
                    ObjCurso.Importe = Convert.ToDouble(dr.GetValue(5));
                    ObjCurso.IdCurso = Convert.ToInt32(dr.GetValue(0));
                    ObjCurso.Semestre = Convert.ToInt32(dr.GetValue(6));
                    List.Add(ObjCurso);
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
        public void CursoInsertar(ref Curso ObjCurso, ref string Verificador)
        {
            CD_Datos CDDatos = new CD_Datos("INGRESOS");
            OracleCommand Cmd = null;
            try
            {
                String[] Parametros = { "P_ID_CARRERA", "P_ID_MATERIA", "P_CICLO_ESCOLAR", "P_DEPENDENCIA", "P_SEMESTRE",
                                        "P_DESC_CARRERA", "P_DESC_MATERIA", "P_STATUS", "P_EVENTO","P_IMPORTE",
                                        "P_PLAN", "P_ID_MATERIA_OPT", "P_OFICIO" };
                object[] Valores = { Convert.ToInt32(ObjCurso.IdCarrera), ObjCurso.IdMateria, ObjCurso.CicloEscolar, ObjCurso.Dependencia, ObjCurso.Semestre,
                                   ObjCurso.DescCarrera,ObjCurso.DescMateria,ObjCurso.Status,ObjCurso.Evento,ObjCurso.Importe,
                                   ObjCurso.Plan, ObjCurso.IdMateriaOpt, ObjCurso.Oficio };
                String[] ParametrosOut = { "p_Bandera"};

                Cmd = CDDatos.GenerarOracleCommand("INS_CURSOS_DISPONIBLES", ref Verificador, Parametros, Valores, ParametrosOut);
                
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
        public void CursoEditar(ref Curso ObjCurso, ref string Verificador)
        {
            CD_Datos CDDatos = new CD_Datos("INGRESOS");
            OracleCommand Cmd = null;
            try
            {
                String[] Parametros = { "P_ID_CURSO", "P_ID_CARRERA", "P_ID_MATERIA", "P_CICLO_ESCOLAR", "P_DEPENDENCIA", "P_SEMESTRE",
                                        "P_DESC_CARRERA", "P_DESC_MATERIA", "P_STATUS","P_EVENTO", "P_IMPORTE","P_PLAN", "P_ID_MATERIA_OPT", "P_OFICIO"};
                object[] Valores = { ObjCurso.IdCurso, ObjCurso.IdCarrera,ObjCurso.IdMateria, ObjCurso.CicloEscolar, ObjCurso.Dependencia, ObjCurso.Semestre,
                                   ObjCurso.DescCarrera, ObjCurso.DescMateria, ObjCurso.Status, ObjCurso.Evento, ObjCurso.Importe, ObjCurso.Plan, ObjCurso.IdMateriaOpt, ObjCurso.Oficio};
                String[] ParametrosOut = { "P_BANDERA" };
                Cmd = CDDatos.GenerarOracleCommand("UPD_CURSOS_DISPONIBLES", ref Verificador, Parametros, Valores, ParametrosOut);
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
        public void CursoEliminar(ref Curso ObjCurso, ref string Verificador)
        {
            CD_Datos CDDatos = new CD_Datos("INGRESOS");
            OracleCommand Cmd = null;
            try
            {
                String[] Parametros = { "P_ID_CURSO"};
                object[] Valores = { ObjCurso.IdCurso};
                String[] ParametrosOut = { "P_BANDERA" };
                Cmd = CDDatos.GenerarOracleCommand("DEL_CURSOS_DISPONIBLES", ref Verificador, Parametros, Valores, ParametrosOut);
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
        public void ConsultarCursoSel(ref Curso ObjCurso, ref string Verificador)
        {
            CD_Datos CDDatos = new CD_Datos("INGRESOS");
            OracleCommand Cmd = null;
            try
            {


                string[] ParametrosIn = { 
                                         "ID_CURSO"};
                object[] Valores = {   
                                       ObjCurso.IdCurso
            };
                string[] ParametrosOut ={                                          
                                          "P_ID_CARRERA",
                                          "P_ID_MATERIA",
                                          "P_CICLO_ESCOLAR",
                                          "P_DEPENDENCIA",
                                          "P_SEMESTRE",
                                          "P_DESC_CARRERA",
                                          "P_DESC_MATERIA",
                                          "P_STATUS",
                                          "P_EVENTO",
                                          "P_IMPORTE",
                                          "P_NIVEL",                                       
                                          "P_PLAN",
                                          "P_ID_MATERIA_OPT",
                                          "P_OFICIO",
                                          "P_BANDERA"
                };

                Cmd = CDDatos.GenerarOracleCommand("SEL_CURSOS_DISPONIBLES", ref Verificador, ParametrosIn, Valores, ParametrosOut);
                if (Verificador == "0")
                {
                    ObjCurso = new Curso();
                    ObjCurso.IdCarrera = Convert.ToString(Cmd.Parameters["P_ID_CARRERA"].Value);
                    ObjCurso.IdMateria = Convert.ToInt32(Cmd.Parameters["P_ID_MATERIA"].Value);
                    ObjCurso.CicloEscolar = Convert.ToString(Cmd.Parameters["P_CICLO_ESCOLAR"].Value);
                    ObjCurso.Dependencia = Convert.ToString(Cmd.Parameters["P_DEPENDENCIA"].Value);
                    ObjCurso.Semestre = Convert.ToInt32(Cmd.Parameters["P_SEMESTRE"].Value);
                    ObjCurso.DescCarrera = Convert.ToString(Cmd.Parameters["P_DESC_CARRERA"].Value);
                    ObjCurso.DescMateria = Convert.ToString(Cmd.Parameters["P_DESC_MATERIA"].Value);
                    ObjCurso.Status = Convert.ToString(Cmd.Parameters["P_STATUS"].Value);
                    ObjCurso.Evento = Convert.ToString(Cmd.Parameters["P_EVENTO"].Value);
                    ObjCurso.Importe = Convert.ToDouble(Cmd.Parameters["P_IMPORTE"].Value);
                    ObjCurso.Nivel = Convert.ToString(Cmd.Parameters["P_NIVEL"].Value);
                    ObjCurso.Plan = Convert.ToString(Cmd.Parameters["P_PLAN"].Value);
                    ObjCurso.IdMateriaOpt = Convert.ToInt32(Cmd.Parameters["P_ID_MATERIA_OPT"].Value);
                    ObjCurso.Oficio = Convert.ToString(Cmd.Parameters["P_OFICIO"].Value);
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
