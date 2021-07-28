using System;
using System.Collections.Generic;
using System.Data.OracleClient;
using System.Linq;
using System.Text;
using CapaEntidad;
namespace CapaDatos
{
   public class CD_Evento
    {
        public void ConsultarEventos(ref Evento Objeventos, ref List<Evento> List, string Busqueda)
        {
            CD_Datos CDDatos = new CD_Datos("INGRESOS");
            OracleCommand cmm = null;
            try
            {

                OracleDataReader dr = null;
                String[] Parametros = { "p_dependencia", "p_status", "p_busqueda", "p_tipo_acceso", "p_anio" };
                Object[] Valores = { Objeventos.Dependencia, Objeventos.Status, Busqueda, Objeventos.Tipo, Objeventos.Anio };
                //String[] ParametrosOut = { "p_dependencia", "p_evento", "p_descripcion", "p_fecha_inicial", "p_fecha_final", "p_nivel" };

                cmm = CDDatos.GenerarOracleCommandCursor("pkg_pagos.Obt_Grid_Evento", ref dr, Parametros, Valores);

                while (dr.Read())
                {
                    Objeventos = new Evento();
                    Objeventos.Dependencia = Convert.ToString(dr[0]);
                    Objeventos.Eventos = Convert.ToString(dr[1]);
                    Objeventos.Descripcion = Convert.ToString(dr[2]);       
                    Objeventos.Fecha_inicial = Convert.ToString(dr[3]);
                    Objeventos.Fecha_final = Convert.ToString(dr[4]);
                    Objeventos.Nivel = Convert.ToString(dr[5]);
                    Objeventos.Status = Convert.ToString(dr[6]);
                    Objeventos.Usuario_Solicita= Convert.ToString(dr[8]);
                    Objeventos.Fecha_Solicitud = Convert.ToString(dr[9]);
                    Objeventos.Usuario_Autoriza = Convert.ToString(dr[10]);
                    Objeventos.Fecha_Autorizacion = Convert.ToString(dr[11]);
                    Objeventos.NoOficio =Convert.ToString(dr[12])+" DOCTO(S)";
                    Objeventos.Nueva_Version = Convert.ToString(dr[13]);
                    Objeventos.EsVisible = (Convert.ToString(dr[13])=="S") ? true : false;
                    Objeventos.EsVisible2 = (Convert.ToString(dr[13]) == "S") ? false : true;
                    Objeventos.VisibleAutorizacion = (Convert.ToString(dr[14]) == "S") ? true : false;
                    if (Convert.ToString(dr[7]) != "")
                    {
                        Objeventos.Oficio_s = "<img src=" + "https://sysweb.unach.mx/resources/imagenes/adjunto.png" + ">";
                        Objeventos.Oficio = Convert.ToString(dr[7]);
                    }
                    else
                    {
                        Objeventos.Oficio_s = "";
                        Objeventos.Oficio ="";
                    }

                    List.Add(Objeventos);
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
        public void ConsultarEventos_conceptos(ref ConceptoCuotaLibre ObjConceptoCuotaLibre, ref List<ConceptoCuotaLibre> List)
        {
            CD_Datos CDDatos = new CD_Datos("INGRESOS");
            OracleCommand cmm = null;
            try
            {

                OracleDataReader dr = null;
                String[] Parametros = { "p_evento" };
                Object[] Valores = { ObjConceptoCuotaLibre.Evento };

                cmm = CDDatos.GenerarOracleCommandCursor("PKG_PAGOS.Obt_Grid_Evento_Conceptos", ref dr, Parametros, Valores);

                while (dr.Read())
                {
                    ObjConceptoCuotaLibre = new ConceptoCuotaLibre();
                    ObjConceptoCuotaLibre.Evento = Convert.ToString(dr[0]);
                    ObjConceptoCuotaLibre.Carrera = Convert.ToInt32(dr[1]);
                    ObjConceptoCuotaLibre.DescCarrera = Convert.ToString(dr[2]);
                    ObjConceptoCuotaLibre.Id_Concepto = Convert.ToInt32(dr[3]);
                    ObjConceptoCuotaLibre.DescConcepto = Convert.ToString(dr[4]);
                    ObjConceptoCuotaLibre.Dependencia = Convert.ToInt32(dr[5]);
                    ObjConceptoCuotaLibre.Importe = Convert.ToInt32(dr[6]);
                    ObjConceptoCuotaLibre.Status = Convert.ToChar(dr[7]);
                    ObjConceptoCuotaLibre.Observaciones = Convert.ToString(dr[8]);
                    List.Add(ObjConceptoCuotaLibre);
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
        public void ConsultarEventos_Detalle(ref ConceptoCuotaLibre ObjConceptoCuotaLibre, ref List<ConceptoCuotaLibre> List)
        {
            CD_Datos CDDatos = new CD_Datos("INGRESOS");
            OracleCommand cmm = null;
            try
            {

                OracleDataReader dr = null;
                String[] Parametros = { "p_evento" };
                Object[] Valores = { ObjConceptoCuotaLibre.Evento};
               
                cmm = CDDatos.GenerarOracleCommandCursor("PKG_PAGOS_2016.Obt_Grid_Evento_Conceptos", ref dr, Parametros, Valores);

                while (dr.Read())
                {
                    ObjConceptoCuotaLibre = new ConceptoCuotaLibre();
                    ObjConceptoCuotaLibre.Evento = Convert.ToString(dr[0]);
                    ObjConceptoCuotaLibre.Carrera = Convert.ToInt32(dr[1]);
                    ObjConceptoCuotaLibre.DescCarrera = Convert.ToString(dr[2]);
                    ObjConceptoCuotaLibre.Id_Concepto = Convert.ToInt32(dr[3]);
                    ObjConceptoCuotaLibre.DescConcepto = Convert.ToString(dr[4]);
                    ObjConceptoCuotaLibre.Dependencia = Convert.ToInt32(dr[5]);
                    ObjConceptoCuotaLibre.Importe = Convert.ToInt32(dr[6]);
                    ObjConceptoCuotaLibre.Status = Convert.ToChar(dr[7]);
                    ObjConceptoCuotaLibre.Observaciones= Convert.ToString(dr[8]);
                    ObjConceptoCuotaLibre.Es_Ponente = Convert.ToString(dr[9]);
                    ObjConceptoCuotaLibre.Requiere_Constancia = Convert.ToString(dr[10]);
                    ObjConceptoCuotaLibre.Concepto = Convert.ToString(dr[11]);
                    ObjConceptoCuotaLibre.Tipo_Participante = Convert.ToString(dr[12]);
                    ObjConceptoCuotaLibre.Participante = Convert.ToString(dr[13]);
                    ObjConceptoCuotaLibre.Desc_Tipo_Participante = Convert.ToString(dr[2]);
                    ObjConceptoCuotaLibre.Id_Tipo_Participante = Convert.ToInt32(dr[1]);
                    List.Add(ObjConceptoCuotaLibre);
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
        public void ConsultarEvento_Participantes(ref ConceptoCuotaLibre ObjParticipantes, ref List<ConceptoCuotaLibre> List)
        {
            CD_Datos CDDatos = new CD_Datos("INGRESOS");
            OracleCommand cmm = null;
            try
            {

                OracleDataReader dr = null;
                String[] Parametros = { "p_evento" };
                Object[] Valores = { ObjParticipantes.Evento };

                cmm = CDDatos.GenerarOracleCommandCursor("PKG_PAGOS_2016.Obt_Grid_Eventos_Persona", ref dr, Parametros, Valores);

                while (dr.Read())
                {
                    ObjParticipantes = new ConceptoCuotaLibre();
                    ObjParticipantes.Evento = Convert.ToString(dr[0]);
                    ObjParticipantes.Tipo_Participante = Convert.ToString(dr[3]);
                    ObjParticipantes.Desc_Tipo_Participante = Convert.ToString(dr[1]);
                    ObjParticipantes.Es_Ponente = Convert.ToString(dr[2]);
                    ObjParticipantes.Participante = Convert.ToString(dr[5]);
                    ObjParticipantes.Requiere_Constancia = Convert.ToString(dr[4]);
                    List.Add(ObjParticipantes);
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
        public void ConsultarEventoDetParticipantes(ConceptoCuotaLibre ObjParticipantes, ref List<ConceptoCuotaLibre> List)
        {
            CD_Datos CDDatos = new CD_Datos("INGRESOS");
            OracleCommand cmm = null;
            try
            {

                OracleDataReader dr = null;
                String[] Parametros = { "p_evento" };
                Object[] Valores = { ObjParticipantes.Evento };

                cmm = CDDatos.GenerarOracleCommandCursor("PKG_PAGOS_2016.Obt_Grid_Temp_Det_Part", ref dr, Parametros, Valores);

                while (dr.Read())
                {
                    ObjParticipantes = new ConceptoCuotaLibre();
                    ObjParticipantes.Id_Tipo_Participante  = Convert.ToInt32(dr[1]);
                    ObjParticipantes.Tipo_Participante = Convert.ToString(dr[2]);
                    ObjParticipantes.Participante = Convert.ToString(dr[3]);
                    ObjParticipantes.Es_Ponente = Convert.ToString(dr[4]);
                    ObjParticipantes.Requiere_Constancia = Convert.ToString(dr[5]);
                    ObjParticipantes.Id = Convert.ToString(dr[6]);
                    List.Add(ObjParticipantes);
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
        public void ConsultarEventoDetConceptos(ConceptoCuotaLibre ObjParticipantes, ref List<ConceptoCuotaLibre> List)
        {
            CD_Datos CDDatos = new CD_Datos("INGRESOS");
            OracleCommand cmm = null;
            try
            {

                OracleDataReader dr = null;
                String[] Parametros = { "P_ID" };
                Object[] Valores = { ObjParticipantes.Id };

                cmm = CDDatos.GenerarOracleCommandCursor("PKG_PAGOS_2016.Obt_Grid_Temp_Det_Conc", ref dr, Parametros, Valores);

                while (dr.Read())
                {
                    ObjParticipantes = new ConceptoCuotaLibre();
                    ObjParticipantes.Id_Concepto = Convert.ToInt32(dr[1]);
                    ObjParticipantes.Importe = Convert.ToDouble(dr[2]);
                    ObjParticipantes.DescCarrera = Convert.ToString(dr[3]);
                    ObjParticipantes.DescConcepto = Convert.ToString(dr[4]);
                    List.Add(ObjParticipantes);
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

        public void ConsultarEventoParticipantes(string Evento, ref TipoParticipante ObjParticipantes, ref List<TipoParticipante> List)
        {
            CD_Datos CDDatos = new CD_Datos("INGRESOS");
            OracleCommand cmm = null;
            try
            {
                OracleDataReader dr = null;
                String[] Parametros = { "p_evento" };
                Object[] Valores = { Evento };
                cmm = CDDatos.GenerarOracleCommandCursor("PKG_PAGOS_2016.Obt_Grid_Evento_Personas", ref dr, Parametros, Valores);

                while (dr.Read())
                {
                    ObjParticipantes = new TipoParticipante();
                    List<Concepto> lstConceptos = new List<Concepto>();
                    ObjParticipantes.Tipo_Participante = Convert.ToString(dr[3]);
                    ObjParticipantes.Desc_Tipo_Participante = Convert.ToString(dr[1]);
                    ObjParticipantes.Requiere_Constancia = Convert.ToString(dr[4]);
                    ObjParticipantes.Es_Ponente = Convert.ToString(dr[2]);
                    ObjParticipantes.Participante = Convert.ToString(dr[5]);
                    ObjParticipantes.Evento = Convert.ToString(dr[0]);
                    ObjParticipantes.Nuevo = "N";
                    ObjParticipantes.Eliminar = "N";
                    ObjParticipantes.Id = Convert.ToString(dr[6]);
                    ConsultarEventoConceptos(ref ObjParticipantes, Evento, Convert.ToInt32(dr[6]));                    
                    List.Add(ObjParticipantes);
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
        public void ConsultarEventoConceptos(ref TipoParticipante objParticipante, string Evento, int IdPersona)
        {
            CD_Datos CDDatos = new CD_Datos("INGRESOS");
            OracleCommand cmm = null;
            try
            {
                OracleDataReader dr = null;
                String[] Parametros = { "p_evento", "p_id_persona" };
                Object[] Valores = { Evento, IdPersona };
                cmm = CDDatos.GenerarOracleCommandCursor("PKG_PAGOS_2016.Obt_Grid_Evento_ConceptosDet", ref dr, Parametros, Valores);

                while (dr.Read())
                {
                    Concepto ObjConcepto = new Concepto();
                    ObjConcepto.Evento = Convert.ToString(dr[6]);
                    ObjConcepto.Dependencia = Convert.ToString(dr[1]);
                    ObjConcepto.CveConcepto = Convert.ToString(dr[8]);
                    ObjConcepto.DescConcepto = Convert.ToString(dr[5]);
                    ObjConcepto.Tipo_Participante = Convert.ToString(dr[2]);
                    ObjConcepto.IdConcepto = Convert.ToInt32(dr[0]);
                    ObjConcepto.Importe = Convert.ToDouble(dr[3]);
                    ObjConcepto.Status = Convert.ToString(dr[4]);
                    ObjConcepto.Nuevo = "N";
                    ObjConcepto.Eliminar = "N";
                    objParticipante.Conceptos.Add(ObjConcepto);                    
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
        public void EventoInsertar(Evento objeventos, string Usuario, ref string Verificador)
        {
            CD_Datos CDDatos = new CD_Datos("INGRESOS");
            OracleCommand Cmd = null;
            try
            {
                String[] Parametros = {  "p_descripcion", "p_escuela", "p_fecha_inicial", "p_fecha_final", "p_email_res", "p_email_corres", "p_concepto", "p_status", "p_nivel", "p_ini_matricula", "p_autorizacion", "p_tipo_periodo", "p_tipo", "p_usuario", "p_observaciones" };
                object[] Valores = { objeventos.Descripcion, objeventos.Dependencia, objeventos.Fecha_inicial, objeventos.Fecha_final, objeventos.Email_Res, objeventos.Email_Corres, objeventos.Concepto, objeventos.Status, objeventos.Nivel, objeventos.Ini_Matricula, objeventos.Autorizacion, objeventos.Tipo_Periodo, objeventos.Tipo, Usuario, objeventos.Observaciones };
                String[] ParametrosOut = { "p_evento", "P_ANO", "p_Bandera" };

                Cmd = CDDatos.GenerarOracleCommand("INS_EVENTOS", ref Verificador, Parametros, Valores, ParametrosOut);

                if (Verificador == "0")
                {
                    objeventos.Eventos = Convert.ToString(Cmd.Parameters["p_evento"].Value);
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
        public void ConsultarCveEvento(ref Evento objeventos, ref string Verificador)
        {
            CD_Datos CDDatos = new CD_Datos("INGRESOS");
            OracleCommand Cmd = null;
            try
            {
                String[] ParametrosOut = { "P_EVENTO", "P_BANDERA" };

                Cmd = CDDatos.GenerarOracleCommand("OBT_CVE_EVENTO", ref Verificador, ParametrosOut);

                if (Verificador == "0")
                {
                    objeventos.Eventos = Convert.ToString(Cmd.Parameters["P_EVENTO"].Value);
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

        public void EventoInsertarDetPart(ref ConceptoCuotaLibre objeventos, ref string Verificador)
        {
            CD_Datos CDDatos = new CD_Datos("INGRESOS");
            OracleCommand Cmd = null;
            try
            {
                String[] Parametros = { "P_EVENTO", "P_ID_PARTICIPANTE", "P_TIPO_PARTICIPANTE", "P_PONENTE", "P_CONSTANCIA", "P_STATUS" };
                object[] Valores = { objeventos.Evento, objeventos.Id_Tipo_Participante, objeventos.Tipo_Participante, objeventos.Es_Ponente, objeventos.Requiere_Constancia, objeventos.StatusDet };
                String[] ParametrosOut = { "P_ID","p_Bandera" };
                Cmd = CDDatos.GenerarOracleCommand("INS_TEMP_PARTICIPANTES_EVENTO", ref Verificador, Parametros, Valores, ParametrosOut);
                if (Verificador == "0")
                    objeventos.Id = Convert.ToString(Cmd.Parameters["P_ID"].Value);
                
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
        public void EventoInsertarDetConcept(ConceptoCuotaLibre objConceptos, ref string Verificador)
        {
            CD_Datos CDDatos = new CD_Datos("INGRESOS");
            OracleCommand Cmd = null;
            try
            {
                String[] Parametros = {"P_ID_PARTICIPANTE", "P_ID_CONCEPTO", "P_IMPORTE", "P_OBSERVACIONES", " P_EVENTO" };
                object[] Valores = { objConceptos.Id_Tipo_Participante, objConceptos.Id_Concepto, objConceptos.Importe, objConceptos.Observaciones, objConceptos.Evento };
                String[] ParametrosOut = { "p_Bandera" };
                Cmd = CDDatos.GenerarOracleCommand("INS_TEMP_PARTICIPANTES_CONCEP", ref Verificador, Parametros, Valores, ParametrosOut);               
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


        public void EventoEspecialInsertar(Evento objeventos, string Usuario, string VersionNueva, ref string Verificador)
        {
            CD_Datos CDDatos = new CD_Datos("INGRESOS");
            OracleCommand Cmd = null;
            try
            {
                String[] Parametros = { "p_descripcion", "p_escuela", "p_fecha_inicial", "p_fecha_final", "p_email_res", "p_email_corres", "p_concepto", "p_status", "p_nivel", "p_ini_matricula", "p_autorizacion", "p_tipo_periodo", "p_tipo", "p_usuario", "p_observaciones", "p_version_nueva" };
                object[] Valores = { objeventos.Descripcion, objeventos.Dependencia, objeventos.Fecha_inicial, objeventos.Fecha_final, objeventos.Email_Res, objeventos.Email_Corres, objeventos.Concepto, objeventos.Status, objeventos.Nivel, objeventos.Ini_Matricula, objeventos.Autorizacion, objeventos.Tipo_Periodo, objeventos.Tipo, Usuario, objeventos.Observaciones, VersionNueva };
                String[] ParametrosOut = { "p_evento", "P_ANO", "p_Bandera" };

                Cmd = CDDatos.GenerarOracleCommand("INS_EVENTO_ESPECIAL", ref Verificador, Parametros, Valores, ParametrosOut);

                if (Verificador == "0")
                {
                    objeventos.Eventos = Convert.ToString(Cmd.Parameters["p_evento"].Value);
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
        public void EventoInsertarConfiguracion(List<ConceptoCuotaLibre> lstConfiguracion, string Evento, ref string Verificador)
        {

            var groupedTipoParticipante = lstConfiguracion.GroupBy(u => new { u.Id_Tipo_Participante, u.Requiere_Constancia }).ToList();

            List<ConceptoCuotaLibre> lstParticipantes = (
                    from p in lstConfiguracion
                    group p by p.Id_Tipo_Participante into g
                    select new ConceptoCuotaLibre()          
                    ).ToList();

            //groupedTipoParticipante

            foreach (var lst in groupedTipoParticipante)
            {

                CD_Datos CDDatos = new CD_Datos("INGRESOS");
                OracleCommand Cmd = null;
                try
                {
                    String[] Parametros = { "P_EVENTO", "P_ID_TIPO_PERSONA", "P_CONSTANCIA" };
                    object[] Valores = { Evento, lst.Key.Id_Tipo_Participante, lst.Key.Requiere_Constancia
                    };
                    String[] ParametrosOut = { "p_Bandera" };
                    Cmd = CDDatos.GenerarOracleCommand("INS_EVENTO_TIPO_PARTICIPANTE", ref Verificador, Parametros, Valores, ParametrosOut);                   
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
        public void EventoInsertarConfiguracionDetalle(List<ConceptoCuotaLibre> lstConfiguracion, string Evento, ref string Verificador)
        {

            foreach (ConceptoCuotaLibre lst in lstConfiguracion)
            {

                CD_Datos CDDatos = new CD_Datos("INGRESOS");
                OracleCommand Cmd = null;
                try
                {
                    String[] Parametros = { "P_CONCEPTO", "P_DEPENDENCIA", "P_CARRERA", "P_IMPORTE", "P_STATUS", "P_OBSERVACIONES",
                    "P_EVENTO", "P_FECHA_INICIAL", "P_FECHA_FINAL"};
                    object[] Valores = { lst.Concepto, lst.Dependencia, lst.Id_Tipo_Participante, lst.Importe, lst.Status, lst.Observaciones, /*lst.DescConcepto,*/
                        Evento, "", ""
                    };
                    String[] ParametrosOut = { "p_Bandera" };

                    Cmd = CDDatos.GenerarOracleCommand("INS_CONCEPTOS_CUOTA_LIBRE", ref Verificador, Parametros, Valores, ParametrosOut);

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
        public void EventoInsertarDetalle(List<TipoParticipante> lstParticipantes, string Evento, ref string Verificador)
        {
            //List<TipoParticipante> lstConceptos = new List<TipoParticipante>();
            //lstConceptos = lstParticipantes;
            List<TipoParticipante> lstNewParticipantes = lstParticipantes.Where(x => x.Nuevo == "S" && x.Eliminar=="N").ToList();
            int indexParticipante = 0;
            foreach (TipoParticipante lst in lstNewParticipantes)
            {

                CD_Datos CDDatos = new CD_Datos("INGRESOS");
                OracleCommand Cmd = null;
                try
                {
                    String[] Parametros = { "P_EVENTO", "P_DESC_TIPO_PARTICIPANTE", "P_ES_PONENTE", "P_TIPO_PARTICIPANTE", "P_CONSTANCIA" };
                    object[] Valores = { Evento, lst.Desc_Tipo_Participante, lst.Es_Ponente, lst.Tipo_Participante, lst.Requiere_Constancia
                    };
                    String[] ParametrosOut = { "p_Bandera", "P_ID_TIPO_PERSONA" };

                    Cmd = CDDatos.GenerarOracleCommand("INS_EVENTO_TIPO_PERSONA", ref Verificador, Parametros, Valores, ParametrosOut);
                    if (Verificador == "0")                    
                        lstParticipantes[indexParticipante].Id = Convert.ToString(Cmd.Parameters["P_ID_TIPO_PERSONA"].Value);

                    

                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
                finally
                {
                    CDDatos.LimpiarOracleCommand(ref Cmd);
                }
                indexParticipante++;
            }


            int index = 0;
            string IdPersona;
            foreach (TipoParticipante lst in lstNewParticipantes)
            {
                //CD_Datos CDDatos = new CD_Datos("INGRESOS");
                //OracleCommand Cmd = null;
                List<Concepto> lstConceptosVarios = new List<Concepto>();
                var Conceptos = lstNewParticipantes[index].Conceptos;
                lstConceptosVarios=Conceptos.ToList<Concepto>();
                List<Concepto> lstConceptos = lstConceptosVarios.Where(x => x.Nuevo == "S" && x.Eliminar == "N").ToList();


                IdPersona = lstNewParticipantes[index].Id;
                foreach (Concepto lstConcepto in lstConceptos)
                {
                    CD_Datos CDDatos = new CD_Datos("INGRESOS");
                    OracleCommand Cmd = null;
                    try
                    {
                        String[] Parametros = { "P_EVENTO", "P_CONCEPTO", "P_DEPENDENCIA", "P_IMPORTE", "P_STATUS", "P_OBSERVACIONES", "P_ID_TIPO_PERSONA" };
                        object[] Valores = { Evento, lstConcepto.CveConcepto, lstConcepto.Dependencia, lstConcepto.Importe, lstConcepto.Status, lstConcepto.DescConcepto, IdPersona
                    };
                        String[] ParametrosOut = { "p_Bandera" };

                        Cmd = CDDatos.GenerarOracleCommand("INS_EVENTO_DETALLE", ref Verificador, Parametros, Valores, ParametrosOut);
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
                index++;
            }
        }
        public void EventoEditarDetalle(List<TipoParticipante> lstParticipantes, string Evento, ref string Verificador)
        {
            //List<TipoParticipante> lstConceptos = new List<TipoParticipante>();
            List<TipoParticipante> list = lstParticipantes.Where(x => x.Nuevo == "N").ToList();

            //lstConceptos = list;
            int indexParticipante = 0;
            foreach (TipoParticipante lst in list)
            {

                CD_Datos CDDatos = new CD_Datos("INGRESOS");
                OracleCommand Cmd = null;
                try
                {
                    String[] Parametros = { "P_ID_TIPO_PERSONA", "P_EVENTO", "P_DESCRIPCION", "P_PONENTE", "P_CONSTANCIA" };
                    object[] Valores = { lst.Id, lst.Evento, lst.Desc_Tipo_Participante, lst.Es_Ponente, lst.Requiere_Constancia };
                    String[] ParametrosOut = { "P_BANDERA" };

                    Cmd = CDDatos.GenerarOracleCommand("UPD_EVENTO_TIPO_PERSONA", ref Verificador, Parametros, Valores, ParametrosOut);
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
                finally
                {
                    CDDatos.LimpiarOracleCommand(ref Cmd);
                }
                indexParticipante++;
            }


            int index = 0;
            string IdPersona;
            foreach (TipoParticipante lst in lstParticipantes)
            {
                List<Concepto> lstConceptosVarios = new List<Concepto>();
                var Conceptos = lstParticipantes[index].Conceptos;
                lstConceptosVarios = Conceptos.ToList<Concepto>();

                List<Concepto> lstConceptos = lstConceptosVarios.Where(x => x.Nuevo == "N").ToList();
                List<Concepto> lstConceptosNew = lstConceptosVarios.Where(x => x.Nuevo == "S" && x.Eliminar=="N").ToList();

                IdPersona = lstParticipantes[index].Id;
                foreach (Concepto lstConcepto in lstConceptos)
                {
                    CD_Datos CDDatos = new CD_Datos("INGRESOS");
                    OracleCommand Cmd = null;
                    try
                    {
                        String[] Parametros = { "P_EVENTO", "P_DEPENDENCIA", "P_ID_CONCEPTO", "P_TIPO_PARTICIPANTE", "P_DESCRIPCION", "P_STATUS", "P_IMPORTE" };
                        object[] Valores = { Evento, lstConcepto.Dependencia, lstConcepto.IdConcepto, lstConcepto.Tipo_Participante, lstConcepto.DescConcepto, lstConcepto.Status, lstConcepto.Importe
                    };
                        String[] ParametrosOut = { "p_Bandera" };

                        Cmd = CDDatos.GenerarOracleCommand("UPD_EVENTO_DETALLE", ref Verificador, Parametros, Valores, ParametrosOut);
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

                foreach (Concepto lstConcepto in lstConceptosNew)
                {
                    CD_Datos CDDatos = new CD_Datos("INGRESOS");
                    OracleCommand Cmd = null;
                    try
                    {
                        String[] Parametros = { "P_EVENTO", "P_CONCEPTO", "P_DEPENDENCIA", "P_IMPORTE", "P_STATUS", "P_OBSERVACIONES", "P_ID_TIPO_PERSONA" };
                        object[] Valores = { Evento, lstConcepto.CveConcepto, lstConcepto.Dependencia, lstConcepto.Importe, lstConcepto.Status, lstConcepto.DescConcepto, IdPersona
                    };
                        String[] ParametrosOut = { "p_Bandera" };

                        Cmd = CDDatos.GenerarOracleCommand("INS_EVENTO_DETALLE", ref Verificador, Parametros, Valores, ParametrosOut);
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


                index++;
            }
        }
        public void EventoEliminarDetalle(string Evento, ref string Verificador)
        {
           

                CD_Datos CDDatos = new CD_Datos("INGRESOS");
                OracleCommand Cmd = null;
                try
                {
                    String[] Parametros = { "P_EVENTO" };
                    object[] Valores = { Evento };
                    String[] ParametrosOut = { "P_BANDERA" };

                    Cmd = CDDatos.GenerarOracleCommand("DEL_EVENTO_DETALLE", ref Verificador, Parametros, Valores, ParametrosOut);
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
        public void EventoEliminarEventoParticipante(string Evento, ref string Verificador)
        {

           
                CD_Datos CDDatos = new CD_Datos("INGRESOS");
                OracleCommand Cmd = null;
                try
                {
                    String[] Parametros = { "P_EVENTO" };
                    object[] Valores = { Evento };
                    String[] ParametrosOut = { "p_Bandera" };

                    Cmd = CDDatos.GenerarOracleCommand("DEL_EVENTO_DETALLE", ref Verificador, Parametros, Valores, ParametrosOut);
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
        public void EventoEliminarDetalleParticipante(List<TipoParticipante> lstParticipantes, ref string Verificador)
        {

            List<TipoParticipante> list = lstParticipantes.Where(x => x.Eliminar == "S" && x.Evento != null).ToList();
            foreach (TipoParticipante lst in list)
            {

                CD_Datos CDDatos = new CD_Datos("INGRESOS");
                OracleCommand Cmd = null;
                try
                {
                    String[] Parametros = { "P_EVENTO", "P_TIPO_PARTICIPANTE" };
                    object[] Valores = { lst.Evento, lst.Id /*Tipo_Participante*/};
                    String[] ParametrosOut = { "p_Bandera" };

                    Cmd = CDDatos.GenerarOracleCommand("DEL_EVENTO_DET_PARTICIPANTE", ref Verificador, Parametros, Valores, ParametrosOut);
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
        public void EventoEliminarDetalleConcepto(List<Concepto> lstConceptos, ref string Verificador)
        {

            List<Concepto> list = lstConceptos.Where(x => x.Eliminar == "S" && x.IdConcepto>0).ToList();
            foreach (Concepto lst in list)
            {

                CD_Datos CDDatos = new CD_Datos("INGRESOS");
                OracleCommand Cmd = null;
                try
                {
                    String[] Parametros = { "P_EVENTO", "P_DEPENDENCIA", "P_TIPO_PARTICIPANTE", "P_ID_CONCEPTO" };
                    object[] Valores = { lst.Evento, lst.Dependencia, lst.Tipo_Participante, lst.IdConcepto };                    
                    String[] ParametrosOut = { "p_Bandera" };

                    Cmd = CDDatos.GenerarOracleCommand("DEL_EVENTO_DET_CONCEPTO", ref Verificador, Parametros, Valores, ParametrosOut);
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
        public void Insertar_oficio(Evento objeventos, ref string Verificador)
        {
            CD_Datos CDDatos = new CD_Datos("INGRESOS");
            OracleCommand Cmd = null;
            try
            {
                String[] Parametros = { "p_evento", "P_NOMBRE_OFICIO", "P_FIRMA", "P_NO_OFICIO", "P_OBSERVACIONES", "P_FECHA"};
                object[] Valores = { objeventos.Eventos, objeventos.Oficio, objeventos.Firma, objeventos.NoOficio, objeventos.Observaciones, objeventos.FechaOficio };
                String[] ParametrosOut = { "p_Bandera" };

                Cmd = CDDatos.GenerarOracleCommand("INS_EVENTO_OFICIO", ref Verificador, Parametros, Valores, ParametrosOut);

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
        public void Insertar_Oficios(string Evento, List<Oficio> lstOficios, ref string Verificador)
        {
            foreach (Oficio lst in lstOficios)
            {
                CD_Datos CDDatos = new CD_Datos("INGRESOS");
                OracleCommand Cmd = null;
                try
                {
                    String[] Parametros = { "p_evento", "P_NOMBRE_OFICIO", "P_FIRMA", "P_NO_OFICIO", "P_OBSERVACIONES", "P_FECHA" };
                    object[] Valores = { Evento, lst.NombreArchivo, lst.FirmaOficio, lst.NumOficio, lst.Observaciones, lst.FechaOficio };
                    String[] ParametrosOut = { "p_Bandera" };

                    Cmd = CDDatos.GenerarOracleCommand("INS_EVENTO_OFICIO", ref Verificador, Parametros, Valores, ParametrosOut);

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
        public void Editar_oficio(Evento objeventos, ref string Verificador)
        {
            CD_Datos CDDatos = new CD_Datos("INGRESOS");
            OracleCommand Cmd = null;
            try
            {
                String[] Parametros = { "p_evento", "P_NOMBRE_OFICIO", "P_FIRMA", "P_NO_OFICIO", "P_OBSERVACIONES", "P_FECHA" };
                object[] Valores = { objeventos.Eventos, objeventos.Oficio, objeventos.Firma, objeventos.NoOficio, objeventos.Observaciones, objeventos.FechaOficio };
                String[] ParametrosOut = { "p_Bandera" };

                Cmd = CDDatos.GenerarOracleCommand("UPD_EVENTO_OFICIO", ref Verificador, Parametros, Valores, ParametrosOut);
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
        public void ConceptoCuotaLibreInsertar(List<ConceptoCuotaLibre> List, ref string Verificador)
        {
            //CD_Datos CDDatos = new CD_Datos("INGRESOS");
            //OracleCommand Cmd = null;
            try
            {
                for (int i = 0; i < List.Count; i++) // Loop through List with for
	            {
                    CD_Datos CDDatos = new CD_Datos("INGRESOS");
                    OracleCommand Cmd = null;
                    String[] Parametros = { "p_evento", "p_carrera", "p_id_concepto", "p_dependencia", "p_importe", "p_status", "p_observaciones", "p_extemporaneo_dia" };
                    object[] Valores = { List[i].Evento, List[i].Carrera, List[i].Id_Concepto, List[i].Dependencia, List[i].Importe, List[i].Status, List[i].Observaciones, List[i].Extemporaneo_Dia };
                    String[] ParametrosOut = { "p_Bandera" };
                    Cmd = CDDatos.GenerarOracleCommand("INS_DETALLE_EVENTO", ref Verificador, Parametros, Valores, ParametrosOut);
                    CDDatos.LimpiarOracleCommand(ref Cmd);
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                //CDDatos.LimpiarOracleCommand(ref Cmd);
            }
        }
        public void insertarConceptoCuotaLibre(ref ConceptoCuotaLibre objConceptoCuotaLibre, ref string Verificador)
        {
            CD_Datos CDDatos = new CD_Datos("INGRESOS");
            OracleCommand Cmd = null;
            try
            {
                String[] Parametros = { "p_evento", "p_carrera", "p_concepto", "p_dependencia", "p_importe", "p_status", "p_observaciones" };
                object[] Valores = { objConceptoCuotaLibre.Evento, objConceptoCuotaLibre.Carrera, objConceptoCuotaLibre.Concepto, objConceptoCuotaLibre.Dependencia, objConceptoCuotaLibre.Importe, objConceptoCuotaLibre.Status, objConceptoCuotaLibre.Observaciones};
                String[] ParametrosOut = {"p_id_concepto", "p_Bandera" };
                Cmd = CDDatos.GenerarOracleCommand("INS_DETALLE_EVENTO", ref Verificador, Parametros, Valores, ParametrosOut);

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
        public void EventoEditar(Evento objeventos, string Usuario, ref string Verificador)
        {
            CD_Datos CDDatos = new CD_Datos("INGRESOS");
            OracleCommand Cmd = null;
            try
            {
                String[] Parametros = { "p_descripcion", "p_escuela", "p_fecha_inicial", "p_fecha_final", "p_email_res", "p_email_corres", "p_concepto", "p_status","p_nivel", "p_ini_matricula", "p_autorizacion", "p_evento", "p_tipo", "p_usuario", "p_observaciones" };

                object[] Valores = {  objeventos.Descripcion, objeventos.Dependencia, objeventos.Fecha_inicial, objeventos.Fecha_final, objeventos.Email_Res, objeventos.Email_Corres, objeventos.Concepto, objeventos.Status, objeventos.Nivel, objeventos.Ini_Matricula, objeventos.Autorizacion, objeventos.Eventos, objeventos.Tipo, Usuario, objeventos.Observaciones };
                
                String[] ParametrosOut = { "p_Bandera" };
                Cmd = CDDatos.GenerarOracleCommand("UPD_EVENTOS", ref Verificador, Parametros, Valores, ParametrosOut);
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
        public void EventoEditarStatus(ref Evento objeventos, ref string Verificador)
        {
            CD_Datos CDDatos = new CD_Datos("INGRESOS");
            OracleCommand Cmd = null;
            try
            {
                String[] Parametros = {  "p_status", "p_evento" };

                object[] Valores = { objeventos.Status, objeventos.Eventos };

                String[] ParametrosOut = { "p_Bandera" };
                Cmd = CDDatos.GenerarOracleCommand("UPD_EVENTOS_STATUS", ref Verificador, Parametros, Valores, ParametrosOut);
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
        public void ConsultarUnevento(ref Evento Objeventos, ref string Verificador)
        {
            CD_Datos CDDatos = new CD_Datos("INGRESOS");
            OracleCommand Cmd = null;
            try
            {
                string[] ParametrosIn = { "p_evento" };
                object[] Valores = { Objeventos.Eventos };
                string[] ParametrosOut ={"p_descripcion", "p_dependencia", "p_fecha_inicial", "p_fecha_final", "p_email_res", "p_email_corres", "p_concepto", "p_status","p_nivel", "p_ini_matricula", "p_autorizacion", "p_tipo", "p_usuario_solicita", "p_fecha_solicitud", "p_usuario_autoriza", "p_fecha_autorizacion", "p_observaciones", "p_bandera"};

                Cmd = CDDatos.GenerarOracleCommand("SEL_EVENTO", ref Verificador, ParametrosIn, Valores, ParametrosOut);
                if (Verificador == "0")
                {
                    Objeventos = new Evento ();
                    Objeventos.Eventos= Convert.ToString(Cmd.Parameters["p_evento"].Value);
                    Objeventos.Descripcion = Convert.ToString(Cmd.Parameters["p_descripcion"].Value);
                    Objeventos.Dependencia = Convert.ToString(Cmd.Parameters["p_dependencia"].Value);
                    Objeventos.Fecha_inicial = Convert.ToString(Cmd.Parameters["p_fecha_inicial"].Value);
                    Objeventos.Fecha_final = Convert.ToString(Cmd.Parameters["p_fecha_final"].Value);
                    Objeventos.Email_Res = Convert.ToString(Cmd.Parameters["p_email_res"].Value);
                    Objeventos.Email_Corres = Convert.ToString(Cmd.Parameters["p_email_corres"].Value);
                    Objeventos.Status= Convert.ToString(Cmd.Parameters["p_status"].Value);
                    Objeventos.Nivel = Convert.ToString(Cmd.Parameters["p_nivel"].Value);                    
                    Objeventos.Concepto = Convert.ToString(Cmd.Parameters["p_concepto"].Value);                    
                    Objeventos.Ini_Matricula = Convert.ToString(Cmd.Parameters["p_ini_matricula"].Value);
                    Objeventos.Autorizacion = Convert.ToString(Cmd.Parameters["p_autorizacion"].Value);
                    Objeventos.Tipo = Convert.ToString(Cmd.Parameters["p_tipo"].Value);
                    Objeventos.Usuario_Solicita = Convert.ToString(Cmd.Parameters["p_usuario_solicita"].Value);
                    Objeventos.Fecha_Solicitud = Convert.ToString(Cmd.Parameters["p_fecha_solicitud"].Value);
                    Objeventos.Usuario_Autoriza = Convert.ToString(Cmd.Parameters["p_usuario_autoriza"].Value);
                    Objeventos.Fecha_Autorizacion = Convert.ToString(Cmd.Parameters["p_fecha_autorizacion"].Value);
                    Objeventos.Observaciones = Convert.ToString(Cmd.Parameters["p_observaciones"].Value);
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
        public void ConsultarOficio(ref Evento Objeventos, ref string Verificador)
        {
            CD_Datos CDDatos = new CD_Datos("INGRESOS");
            OracleCommand Cmd = null;
            try
            {
                string[] ParametrosIn = { "p_evento" };
                object[] Valores = { Objeventos.Eventos };
                string[] ParametrosOut = { "P_NOMBRE_OFICIO", "P_FECHA", "P_NO_OFICIO", "P_FIRMA", "P_OBSERVACIONES", "p_bandera" };

                Cmd = CDDatos.GenerarOracleCommand("OBT_EVENTO_OFICIO", ref Verificador, ParametrosIn, Valores, ParametrosOut);
                if (Verificador == "0")
                {
                    Objeventos = new Evento();
                    Objeventos.Eventos = Convert.ToString(Cmd.Parameters["p_evento"].Value);
                    Objeventos.Oficio = Convert.ToString(Cmd.Parameters["P_NOMBRE_OFICIO"].Value);
                    Objeventos.FechaOficio = Convert.ToString(Cmd.Parameters["P_FECHA"].Value);
                    Objeventos.NoOficio = Convert.ToString(Cmd.Parameters["P_NO_OFICIO"].Value);
                    Objeventos.Firma = Convert.ToString(Cmd.Parameters["P_FIRMA"].Value);
                    Objeventos.Observaciones = Convert.ToString(Cmd.Parameters["P_OBSERVACIONES"].Value);
                  
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
        public void Eliminar_Concepto_evento(ref ConceptoCuotaLibre objConceptoCuotaLibre, ref string Verificador)
        {
            CD_Datos CDDatos = new CD_Datos("INGRESOS");
            OracleCommand Cmd = null;
            try
            {
                String[] Parametros = { "p_evento", "p_carrera", "p_id_concepto" };
                object[] Valores = { objConceptoCuotaLibre.Evento, objConceptoCuotaLibre.Carrera, objConceptoCuotaLibre.Id_Concepto };
                String[] ParametrosOut = { "p_Bandera" };

                Cmd = CDDatos.GenerarOracleCommand("DEL_CONCEPTO_EVENTO", ref Verificador, Parametros, Valores, ParametrosOut);

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
        public void Eliminar_Oficio(ref Evento Objeventos, ref string Verificador)
        {
            CD_Datos CDDatos = new CD_Datos("INGRESOS");
            OracleCommand Cmd = null;

            try
            {
                String[] Parametros = { "p_evento" };
                object[] Valores = { Objeventos.Eventos };
                String[] ParametrosOut = { "p_Bandera" };

                Cmd = CDDatos.GenerarOracleCommand("DEL_EVENTOS_OFICIO", ref Verificador, Parametros, Valores, ParametrosOut);

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
        public void Eliminar_Oficios(Evento Objeventos, ref string Verificador)
        {
            CD_Datos CDDatos = new CD_Datos("INGRESOS");
            OracleCommand Cmd = null;

            try
            {
                String[] Parametros = { "p_evento" };
                object[] Valores = { Objeventos.Eventos };
                String[] ParametrosOut = { "p_Bandera" };

                Cmd = CDDatos.GenerarOracleCommand("DEL_EVENTO_OFICIOS", ref Verificador, Parametros, Valores, ParametrosOut);

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
        public void Editar_VigenciaEvento(Evento Objeventos, ref string Verificador)
        {
            CD_Datos CDDatos = new CD_Datos("INGRESOS");
            OracleCommand Cmd = null;

            try
            {
                String[] Parametros = { "P_EVENTO", "P_FECHA_INICIAL", "P_FECHA_FINAL" };
                object[] Valores = { Objeventos.Eventos, Objeventos.Fecha_inicial, Objeventos.Fecha_final };
                String[] ParametrosOut = { "P_BANDERA" };

                Cmd = CDDatos.GenerarOracleCommand("UPD_VIGENCIA_EVENTO", ref Verificador, Parametros, Valores, ParametrosOut);

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
        public void ConsultarEventosRef(Evento Objeventos, string Usuario, string Status, string Reporte, ref List<Evento> List)
        {
            CD_Datos CDDatos = new CD_Datos("INGRESOS");
            OracleCommand cmm = null;
            try
            {

                OracleDataReader dr = null;
                String[] Parametros = { "p_dependencia", "p_usuario", "p_tipo_acceso", "p_status", "p_reporte" };
                Object[] Valores = { Objeventos.Dependencia, Usuario, Objeventos.Tipo, Status, Reporte };

                cmm = CDDatos.GenerarOracleCommandCursor("PKG_PAGOS_2016.Obt_Grid_Eventos", ref dr, Parametros, Valores);

                while (dr.Read())
                {
                    Objeventos = new Evento();
                    Objeventos.Dependencia = Convert.ToString(dr[1]);
                    Objeventos.Eventos = Convert.ToString(dr[0]);
                    Objeventos.Descripcion = Convert.ToString(dr[2]);
                    Objeventos.Fecha_inicial = Convert.ToString(dr[3]);
                    Objeventos.Fecha_final = Convert.ToString(dr[4]);
                    Objeventos.Ruta= Convert.ToString(dr[5]);
                    List.Add(Objeventos);
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
        public void ConsultarEventosTipoUsu(Evento Objeventos, string Usuario, string TipoUsuario, string Status, string Buscar, ref List<Evento> List)
        {
            CD_Datos CDDatos = new CD_Datos("INGRESOS");
            OracleCommand cmm = null;
            try
            {

                OracleDataReader dr = null;
                String[] Parametros = { "p_dependencia", "p_usuario", "p_tipo_acceso", "p_tipo_usuario", "p_status", "p_busca" };
                Object[] Valores = { Objeventos.Dependencia, Usuario, Objeventos.Tipo, TipoUsuario, Status, Buscar };

                cmm = CDDatos.GenerarOracleCommandCursor("PKG_PAGOS_2016.Obt_Grid_EventosUsu", ref dr, Parametros, Valores);

                while (dr.Read())
                {
                    Objeventos = new Evento();
                    Objeventos.Dependencia = Convert.ToString(dr[1]);
                    Objeventos.Eventos = Convert.ToString(dr[0]);
                    Objeventos.Descripcion = Convert.ToString(dr[2]);
                    Objeventos.Fecha_inicial = Convert.ToString(dr[3]);
                    Objeventos.Fecha_final = Convert.ToString(dr[4]);
                    Objeventos.TotPagados = Convert.ToInt32(dr[5]);
                    Objeventos.Id = Convert.ToInt32(dr[6]);
                    List.Add(Objeventos);
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
        public void ConsultarOficios(string Evento, ref List<Evento> List)
        {
            CD_Datos CDDatos = new CD_Datos("INGRESOS");
            OracleCommand cmm = null;
            Evento Objeventos;
            try
            {

                OracleDataReader dr = null;
                String[] Parametros = { "p_evento" };
                Object[] Valores = { Evento };
                //String[] ParametrosOut = {  };

                cmm = CDDatos.GenerarOracleCommandCursor("pkg_pagos_2016.Obt_Grid_Oficios_Eventos", ref dr, Parametros, Valores);

                while (dr.Read())
                {
                    Objeventos = new Evento();
                    Objeventos.Id = Convert.ToInt32(dr[0]);
                    Objeventos.NoOficio = Convert.ToString(dr[1]);
                    Objeventos.FechaOficio = Convert.ToString(dr[2]);
                    Objeventos.Firma = Convert.ToString(dr[3]);
                    Objeventos.Oficio = Convert.ToString(dr[4]);
                    Objeventos.Observaciones = Convert.ToString(dr[5]);
                    List.Add(Objeventos);
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
        public void ConsultarOficiosEvento(string Evento, ref List<Oficio> List)
        {
            CD_Datos CDDatos = new CD_Datos("INGRESOS");
            OracleCommand cmm = null;
            Oficio ObjOficio;
            try
            {

                OracleDataReader dr = null;
                String[] Parametros = { "p_evento" };
                Object[] Valores = { Evento };
                //String[] ParametrosOut = {  };

                cmm = CDDatos.GenerarOracleCommandCursor("pkg_pagos_2016.Obt_Grid_Oficios_Eventos", ref dr, Parametros, Valores);

                while (dr.Read())
                {
                    ObjOficio = new Oficio();
                    ObjOficio.NumOficio = Convert.ToString(dr[1]);
                    ObjOficio.FechaOficio = Convert.ToString(dr[2]);
                    ObjOficio.FirmaOficio = Convert.ToString(dr[3]);
                    ObjOficio.LinkArchivo= "~/Oficios/Eventos/" + Convert.ToString(dr[4]);
                    ObjOficio.NombreArchivo = Convert.ToString(dr[4]);
                    ObjOficio.Observaciones = Convert.ToString(dr[5]);
                    List.Add(ObjOficio);
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
        public void Insertar_TipoPersona(ConceptoCuotaLibre objParticipante, ref string Verificador)
        {
            
                CD_Datos CDDatos = new CD_Datos("INGRESOS");
                OracleCommand Cmd = null;
                try
                {
                    String[] Parametros = { "P_DESC_TIPO_PARTICIPANTE", "P_TIPO_PARTICIPANTE", "P_ES_PONENTE" };
                    object[] Valores = { objParticipante.Desc_Tipo_Participante, objParticipante.Tipo_Participante, objParticipante.Es_Ponente };
                    String[] ParametrosOut = { "P_BANDERA" };
                    Cmd = CDDatos.GenerarOracleCommand("INS_TIPO_PERSONA", ref Verificador, Parametros, Valores, ParametrosOut);
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
