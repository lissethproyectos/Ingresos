using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OracleClient;
using CapaEntidad;
#region Hecho por
//Nombre:      Melissa Alejandra Rodríguez González
//Correo:      melissargz@hotmail.com
//Institución: Unach
#endregion
namespace CapaDatos
{
    public class CD_Registro
    {
        public void ConsultarRegistros(ref List<Registro> List)
        {
            CD_Datos CDDatos = new CD_Datos("INGRESOS");
            OracleCommand cmm = null;
            try
            {

                OracleDataReader dr = null;
                cmm = CDDatos.GenerarOracleCommandCursor("pkg_pagos.Obt_Grid_Sincronizacion", ref dr);

                while (dr.Read())
                {
                    Registro ObjRegistro = new Registro();

                    ObjRegistro.Tipo = Convert.ToString(dr["tipo"]);
                    ObjRegistro.Sauce = Convert.ToString(dr["registros_sauce"]);
                    ObjRegistro.Ingresos = Convert.ToString(dr["registros_ingresos"]);
                    ObjRegistro.PendienteSincronizar = Convert.ToString(dr["para_sincronizar"]);
                    ObjRegistro.UltimaActualizacion = Convert.ToString(dr["ultima_actualizacion"]);
                    ObjRegistro.Status1 = Convert.ToString(dr["status1"]);

                    List.Add(ObjRegistro);

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
        public void ConsultarRegistros1(ref List<Registro> List)
        {
            CD_Datos CDDatos = new CD_Datos("INGRESOS");
            OracleCommand cmm = null;
            try
            {

                OracleDataReader dr = null;
                cmm = CDDatos.GenerarOracleCommandCursor("pkg_pagos.Obt_Grid_vmaterializadas", ref dr);

                while (dr.Read())
                {
                    Registro ObjRegistro = new Registro();

                    ObjRegistro.name = Convert.ToString(dr["MVIEW_NAME"]);
                    ObjRegistro.fecha = Convert.ToString(dr["LAST_REFRESH_DATE"]);
                    ObjRegistro.hora = Convert.ToString(dr["ULTIMA_REFRESCADA"]);
                    ObjRegistro.master_link = Convert.ToString(dr["MASTER_LINK"]);
                    ObjRegistro.Status = Convert.ToString(dr["status"]); 
                    List.Add(ObjRegistro);

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
        public void ConsultarRegistros2(ref List<Registro> List)
        {
            CD_Datos CDDatos = new CD_Datos("INGRESOS");
            OracleCommand cmm = null;
            try
            {

                OracleDataReader dr = null;
                cmm = CDDatos.GenerarOracleCommandCursor("pkg_pagos.Obt_Grid_inhabiles", ref dr);

                while (dr.Read())
                {
                    Registro ObjRegistro = new Registro();

                    ObjRegistro.objeto = Convert.ToString(dr["OBJETO"]);                   
                    List.Add(ObjRegistro);

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
        public void ConsultarRegistroMatricula(ref Registro ObjRegistro, ref List<Registro> List)
        {
            CD_Datos CDDatos = new CD_Datos("INGRESOS");
            OracleCommand cmm = null;
            try
            {

                OracleDataReader dr = null;
                String[] Parametros = { "p_matricula" };
                Object[] Valores = { ObjRegistro.Matricula };
                String[] ParametrosOut = { "p_nombre" };

                cmm = CDDatos.GenerarOracleCommandCursor("pkg_pagos.Obt_Grid_Sincroniza_Matricula", ref dr, Parametros, Valores, ParametrosOut);

                while (dr.Read())
                {
                     ObjRegistro = new Registro();

                     ObjRegistro.BaseDatos = Convert.ToString(dr["Base_Datos"]);
                     ObjRegistro.Clasificacion = Convert.ToString(dr["Clasificacion"]);
                     ObjRegistro.Tipo = Convert.ToString(dr["tipo"]);
                     ObjRegistro.Matricula = Convert.ToString(dr["matricula"]);
                     ObjRegistro.Dependencia = Convert.ToString(dr["dependencia"]);
                     ObjRegistro.Status = Convert.ToString(dr["status"]);
                     ObjRegistro.Fecha = Convert.ToString(dr["fecha"]);
                     ObjRegistro.Referencia = Convert.ToString(dr["referencia"]);
                     ObjRegistro.Banco = Convert.ToString(dr["Banco"]);
                     ObjRegistro.Folio = Convert.ToString(dr["folio_bancario"]);

                    List.Add(ObjRegistro);
                 
                }
                ObjRegistro.Nombre = cmm.Parameters["p_nombre"].Value.ToString();
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
        public void SincronizarRegistros(Registro ObjRegistro, ref string Verificador)
        {
            CD_Datos CDDatos = new CD_Datos("INGRESOS");
            OracleCommand cmm = null;
            try
            {

                String[] Parametros = { "p_tipo"};
                Object[] Valores = { ObjRegistro.Tipo };
                String[] ParametrosOut = { "p_bandera" };


                cmm = CDDatos.GenerarOracleCommand("SCN_INFORMACION", ref Verificador, Parametros, Valores, ParametrosOut);

               
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

        public void refresh_vmaterilaizada(Registro ObjRegistro, ref string Verificador)
        {
            CD_Datos CDDatos = new CD_Datos("INGRESOS");
            OracleCommand cmm = null;
            try
            {

                String[] Parametros = { "p_vista" };
                Object[] Valores = { ObjRegistro.name };
                String[] ParametrosOut = { "p_bandera" };


                cmm = CDDatos.GenerarOracleCommand("GRL_refrescar_vmaterializadas", ref Verificador, Parametros, Valores, ParametrosOut);


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
        public void habilita_vmaterilaizada(Registro ObjRegistro, ref string Verificador)
        {
            CD_Datos CDDatos = new CD_Datos("INGRESOS");
            OracleCommand cmm = null;
            try
            {

                String[] Parametros = {  };
                Object[] Valores = {  };
                String[] ParametrosOut = { "p_bandera" };


                cmm = CDDatos.GenerarOracleCommand("GRL_OBJETOS_INVAL", ref Verificador, Parametros, Valores, ParametrosOut);


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



        public void InhabilEditar(ref Registro ObjInhabil, ref string Verificador)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand Cmd = null;
            try
            {
                String[] Parametros = { "p_ejercicio", "p_inhabil", "p_habil" , "p_id"};
                object[] Valores = { ObjInhabil.Ejercicio, ObjInhabil.Inhabil, ObjInhabil.Habil, ObjInhabil.Id};
                String[] ParametrosOut = { "p_Bandera" };
                Cmd = CDDatos.GenerarOracleCommand("INS_INHABIL", ref Verificador, Parametros, Valores, ParametrosOut);
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



        public void InhabilInsertar(ref Registro Objinhabil, ref string Verificador)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand Cmd = null;
            try
            {
                String[] Parametros = { "p_ejercicio", "p_inhabil", "p_habil" };
                object[] Valores = { Objinhabil.Ejercicio, Objinhabil.Inhabil, Objinhabil.Habil };
                String[] ParametrosOut = { "p_Bandera" };

                Cmd = CDDatos.GenerarOracleCommand("INS_INHABIL", ref Verificador, Parametros, Valores, ParametrosOut);
                               
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

        public void ConsultarDiaInhabil(ref Registro ObjRegistro, ref List<Registro> List)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand cmm = null;
            try
            {

                OracleDataReader dr = null;
                String[] Parametros = { "p_ejercicio" };
                Object[] Valores = { ObjRegistro.Ejercicio };
                //String[] ParametrosOut = { "p_nombre" };

                cmm = CDDatos.GenerarOracleCommandCursor("pkg_felectronica.Obt_Grid_Inhabil", ref dr, Parametros, Valores);

                while (dr.Read())
                {
                    ObjRegistro = new Registro();
                    ObjRegistro.Id= Convert.ToString(dr[0]);
                     ObjRegistro.Inhabil  = Convert.ToString(dr[1]);
                    ObjRegistro.Habil = Convert.ToString(dr[2]);
                  

                    List.Add(ObjRegistro);

                }
                //ObjRegistro.Nombre = cmm.Parameters["p_ejercicio"].Value.ToString();
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




        public void Consultarinhabil(ref Registro Objinhabil, ref string Verificador)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand Cmd = null;
            try
            {


                string[] ParametrosIn = { "p_id"};
                object[] Valores = {   Objinhabil.Id  };
                string[] ParametrosOut ={
                                        
                                          "p_ejercicio",
                                          "p_inhabil" ,
                                          "p_habil", 
                                        "p_bandera"};

                Cmd = CDDatos.GenerarOracleCommand("SEL_INHABIL", ref Verificador, ParametrosIn, Valores, ParametrosOut);
                if (Verificador == "0")
                {
                    Objinhabil = new Registro ();

                    Objinhabil.Ejercicio = Convert.ToString(Cmd.Parameters["p_ejercicio"].Value);
                    Objinhabil.Inhabil = Convert.ToString(Cmd.Parameters["p_inhabil"].Value);
                    Objinhabil.Habil= Convert.ToString(Cmd.Parameters["p_habil"].Value);
                    
                   
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



        public void Eliminar_Dia_Inhabil(Registro Objinhabil, ref string Verificador)
        {
            CD_Datos CapaDatos = new CD_Datos();
            try
            {

                CapaDatos.StartTrans();
                string[] ParametrosIn ={
                                        "P_Id"
                                        
                };
                Object[] Valores ={
                                    Objinhabil.Id
                };

                string[] ParametrosOut ={
                                        "p_bandera"
                };

                OracleCommand OracleCmd = CapaDatos.GenerarOracleCommand("DEL_INHABIL", ref Verificador, ParametrosIn, Valores, ParametrosOut);
                if (Verificador == "0")
                {

                    CapaDatos.CommitTrans();
                }
                else
                    CapaDatos.RollBackTrans();
                CapaDatos.LimpiarOracleCommand(ref OracleCmd);

            }
            catch (Exception ex)
            {
                CapaDatos.RollBackTrans();
                throw new Exception(ex.Message);
            }
        }







    }
}
