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
    public class CD_Participante
    {
        public void ConsultarParticipante(ref Participante ObjParticipante, ref string Verificador)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand Cmd = null;
            try
            {

              
                string[] ParametrosIn = { "p_PATERNO",
                                          "p_MATERNO",
                                          "p_NOMBRES",
                                          "p_EVENTO"};
                object[] Valores = { ObjParticipante.APaterno,
                                     ObjParticipante.AMaterno,
                                     ObjParticipante.Nombre,
                                     ObjParticipante.Evento   
            };
                string[] ParametrosOut ={
                                        
                                          "p_GENERO",
                                          "p_GRADO" ,
                                          "p_TEL_PARTICULAR",
                                          "p_TEL_CELULAR",
                                          "p_EMAIL",
                                          "p_PROCEDENCIA_INSTITUCION",
                                          "p_PROCEDENCIA_CARGO",
                                          "p_PROCEDENCIA_DOMICILIO",
                                          "p_PROCEDENCIA_CIUDAD",
                                          "p_PROCEDENCIA_TELEFONO",
                                          "p_PONENCIA_TITULO_1",
                                          "p_PONENCIA_TITULO_2",
                                          "p_NOMBRE_CONSTANCIA",
                                          "p_TIPO_PERSONA",
                                          "p_ESTADO",
                                          "p_MATRICULA",
                                          "p_BANDERA",
                                          "p_OPERACION",
                                          "p_DONATIVO",
                                          "p_id_periodo_pago",
                                          "p_COLONIA",
                                          "p_CODIGO_POSTAL"
                };

                 Cmd = CDDatos.GenerarOracleCommand("OBT_EXTERNOS", ref Verificador, ParametrosIn, Valores, ParametrosOut);
                if (Verificador == "0")
                {
                    ObjParticipante = new Participante();

                    ObjParticipante.Operacion = Convert.ToString(Cmd.Parameters["p_OPERACION"].Value);
                    if (ObjParticipante.Operacion == "U")
                    {
                        ObjParticipante.Genero = Convert.ToChar(Cmd.Parameters["p_GENERO"].Value);
                        ObjParticipante.GradoEstudio = Convert.ToString(Cmd.Parameters["p_GRADO"].Value);
                        ObjParticipante.TelParticular = Convert.ToString(Cmd.Parameters["p_TEL_PARTICULAR"].Value);
                        ObjParticipante.Celular = Convert.ToString(Cmd.Parameters["p_TEL_CELULAR"].Value);
                        ObjParticipante.Correo = Convert.ToString(Cmd.Parameters["p_EMAIL"].Value);
                        ObjParticipante.Dependencia = Convert.ToString(Cmd.Parameters["p_PROCEDENCIA_INSTITUCION"].Value);
                        ObjParticipante.CargoProcedencia = Convert.ToString(Cmd.Parameters["p_PROCEDENCIA_CARGO"].Value);
                        ObjParticipante.DomicilioProcedencia = Convert.ToString(Cmd.Parameters["p_PROCEDENCIA_DOMICILIO"].Value);
                        ObjParticipante.CiudadProcedencia = Convert.ToString(Cmd.Parameters["p_PROCEDENCIA_CIUDAD"].Value);
                        ObjParticipante.TelProcedencia = Convert.ToString(Cmd.Parameters["p_PROCEDENCIA_TELEFONO"].Value);
                        ObjParticipante.Ponencia1 = Convert.ToString(Cmd.Parameters["p_PONENCIA_TITULO_1"].Value);
                        ObjParticipante.Ponencia2 = Convert.ToString(Cmd.Parameters["p_PONENCIA_TITULO_2"].Value);
                        ObjParticipante.Constancia = Convert.ToString(Cmd.Parameters["p_NOMBRE_CONSTANCIA"].Value);
                        ObjParticipante.TipoPersona = Convert.ToInt32(Cmd.Parameters["p_TIPO_PERSONA"].Value);
                        ObjParticipante.EstadoProcedencia = Convert.ToString(Cmd.Parameters["p_ESTADO"].Value);
                        ObjParticipante.CP = Convert.ToString(Cmd.Parameters["p_CODIGO_POSTAL"].Value);
                        ObjParticipante.Colonia = Convert.ToString(Cmd.Parameters["p_COLONIA"].Value);
                        ObjParticipante.Donativo = Convert.ToString(Cmd.Parameters["p_DONATIVO"].Value);
                        ObjParticipante.PeriodoPago = Convert.ToInt32(Cmd.Parameters["p_id_periodo_pago"].Value);
                    }

                }
                ObjParticipante.NoControl = Convert.ToString(Cmd.Parameters["p_MATRICULA"].Value);
               
            
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
        public void ConsultarEvento(ref Participante ObjParticipante, ref string Verificador)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand Cmd = null;
            try
            {

              
                string[] ParametrosIn = { 
                                          "p_evento"};
                object[] Valores = { 
                                     ObjParticipante.Evento   
            };
                string[] ParametrosOut ={
                                          "p_BANDERA",
                                          "p_Escuela"
                };

               Cmd = CDDatos.GenerarOracleCommand("VAL_EVENTO_ESCUELA", ref Verificador, ParametrosIn, Valores, ParametrosOut);


                ObjParticipante.StatusEvento = Convert.ToChar(Verificador);
                ObjParticipante.Dependencia = Convert.ToString(Cmd.Parameters["p_Escuela"].Value);
                   
             

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
        public void InsertarParticipante(ref Participante ObjParticipante, ref string Verificador)
         {
             CD_Datos CDDatos = new CD_Datos();
             OracleCommand Cmd = null;
            try
            {

             
                string[] ParametrosIn = { "p_PATERNO",
                                          "p_MATERNO",
                                          "p_NOMBRES",
                                          "p_TEL_PARTICULAR",
                                          "p_TEL_CELULAR",
                                          "p_EMAIL",
                                          "p_PROCEDENCIA_INSTITUCION",
                                          "p_PROCEDENCIA_CARGO",
                                          "p_PROCEDENCIA_DOMICILIO",
                                          "p_PROCEDENCIA_CIUDAD",
                                          "p_PROCEDENCIA_TELEFONO",
                                          "p_TIPO_PERSONA",
                                           "p_PONENCIA_TITULO_1",
                                          "p_PONENCIA_TITULO_2",
                                          "p_NOMBRE_CONSTANCIA",
                                          "p_GENERO",
                                          "p_EVENTO",
                                          "p_GRADO",
                                          "p_ESTADO",
                                          "p_DONATIVO",
                                          "p_id_periodo_pago",
                                          "p_MATRICULA",
                                         "p_COLONIA",
                                          "p_CODIGO_POSTAL"};
                    object[] Valores = { ObjParticipante.APaterno,
                                         ObjParticipante.AMaterno,
                                         ObjParticipante.Nombre,
                                         ObjParticipante.TelParticular,
                                        ObjParticipante.Celular,
                                        ObjParticipante.Correo,
                                        ObjParticipante.Dependencia,
                                        ObjParticipante.CargoProcedencia,
                                        ObjParticipante.DomicilioProcedencia,
                                        ObjParticipante.CiudadProcedencia,
                                        ObjParticipante.TelProcedencia,
                                        ObjParticipante.TipoPersona,
                                        ObjParticipante.Ponencia1,
                                        ObjParticipante.Ponencia2,
                                        ObjParticipante.Constancia,
                                        ObjParticipante.Genero.ToString(),
                                        ObjParticipante.Evento,
                                        ObjParticipante.GradoEstudio,
                                        ObjParticipante.EstadoProcedencia,
                                        ObjParticipante.Donativo,
                                        ObjParticipante.PeriodoPago,
                                        ObjParticipante.NoControl,
                                        ObjParticipante.Colonia,
                                        ObjParticipante.CP
            };
                string[] ParametrosOut ={                                        
                                          "p_BANDERA"
                };

                Cmd = CDDatos.GenerarOracleCommand("INS_EXTERNOS", ref Verificador, ParametrosIn, Valores, ParametrosOut);
           
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
        public void ActualizarParticipante(ref Participante ObjParticipante, ref string Verificador)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand Cmd = null;
            try
            {

              
                string[] ParametrosIn = { "p_PATERNO",
                                          "p_MATERNO",
                                          "p_NOMBRES",
                                          "p_TEL_PARTICULAR",
                                          "p_TEL_CELULAR",
                                          "p_EMAIL",
                                          "p_PROCEDENCIA_INSTITUCION",
                                          "p_PROCEDENCIA_CARGO",
                                          "p_PROCEDENCIA_DOMICILIO",
                                          "p_PROCEDENCIA_CIUDAD",
                                          "p_PROCEDENCIA_TELEFONO",
                                          "p_TIPO_PERSONA",
                                           "p_PONENCIA_TITULO_1",
                                          "p_PONENCIA_TITULO_2",
                                          "p_NOMBRE_CONSTANCIA",
                                          "p_GENERO",
                                          "p_EVENTO",
                                          "p_GRADO",
                                          "p_ESTADO",
                                          "p_DONATIVO",
                                          "p_id_periodo_pago",
                                          "p_MATRICULA",
                                          "p_COLONIA",
                                          "p_CODIGO_POSTAL"};
                object[] Valores = { ObjParticipante.APaterno,
                                         ObjParticipante.AMaterno,
                                         ObjParticipante.Nombre,
                                         ObjParticipante.TelParticular,
                                        ObjParticipante.Celular,
                                        ObjParticipante.Correo,
                                        ObjParticipante.Dependencia,
                                        ObjParticipante.CargoProcedencia,
                                        ObjParticipante.DomicilioProcedencia,
                                        ObjParticipante.CiudadProcedencia,
                                        ObjParticipante.TelProcedencia,
                                        ObjParticipante.TipoPersona,
                                        ObjParticipante.Ponencia1,
                                        ObjParticipante.Ponencia2,
                                        ObjParticipante.Constancia,
                                        ObjParticipante.Genero.ToString(),
                                        ObjParticipante.Evento,
                                        ObjParticipante.GradoEstudio,
                                        ObjParticipante.EstadoProcedencia,
                                        ObjParticipante.Donativo,
                                        ObjParticipante.PeriodoPago,
                                        ObjParticipante.NoControl,
                                        ObjParticipante.Colonia,
                                        ObjParticipante.CP
            };
                string[] ParametrosOut ={                                        
                                          "p_BANDERA"
                };

                Cmd = CDDatos.GenerarOracleCommand("UPD_EXTERNOS", ref Verificador, ParametrosIn, Valores, ParametrosOut);

           

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
