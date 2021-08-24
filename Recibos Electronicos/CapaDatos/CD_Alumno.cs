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
    public class CD_Alumno
    {
        public void ConsultarCarrerasPosgrado(Alumno ObjAlumno, string Buscar, ref List<Alumno> List)
        {
            CD_Datos CDDatos = new CD_Datos("INGRESOS");
            OracleCommand cmm = null;
            try
            {
                OracleDataReader dr = null;

                string[] Parametros = { "p_dependencia",
                                        "p_nivel",
                                        "p_busca"};
                object[] Valores = { ObjAlumno.Dependencia, ObjAlumno.Nivel, Buscar };
                cmm = CDDatos.GenerarOracleCommandCursor("PKG_PAGOS_2016.Obt_Grid_PosgradosUnach", ref dr, Parametros, Valores);
                while (dr.Read())
                {
                    ObjAlumno = new Alumno();                    
                    ObjAlumno.Dependencia = Convert.ToString(dr.GetValue(1));
                    ObjAlumno.Carrera = Convert.ToString(dr.GetValue(2));
                    ObjAlumno.DescCarrera = Convert.ToString(dr.GetValue(3));                    
                    ObjAlumno.Nivel = Convert.ToString(dr.GetValue(4));                    
                    List.Add(ObjAlumno);
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
        public void ConsultarAlumnosUNACH(Alumno ObjAlumno, string Buscar, ref List<Alumno> List)
        {
            CD_Datos CDDatos = new CD_Datos("INGRESOS");
            OracleCommand cmm = null;
            try
            {
                OracleDataReader dr = null;

                string[] Parametros = { "p_tipo",
                                        "p_nivel",
                                        "p_busca",
                                        "p_dependencia",
                                        "p_ciclo"};
                object[] Valores = { ObjAlumno.TipoPersonaStr, ObjAlumno.Nivel, Buscar, ObjAlumno.Dependencia, ObjAlumno.CicloEscolar };
                cmm = CDDatos.GenerarOracleCommandCursor("PKG_PAGOS_2016.Obt_Grid_AlumnosUnach", ref dr, Parametros, Valores);
                string Ruta= "https://sysweb.unach.mx/FichaReferenciada/Form/Registro_Participantes.aspx";
                while (dr.Read())
                {
                    string EsquemaAlu = "SIAE";

                    ObjAlumno = new Alumno();
                    ObjAlumno.TipoPersonaStr = Convert.ToString(dr.GetValue(0));
                    ObjAlumno.Matricula = Convert.ToString(dr.GetValue(1));
                    ObjAlumno.Nombre = Convert.ToString(dr.GetValue(2));
                    ObjAlumno.Observaciones = Convert.ToString(dr.GetValue(3));
                    ObjAlumno.FechaNacimiento = Convert.ToString(dr.GetValue(4));
                    ObjAlumno.Dependencia = Convert.ToString(dr.GetValue(5));
                    ObjAlumno.DescCarrera = Convert.ToString(dr.GetValue(6));
                    ObjAlumno.CicloEscolar = Convert.ToString(dr.GetValue(7));
                    ObjAlumno.Nivel = Convert.ToString(dr.GetValue(8));
                    ObjAlumno.Semestre = Convert.ToString(dr.GetValue(9));
                    ObjAlumno.Correo = Convert.ToString(dr.GetValue(10));
                    ObjAlumno.Password = Convert.ToString(dr.GetValue(11));
                    if (ObjAlumno.TipoPersonaStr == "ALUMNO" && ObjAlumno.Nivel == "L" && ObjAlumno.Observaciones == "SAUCE")
                        Ruta = "https://siae.unach.mx/accesos/alumnos/?a=1&m=0";
                    else if (ObjAlumno.TipoPersonaStr == "ALUMNO" && (ObjAlumno.Nivel == "M" || ObjAlumno.Nivel == "D" || ObjAlumno.Nivel == "E") && ObjAlumno.Observaciones == "POSGRADO")
                        Ruta = "https://siae.unach.mx/posgrado/login/";
                    else if (ObjAlumno.TipoPersonaStr == "ASPIRANTE" && (ObjAlumno.Nivel == "M" || ObjAlumno.Nivel == "D" || ObjAlumno.Nivel == "E") && ObjAlumno.Observaciones == "POSGRADO")
                        Ruta = "https://siae.unach.mx/posgrado/aspirantes/";
                    else if (ObjAlumno.TipoPersonaStr == "ASPIRANTE" && ObjAlumno.Nivel == "L")
                        Ruta = "https://siae.unach.mx/inscripciones/";
                    else if (ObjAlumno.TipoPersonaStr == "ALUMNO LENGUAS " && ObjAlumno.Nivel == "N")
                        Ruta = "https://siae.unach.mx/acceso/?m=0&a=2";
                    else
                        EsquemaAlu = "SYSWEB";

                    ObjAlumno.LinkEsquema = Ruta;
                    ObjAlumno.Esquema = EsquemaAlu;
                    ObjAlumno.Correo_Instituicional = Convert.ToString(dr.GetValue(12));
                    List.Add(ObjAlumno);
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
        public void ConsultarAspirantesUNACH(Alumno ObjAlumno, string Buscar, string Origen, ref List<Alumno> List)
        {
            CD_Datos CDDatos = new CD_Datos("INGRESOS");
            OracleCommand cmm = null;
            try
            {
                OracleDataReader dr = null;

                string[] Parametros = { "p_tipo",
                                        "p_nivel",
                                        "p_busca",
                                        "p_dependencia",
                                        "p_ciclo", "p_origen"};
                object[] Valores = { ObjAlumno.TipoPersonaStr, ObjAlumno.Nivel, Buscar, ObjAlumno.Dependencia, ObjAlumno.CicloEscolar, Origen };
                cmm = CDDatos.GenerarOracleCommandCursor("PKG_PAGOS_2016.Obt_Grid_AspirantesUnach", ref dr, Parametros, Valores);
                string Ruta = "https://sysweb.unach.mx/FichaReferenciada/Form/Registro_Participantes.aspx";
                while (dr.Read())
                {
                    string EsquemaAlu = "ASPIRANTES";
                    ObjAlumno = new Alumno();
                    ObjAlumno.TipoPersonaStr = Convert.ToString(dr.GetValue(0));
                    ObjAlumno.Matricula = Convert.ToString(dr.GetValue(1));
                    ObjAlumno.Nombre = Convert.ToString(dr.GetValue(2));
                    ObjAlumno.Observaciones = Convert.ToString(dr.GetValue(3));
                    ObjAlumno.FechaNacimiento = Convert.ToString(dr.GetValue(4));
                    ObjAlumno.Dependencia = Convert.ToString(dr.GetValue(5));
                    ObjAlumno.DescCarrera = Convert.ToString(dr.GetValue(6));
                    ObjAlumno.CicloEscolar = Convert.ToString(dr.GetValue(7));
                    ObjAlumno.Nivel = Convert.ToString(dr.GetValue(8));
                    ObjAlumno.Semestre = Convert.ToString(dr.GetValue(9));
                    ObjAlumno.Correo = Convert.ToString(dr.GetValue(10));
                    ObjAlumno.Password = Convert.ToString(dr.GetValue(11));
                    if (ObjAlumno.TipoPersonaStr == "ALUMNO" && ObjAlumno.Nivel == "L" && ObjAlumno.Observaciones == "SAUCE")
                        Ruta = "http://siae.unach.mx/login/";
                    else if (ObjAlumno.TipoPersonaStr == "ALUMNO" && (ObjAlumno.Nivel == "M" || ObjAlumno.Nivel == "D" || ObjAlumno.Nivel == "E") && ObjAlumno.Observaciones == "POSGRADO")
                        Ruta = "http://siae.unach.mx/posgrado/login/";
                    else if (ObjAlumno.TipoPersonaStr == "ASPIRANTE" && (ObjAlumno.Nivel == "M" || ObjAlumno.Nivel == "D" || ObjAlumno.Nivel == "E") && ObjAlumno.Observaciones == "POSGRADO")
                        Ruta = "http://siae.unach.mx/posgrado/aspirantes/";
                    else if ((ObjAlumno.TipoPersonaStr == "ASPIRANTE" || ObjAlumno.TipoPersonaStr == "ACEPTADO" ) && ObjAlumno.Nivel == "L" && ObjAlumno.Observaciones == "ASPIRANTES")
                        Ruta = "https://aspirantes.unach.mx/";
                    else
                        EsquemaAlu = "SYSWEB";

                    ObjAlumno.LinkEsquema = Ruta;
                    ObjAlumno.Esquema = EsquemaAlu;

                    List.Add(ObjAlumno);
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

        public void ConsultarAlumno(ref Alumno ObjAlumno, ref string Verificador)
        {
            CD_Datos CDDatos = new CD_Datos("INGRESOS");
            OracleCommand Cmd = null;
            try
            {


                string[] ParametrosIn = { "p_matricula",
                                        "p_evento",
                                        "p_tipo_participante",
                                        "p_tipo",
                                        "p_nivel",
                                        "p_ciclo"

                };
                object[] Valores = {   ObjAlumno.Matricula,
                                       ObjAlumno.Evento,
                                       ObjAlumno.TipoPersona,
                                       "A",
                                       ObjAlumno.Nivel,
                                       ObjAlumno.CicloEscolar
            };
                string[] ParametrosOut ={
                                         "p_nombre",
                                          "p_appat",
                                          "p_apmat",
                                          "p_sexo" ,
                                          "p_email",
                                          "p_escuela",
                                          "p_carrera",
                                          "p_semestre",
                                          "p_grupo",
                                          "p_Bandera",
                                          "p_desc_escuela",
                                          "p_desc_carrera",
                                          "p_status",
                                          "p_fecha_nacimiento",
                                          "p_genero"
                };

                //Cmd = CDDatos.GenerarOracleCommand("OBT_INTERNOS", ref Verificador, ParametrosIn, Valores, ParametrosOut);
                Cmd = CDDatos.GenerarOracleCommand("OBT_ALUMNO", ref Verificador, ParametrosIn, Valores, ParametrosOut);
                if (Verificador == "0")
                {
                    ObjAlumno = new Alumno();

                    ObjAlumno.Dependencia = Convert.ToString(Cmd.Parameters["p_escuela"].Value);
                    ObjAlumno.Carrera = Convert.ToString(Cmd.Parameters["p_carrera"].Value);
                    ObjAlumno.Semestre = Convert.ToString(Cmd.Parameters["p_semestre"].Value);
                    ObjAlumno.Grupo = Convert.ToString(Cmd.Parameters["p_grupo"].Value);
                    ObjAlumno.Correo = Convert.ToString(Cmd.Parameters["p_email"].Value);
                    ObjAlumno.Constancia = Convert.ToString(Cmd.Parameters["p_nombre"].Value);
                    ObjAlumno.Nombre = Convert.ToString(Cmd.Parameters["p_nombre"].Value);
                    ObjAlumno.APaterno = Convert.ToString(Cmd.Parameters["p_appat"].Value);
                    ObjAlumno.AMaterno = Convert.ToString(Cmd.Parameters["p_apmat"].Value);
                    ObjAlumno.Genero = Convert.ToChar(Cmd.Parameters["p_sexo"].Value);
                    ObjAlumno.DescEscuela = Convert.ToString(Cmd.Parameters["p_desc_escuela"].Value);
                    ObjAlumno.DescCarrera = Convert.ToString(Cmd.Parameters["p_desc_carrera"].Value);
                    ObjAlumno.StatusMatricula = Convert.ToString(Cmd.Parameters["p_status"].Value);
                    ObjAlumno.FechaNacimiento = Convert.ToString(Cmd.Parameters["p_fecha_nacimiento"].Value);
                    ObjAlumno.Genero = Convert.ToChar(Cmd.Parameters["p_genero"].Value);

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
        public void ConsultarDatosAlumno(ref Alumno ObjAlumno, ref string Verificador)
        {
            CD_Datos CDDatos = new CD_Datos("INGRESOS");
            OracleCommand Cmd = null;
            try
            {


                string[] ParametrosIn = { "p_matricula",
                                        "p_evento",
                                        "p_tipo_participante",
                                        "p_tipo",
                                        "p_nivel"

                };
                object[] Valores = {   ObjAlumno.Matricula,
                                       ObjAlumno.Evento,
                                       ObjAlumno.TipoPersona,
                                       "A",
                                       ObjAlumno.Nivel
            };
                string[] ParametrosOut ={
                                         "p_nombre",
                                          "p_appat",
                                          "p_apmat",
                                          "p_sexo" ,
                                          "p_email",
                                          "p_escuela",
                                          "p_carrera",
                                          "p_semestre",
                                          "p_grupo",
                                          "p_Bandera",
                                          "p_desc_escuela",
                                          "p_desc_carrera",
                                          "p_status",
                                          "p_fecha_nacimiento",
                                          "p_genero"
                };

                //Cmd = CDDatos.GenerarOracleCommand("OBT_INTERNOS", ref Verificador, ParametrosIn, Valores, ParametrosOut);
                Cmd = CDDatos.GenerarOracleCommand("OBT_DATOS_ALUMNO2017", ref Verificador, ParametrosIn, Valores, ParametrosOut);
                if (Verificador == "0")
                {
                    ObjAlumno = new Alumno();

                    ObjAlumno.Dependencia = Convert.ToString(Cmd.Parameters["p_escuela"].Value);
                    ObjAlumno.Carrera = Convert.ToString(Cmd.Parameters["p_carrera"].Value);
                    ObjAlumno.Semestre = Convert.ToString(Cmd.Parameters["p_semestre"].Value);
                    ObjAlumno.Grupo = Convert.ToString(Cmd.Parameters["p_grupo"].Value);
                    ObjAlumno.Correo = Convert.ToString(Cmd.Parameters["p_email"].Value);
                    ObjAlumno.Constancia = Convert.ToString(Cmd.Parameters["p_nombre"].Value);
                    ObjAlumno.Nombre = Convert.ToString(Cmd.Parameters["p_nombre"].Value);
                    ObjAlumno.APaterno = Convert.ToString(Cmd.Parameters["p_appat"].Value);
                    ObjAlumno.AMaterno = Convert.ToString(Cmd.Parameters["p_apmat"].Value);
                    ObjAlumno.Genero = Convert.ToChar(Cmd.Parameters["p_sexo"].Value);
                    ObjAlumno.DescEscuela = Convert.ToString(Cmd.Parameters["p_desc_escuela"].Value);
                    ObjAlumno.DescCarrera = Convert.ToString(Cmd.Parameters["p_desc_carrera"].Value);
                    ObjAlumno.StatusMatricula = Convert.ToString(Cmd.Parameters["p_status"].Value);
                    ObjAlumno.FechaNacimiento = Convert.ToString(Cmd.Parameters["p_fecha_nacimiento"].Value);
                    ObjAlumno.Genero = Convert.ToChar(Cmd.Parameters["p_genero"].Value);

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

        public void ConsultarCatClientes(ref Alumno ObjCliente, string Buscar, ref List<Alumno> List)
        {
            CD_Datos CDDatos = new CD_Datos("INGRESOS");
            OracleCommand cmm = null;
            try
            {
                OracleDataReader dr = null;

                string[] Parametros = { "p_dependencia",
                                        "p_Busqueda"};
                object[] Valores = { ObjCliente.Dependencia, Buscar };
                cmm = CDDatos.GenerarOracleCommandCursor("PKG_PAGOS_2016.Obt_Grid_Cat_Clientes", ref dr, Parametros, Valores);
                while (dr.Read())
                {
                    ObjCliente = new Alumno();
                    ObjCliente.Matricula = Convert.ToString(dr.GetValue(0));
                    ObjCliente.Nombre = Convert.ToString(dr.GetValue(1));
                    ObjCliente.Nivel = Convert.ToString(dr.GetValue(2));
                    ObjCliente.Esquema = Convert.ToString(dr.GetValue(3));
                    List.Add(ObjCliente);
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

        public void ConsultarCliente(ref Alumno ObjCliente, ref string Verificador)
        {
            CD_Datos CDDatos = new CD_Datos("INGRESOS");
            OracleCommand Cmd = null;
            try
            {


                string[] ParametrosIn = { "P_NUM_CLIENTE",
                                        "P_DEPENDENCIA"};
                object[] Valores = {   ObjCliente.Matricula,
                                       ObjCliente.Dependencia
            };
                string[] ParametrosOut ={
                                         "P_NOMBRE",
                                          "P_APPAT",
                                          "P_APMAT",
                                          "P_BANDERA"
                };

                //Cmd = CDDatos.GenerarOracleCommand("OBT_INTERNOS", ref Verificador, ParametrosIn, Valores, ParametrosOut);
                Cmd = CDDatos.GenerarOracleCommand("OBT_DATOS_CLIENTE", ref Verificador, ParametrosIn, Valores, ParametrosOut);
                if (Verificador == "0")
                {
                    ObjCliente = new Alumno();                    
                    ObjCliente.Nombre = Convert.ToString(Cmd.Parameters["p_nombre"].Value);
                    ObjCliente.APaterno = Convert.ToString(Cmd.Parameters["p_appat"].Value);
                    ObjCliente.AMaterno = Convert.ToString(Cmd.Parameters["p_apmat"].Value);
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

        public void ConsultarEmpleadoMatricula(ref Alumno ObjEmpleado, string Matricula, ref string Verificador)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand Cmd = null;
            try
            {


                string[] ParametrosIn = { "P_MATRICULA" };
                object[] Valores = { Matricula };
                string[] ParametrosOut ={
                                         "P_ID_EMPLEADO",
                                         "P_ID_UR",
                                         "P_TIPO_PERSONAL",
                                         "P_ID_FAMILIAR",
                                         "P_BANDERA"
                };

                //Cmd = CDDatos.GenerarOracleCommand("OBT_INTERNOS", ref Verificador, ParametrosIn, Valores, ParametrosOut);
                Cmd = CDDatos.GenerarOracleCommand("OBT_DATOS_EMPLEADO", ref Verificador, ParametrosIn, Valores, ParametrosOut);
                if (Verificador == "0")
                {
                    ObjEmpleado = new Alumno();
                    ObjEmpleado.IdEmpleado= Convert.ToInt32(Cmd.Parameters["P_ID_EMPLEADO"].Value);
                    ObjEmpleado.Dependencia = Convert.ToString(Cmd.Parameters["P_ID_UR"].Value);
                    ObjEmpleado.TipoPersonaStr = Convert.ToString(Cmd.Parameters["P_TIPO_PERSONAL"].Value);
                    ObjEmpleado.IdFamiliar = Convert.ToInt32(Cmd.Parameters["P_ID_FAMILIAR"].Value);
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
        public void ConsultarAlumnoSel(ref Alumno ObjAlumno, ref string Verificador)
        {
            CD_Datos CDDatos = new CD_Datos("INGRESOS");
            OracleCommand Cmd = null;
            try
            {


                string[] ParametrosIn = { /*"p_matricula","p_dependencia","p_nivel",*/
                                         "p_id"};
                object[] Valores = {   /*ObjAlumno.Matricula,ObjAlumno.Dependencia,ObjAlumno.Nivel,*/
                                       ObjAlumno.IdPersona
            };
                string[] ParametrosOut ={
                                          "p_nombre",
                                          "p_paterno",
                                          "p_materno",
                                          "p_dependencia",
                                          "p_carrera",
                                          "p_semestre",
                                          "p_grupo",
                                          "p_status",
                                          "p_Bandera",
                                          "p_id_carrera",
                                          "p_sexo",
                                          "p_email",
                                          "p_nivel"
                };

                Cmd = CDDatos.GenerarOracleCommand("SEL_ALUMNO_POSGRADO_2016", ref Verificador, ParametrosIn, Valores, ParametrosOut);
                if (Verificador == "0")
                {
                    ObjAlumno = new Alumno();
                    ObjAlumno.Dependencia = Convert.ToString(Cmd.Parameters["p_dependencia"].Value);
                    ObjAlumno.Carrera = Convert.ToString(Cmd.Parameters["p_id_carrera"].Value);
                    ObjAlumno.DescCarrera = Convert.ToString(Cmd.Parameters["p_carrera"].Value);
                    ObjAlumno.Semestre = Convert.ToString(Cmd.Parameters["p_semestre"].Value);
                    ObjAlumno.Grupo = Convert.ToString(Cmd.Parameters["p_grupo"].Value);
                    ObjAlumno.Nombre = Convert.ToString(Cmd.Parameters["p_nombre"].Value);
                    ObjAlumno.APaterno = Convert.ToString(Cmd.Parameters["p_paterno"].Value);
                    ObjAlumno.AMaterno = Convert.ToString(Cmd.Parameters["p_materno"].Value);
                    ObjAlumno.StatusMatricula = Convert.ToString(Cmd.Parameters["p_status"].Value);
                    ObjAlumno.Correo = Convert.ToString(Cmd.Parameters["p_email"].Value);
                    ObjAlumno.Genero = Convert.ToChar(Cmd.Parameters["p_sexo"].Value);
                    ObjAlumno.Nivel = Convert.ToString(Cmd.Parameters["p_nivel"].Value);

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
        public void ConsultarAlumnoStatus(ref Alumno ObjAlumno, ref List<Alumno> List)
        {
            CD_Datos CDDatos = new CD_Datos("INGRESOS");
            OracleCommand cmm = null;
            try
            {
                OracleDataReader dr = null;

                string[] Parametros = { "P_Matricula" };
                object[] Valores = { ObjAlumno.Matricula };
                cmm = CDDatos.GenerarOracleCommandCursor("PKG_PAGOS_2016.Obt_Grid_Status_Alumno", ref dr, Parametros, Valores);
                while (dr.Read())
                {
                    ObjAlumno = new Alumno();
                    ObjAlumno.StatusMatricula = Convert.ToString(dr.GetValue(0));
                    ObjAlumno.Semestre = Convert.ToString(dr.GetValue(1));
                    ObjAlumno.CicloEscolar = Convert.ToString(dr.GetValue(2));
                    List.Add(ObjAlumno);

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

        public void ConsultarAlumno(ref Alumno ObjAlumno, string Busqueda, ref List<Alumno> List)
        {
            CD_Datos CDDatos = new CD_Datos("INGRESOS");
            OracleCommand cmm = null;
            try
            {
                OracleDataReader dr = null;

                string[] Parametros = { "p_Dependencia",
                                        "p_Nivel","p_Carrera","p_Status","p_Busca"};
                object[] Valores = { ObjAlumno.Dependencia,
                                   ObjAlumno.Nivel,ObjAlumno.Carrera,ObjAlumno.StatusMatricula,Busqueda};
                cmm = CDDatos.GenerarOracleCommandCursor("PKG_PAGOS_2016.Obt_Grid_Alumnos_Posgrado", ref dr, Parametros, Valores);
                while (dr.Read())
                {
                    ObjAlumno = new Alumno();
                    ObjAlumno.IdPersona = Convert.ToInt32(dr.GetValue(7));
                    ObjAlumno.Matricula = Convert.ToString(dr.GetValue(0));
                    ObjAlumno.Nombre = Convert.ToString(dr.GetValue(1));
                    ObjAlumno.DescCarrera = Convert.ToString(dr.GetValue(2));
                    ObjAlumno.Carrera = Convert.ToString(dr.GetValue(6));
                    ObjAlumno.Semestre = Convert.ToString(dr.GetValue(3));
                    ObjAlumno.Grupo = Convert.ToString(dr.GetValue(4));
                    ObjAlumno.StatusMatricula = Convert.ToString(dr.GetValue(5));
                    ObjAlumno.ImageStatusMatricula = "../Imagenes/" + Convert.ToString(dr.GetValue(5)) + ".PNG";
                    ObjAlumno.Dependencia = Convert.ToString(dr.GetValue(8));
                    ObjAlumno.Nivel = Convert.ToString(dr.GetValue(9));
                    List.Add(ObjAlumno);

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
        public void AlumnoEditar(ref Alumno ObjAlumno, ref string Verificador)
        {
            CD_Datos CDDatos = new CD_Datos("INGRESOS");
            OracleCommand Cmd = null;
            try
            {
                String[] Parametros = { "p_matricula", "p_dependencia", "p_nivel", "p_nombre", "p_paterno", "p_materno", "p_carrera",
                                        "p_id_carrera", "p_semestre", "p_grupo","p_status", "p_usuario","p_sexo",
                                        "p_email", "p_id" };
                object[] Valores = { ObjAlumno.Matricula, ObjAlumno.Dependencia, ObjAlumno.Nivel, ObjAlumno.Nombre, ObjAlumno.APaterno, ObjAlumno.AMaterno, ObjAlumno.DescCarrera,
                                     ObjAlumno.Carrera, ObjAlumno.Semestre, ObjAlumno.Grupo, ObjAlumno.StatusMatricula, ObjAlumno.UsuNombre, ObjAlumno.Genero, ObjAlumno.Correo, ObjAlumno.IdPersona };
                String[] ParametrosOut = { "p_Bandera" };
                Cmd = CDDatos.GenerarOracleCommand("UPD_ALUMNO_POSGRADO_2016", ref Verificador, Parametros, Valores, ParametrosOut);
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
        public void AlumnoInsertar(ref Alumno ObjAlumno, ref string Verificador)
        {
            CD_Datos CDDatos = new CD_Datos("INGRESOS");
            OracleCommand Cmd = null;
            try
            {
                String[] Parametros = { "p_matricula", "p_dependencia", "p_nivel", "p_nombre", "p_paterno", "p_materno", "p_carrera",
                                        "p_id_carrera", "p_semestre", "p_grupo", "p_usuario","p_sexo",
                                        "p_email", "p_status" };
                object[] Valores = { ObjAlumno.Matricula, ObjAlumno.Dependencia, ObjAlumno.Nivel, ObjAlumno.Nombre, ObjAlumno.APaterno, ObjAlumno.AMaterno, ObjAlumno.DescCarrera,
                                     ObjAlumno.Carrera, ObjAlumno.Semestre, ObjAlumno.Grupo, ObjAlumno.UsuNombre, ObjAlumno.Genero, ObjAlumno.Correo, ObjAlumno.StatusMatricula };
                String[] ParametrosOut = { "p_Bandera", "p_matricula_generada" };

                Cmd = CDDatos.GenerarOracleCommand("INS_ALUMNO_POSGRADO_2016", ref Verificador, Parametros, Valores, ParametrosOut);

                ObjAlumno.Matricula = Convert.ToString(Cmd.Parameters["p_matricula_generada"].Value);
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
        public void AlumnoEliminar(ref Alumno ObjAlumno, ref string Verificador)
        {
            CD_Datos CDDatos = new CD_Datos("INGRESOS");
            OracleCommand Cmd = null;
            try
            {
                String[] Parametros = { "P_ID_ALUMNO" };
                object[] Valores = { ObjAlumno.IdPersona};
                String[] ParametrosOut = { "p_Bandera"};

                Cmd = CDDatos.GenerarOracleCommand("DEL_ALUMNO_POSGRADO", ref Verificador, Parametros, Valores, ParametrosOut);
                
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
        public void ConsultarAlumnoDescuento(ref Alumno ObjAlumno, string Clasificacion, string Referencia, ref List<Alumno> List)
        {
            CD_Datos CDDatos = new CD_Datos("INGRESOS");
            OracleCommand cmm = null;
            try
            {
                OracleDataReader dr = null;

                string[] Parametros = { 
                                      "p_dependencia",
                                      "p_ciclo_escolar",
                                      "p_status",
                                      "p_referencia",
                                      "p_nivel",
                                      "p_clasificacion"
                                      };
                object[] Valores = { ObjAlumno.Dependencia,
                                    ObjAlumno.CicloEscolar,
                                    ObjAlumno.StatusMatricula,
                                    Referencia,
                                    ObjAlumno.Nivel,
                                    Clasificacion
                                   };
                cmm = CDDatos.GenerarOracleCommandCursor("pkg_pagos_2016.Obt_Grid_Descuentos", ref dr, Parametros, Valores);
                while (dr.Read())
                {
                    ObjAlumno = new Alumno();
                    ObjAlumno.IdPersona = Convert.ToInt32(dr.GetValue(0));
                    ObjAlumno.Matricula = Convert.ToString(dr.GetValue(1));
                    ObjAlumno.Nombre = Convert.ToString(dr.GetValue(2));
                    ObjAlumno.Carrera = Convert.ToString(dr.GetValue(3));
                    ObjAlumno.TipoDescuento = Convert.ToString(dr.GetValue(4));
                    ObjAlumno.StatusMatricula = Convert.ToString(dr.GetValue(5));
                    ObjAlumno.Referencia = Convert.ToString(dr.GetValue(6));
                    ObjAlumno.CicloEscolar = Convert.ToString(dr.GetValue(7));
                    ObjAlumno.PorcentajeDescuento = Convert.ToString(dr.GetValue(12));
                    ObjAlumno.OficioTiene = Convert.ToString(dr.GetValue(13))!="0"?"1":"0";
                    ObjAlumno.registro.Habil = (ObjAlumno.Referencia.Length > 0) ? true : false;
                    ObjAlumno.registro.Inhabil = (ObjAlumno.Referencia.Length == 0) ? true : false;
                    if (dr.GetValue(8).ToString() == "X")
                    {
                        ObjAlumno.GenerarRecibo = true;
                        ObjAlumno.GenerarPermiso = false;
                    }
                    else if (dr.GetValue(8).ToString() == "S")
                    {
                        ObjAlumno.GenerarRecibo = false;
                        ObjAlumno.GenerarPermiso = true;
                    }
                    else
                    {
                        ObjAlumno.GenerarRecibo = false;
                        ObjAlumno.GenerarPermiso = false;
                    }
                    ObjAlumno.Dependencia = Convert.ToString(dr.GetValue(9));
                    ObjAlumno.ConceptoDescuento = Convert.ToString(dr.GetValue(10));
                    ObjAlumno.Nivel = Convert.ToString(dr.GetValue(14));
                    ObjAlumno.Observaciones = Convert.ToString(dr.GetValue(15));
                    //ObjAlumno.SolicitoFecha = Convert.ToString(dr.GetValue(16));
                    ObjAlumno.registro.EtiquetaSiete = Convert.ToString(dr.GetValue(16)); //Para saber si tiene asociado un familiar
                    ObjAlumno.registro.EtiquetaSeis = Convert.ToString(dr.GetValue(17)); //Para saber si tiene asociado un familiar
                    ObjAlumno.CicloAlu= Convert.ToString(dr.GetValue(18));
                    List.Add(ObjAlumno);

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
        public void ConsultarAlumnoDescuento(ref Alumno ObjAlumno, ref string Verificador)
        {
            CD_Datos CDDatos = new CD_Datos("INGRESOS");
            OracleCommand Cmd = null;
            try
            {


                string[] ParametrosIn = { "p_id_descuento"};
                object[] Valores = {  ObjAlumno.IdPersona
            };
                string[] ParametrosOut ={
                                         "p_dependencia", "p_ciclo_escolar", "p_matricula", "p_nivel", "p_nombre", "p_paterno", "p_materno", "P_evento",
                                        "p_carrera", "p_status","p_semestre", "p_grupo", "p_clave_concepto", "p_porcentaje", 
                                        "p_oficio_solicitud", "p_oficio_fecha", "P_oficio_firma", "P_tipo", "p_vigencia_inicial", "p_vigencia_final", "p_captura_fecha",
                                        "p_captura_usuario", "p_autoriza_fecha","p_autoriza_usuario","p_recibo_fecha", "p_recibo_usuario", "p_notas", "p_oficio_ruta", "p_oficio_id", "P_IDCARRERA","p_clasificacion", "P_ID_EMPLEADO", "P_ID_FAMILIAR", "P_OFICIO_SOLICITA","P_CICLO_ALUM","p_BANDERA"
                };

                Cmd = CDDatos.GenerarOracleCommand("SEL_DESCUENTOS_2016", ref Verificador, ParametrosIn, Valores, ParametrosOut);
                if (Verificador == "0")
                {
                    ObjAlumno = new Alumno();

                    ObjAlumno.Matricula = Convert.ToString(Cmd.Parameters["p_matricula"].Value);
                    ObjAlumno.Dependencia = Convert.ToString(Cmd.Parameters["p_dependencia"].Value);
                    ObjAlumno.CicloEscolar = Convert.ToString(Cmd.Parameters["p_ciclo_escolar"].Value);
                    ObjAlumno.CicloAlu= Convert.ToString(Cmd.Parameters["P_CICLO_ALUM"].Value); 
                    ObjAlumno.Nivel = Convert.ToString(Cmd.Parameters["p_nivel"].Value);
                    ObjAlumno.DescCarrera = Convert.ToString(Cmd.Parameters["p_carrera"].Value);
                    ObjAlumno.Semestre = Convert.ToString(Cmd.Parameters["p_semestre"].Value);
                    ObjAlumno.Grupo = Convert.ToString(Cmd.Parameters["p_grupo"].Value);
                    ObjAlumno.Nombre = Convert.ToString(Cmd.Parameters["p_nombre"].Value);
                    ObjAlumno.APaterno = Convert.ToString(Cmd.Parameters["p_paterno"].Value);
                    ObjAlumno.AMaterno = Convert.ToString(Cmd.Parameters["p_materno"].Value);
                    ObjAlumno.StatusMatricula = Convert.ToString(Cmd.Parameters["p_status"].Value);
                    ObjAlumno.Evento = Convert.ToString(Cmd.Parameters["p_evento"].Value);
                    ObjAlumno.ConceptoDescuento = Convert.ToString(Cmd.Parameters["p_clave_concepto"].Value);
                    ObjAlumno.PorcentajeDescuento = Convert.ToString(Cmd.Parameters["p_porcentaje"].Value);
                    ObjAlumno.OficioSolicito = Convert.ToString(Cmd.Parameters["p_oficio_solicitud"].Value);
                    ObjAlumno.OficioFirma = Convert.ToString(Cmd.Parameters["p_oficio_Firma"].Value);
                    ObjAlumno.OficioFecha = Convert.ToString(Cmd.Parameters["p_oficio_fecha"].Value);
                    ObjAlumno.TipoDescuento = Convert.ToString(Cmd.Parameters["P_tipo"].Value);
                    ObjAlumno.Observaciones = Convert.ToString(Cmd.Parameters["p_notas"].Value);
                    ObjAlumno.FechaInicial = Convert.ToString(Cmd.Parameters["p_vigencia_inicial"].Value);
                    ObjAlumno.FechaFinal = Convert.ToString(Cmd.Parameters["p_vigencia_final"].Value);
                    ObjAlumno.SolicitoFecha = Convert.ToString(Cmd.Parameters["p_captura_fecha"].Value);
                    ObjAlumno.SolicitoNombre = Convert.ToString(Cmd.Parameters["p_captura_usuario"].Value);
                    ObjAlumno.AutorizoFecha = Convert.ToString(Cmd.Parameters["p_autoriza_fecha"].Value);
                    ObjAlumno.AutorizoNombre = Convert.ToString(Cmd.Parameters["p_autoriza_usuario"].Value);
                    ObjAlumno.GeneroFecha = Convert.ToString(Cmd.Parameters["p_recibo_fecha"].Value);
                    ObjAlumno.GeneroNombre = Convert.ToString(Cmd.Parameters["p_recibo_usuario"].Value);
                    //ObjAlumno.OficioRuta = Convert.ToString(Cmd.Parameters["p_oficio_ruta"].Value);
                    ObjAlumno.oficio.IdOficio = Convert.ToInt32(Cmd.Parameters["p_oficio_id"].Value);
                    ObjAlumno.Carrera= Convert.ToString(Cmd.Parameters["P_IDCARRERA"].Value); 
                    ObjAlumno.SubTipoDescuento = Convert.ToString(Cmd.Parameters["p_clasificacion"].Value);
                    ObjAlumno.IdEmpleado = Convert.ToInt32(Cmd.Parameters["P_ID_EMPLEADO"].Value);
                    ObjAlumno.IdFamiliar = Convert.ToInt32(Cmd.Parameters["P_ID_FAMILIAR"].Value);
                    ObjAlumno.OficioQuienSolicita= Convert.ToString(Cmd.Parameters["P_OFICIO_SOLICITA"].Value);
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
        public void ConsultarDescuentoAutomatico(Alumno ObjAlumno, ref List<Alumno> List)
        {
            CD_Datos CDDatos = new CD_Datos("INGRESOS");
            OracleCommand cmm = null;
            try
            {
                OracleDataReader dr = null;

                string[] Parametros = { "p_dependencia", "p_ciclo_escolar", "p_status",
                "p_referencia", "p_nivel", "p_clasificacion", "p_tipo"};
                object[] Valores = { ObjAlumno.Dependencia, ObjAlumno.CicloEscolar, ObjAlumno.StatusMatricula, "", ObjAlumno.Nivel, "T", ObjAlumno.TipoDescuento };
                cmm = CDDatos.GenerarOracleCommandCursor("PKG_PAGOS_2016.Obt_Grid_Desc_Auto", ref dr, Parametros, Valores);
                while (dr.Read())
                {
                    ObjAlumno = new Alumno();
                    ObjAlumno.Matricula = Convert.ToString(dr.GetValue(1));
                    ObjAlumno.Nombre = Convert.ToString(dr.GetValue(2));
                    ObjAlumno.CicloEscolar = Convert.ToString(dr.GetValue(6));
                    ObjAlumno.Nivel = Convert.ToString(dr.GetValue(7));
                    ObjAlumno.DescCarrera = Convert.ToString(dr.GetValue(3));
                    ObjAlumno.TipoDescuento = Convert.ToString(dr.GetValue(4));
                    ObjAlumno.StatusMatricula = Convert.ToString(dr.GetValue(5));
                    List.Add(ObjAlumno);
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

        public void ConsultarStatusDescuento(ref Alumno ObjAlumno, string Usuario, ref List<Alumno> List)
        {
            CD_Datos CDDatos = new CD_Datos("INGRESOS");
            OracleCommand cmm = null;
            try
            {
                OracleDataReader dr = null;
                String[] Parametros = { "p_usuario" };
                String[] Valores = { Usuario };

                cmm = CDDatos.GenerarOracleCommandCursor("PKG_PAGOS_2016.Obt_Grid_Status_Descuentos", ref dr, Parametros, Valores);

                while (dr.Read())
                {
                    ObjAlumno = new Alumno();
                    ObjAlumno.Dependencia = Convert.ToString(dr.GetValue(0));
                    ObjAlumno.TotalMatricula = Convert.ToInt32(dr.GetValue(1));
                    List.Add(ObjAlumno);
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
        public void AlumnoEditarDescuentoOld(ref Alumno ObjAlumno, ref string Verificador)
        {
            CD_Datos CDDatos = new CD_Datos("INGRESOS");
            OracleCommand Cmd = null;
            try
            {
                String[] Parametros = { "P_ID_DESCUENTO", "P_DEPENDENCIA", "P_CICLO_ESCOLAR", "P_MATRICULA", "P_NOMBRE","P_PATERNO","P_MATERNO",
                                        "P_CARRERA", "P_IDCARRERA", "P_SEMESTRE", "P_GRUPO", "P_NIVEL",
                                        "P_STATUS", "P_EVENTO", "P_CLAVE_CONCEPTO", "P_PORCENTAJE", "P_OFICIO_SOLICITUD",
                                        "P_OFICIO_FIRMA", "P_OFICIO_FECHA", "P_ID_TIPO_DESCUENTO", "P_NOTAS", "P_USUARIO",
                                        "P_VIGENCIA_INICIAL", "P_VIGENCIA_FINAL", "P_QUIEN_SOLICITA"
                                      };
                object[] Valores = { ObjAlumno.IdPersona, ObjAlumno.Dependencia, ObjAlumno.CicloEscolar,ObjAlumno.Matricula, ObjAlumno.Nombre,ObjAlumno.APaterno,ObjAlumno.AMaterno,
                                     ObjAlumno.DescCarrera,ObjAlumno.Carrera, ObjAlumno.Semestre, ObjAlumno.Grupo, ObjAlumno.Nivel,
                                     ObjAlumno.StatusMatricula, ObjAlumno.Evento,  ObjAlumno.ConceptoDescuento, ObjAlumno.PorcentajeDescuento, ObjAlumno.OficioSolicito,
                                     ObjAlumno.OficioFirma, ObjAlumno.OficioFecha, ObjAlumno.TipoDescuento, ObjAlumno.Observaciones, ObjAlumno.UsuNombre,
                                     ObjAlumno.FechaInicial, ObjAlumno.FechaFinal, ObjAlumno.OficioQuienSolicita
                                   };
                String[] ParametrosOut = { "p_Bandera" };

                Cmd = CDDatos.GenerarOracleCommand("UPD_DESCUENTOS_2016", ref Verificador, Parametros, Valores, ParametrosOut);
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
        public void AlumnoEditarDescuento(ref Alumno ObjAlumno, ref string Verificador)
        {
            CD_Datos CDDatos = new CD_Datos("INGRESOS");
            OracleCommand Cmd = null;
            try
            {
                String[] Parametros = { "P_ID_DESCUENTO", "P_DEPENDENCIA", "P_CICLO_ESCOLAR", "P_MATRICULA", "P_NOMBRE","P_PATERNO","P_MATERNO",
                                        "P_CARRERA", "P_IDCARRERA", "P_SEMESTRE", "P_GRUPO", "P_NIVEL",
                                        "P_STATUS", "P_EVENTO", "P_CLAVE_CONCEPTO", "P_PORCENTAJE", "P_OFICIO_SOLICITUD",
                                        "P_OFICIO_FIRMA", "P_OFICIO_FECHA", "P_ID_TIPO_DESCUENTO", "P_NOTAS", "P_USUARIO",
                                        "P_VIGENCIA_INICIAL", "P_VIGENCIA_FINAL", "P_ASOCIADO", "P_ID_FAMILIAR", "P_ADSCRIPCION", "P_PLAZA", "P_TIPO_PERSONAL", "P_PARENTESCO",
                                        "P_FECHA_NACIMIENTO", "P_GENERO", "P_ID_EMPLEADO", "P_QUIEN_SOLICITA", "P_CICLO_ALUM"
                                      };
                object[] Valores = { ObjAlumno.IdPersona, ObjAlumno.Dependencia, ObjAlumno.CicloEscolar,ObjAlumno.Matricula, ObjAlumno.Nombre,ObjAlumno.APaterno,ObjAlumno.AMaterno,
                                     ObjAlumno.DescCarrera,ObjAlumno.Carrera, ObjAlumno.Semestre, ObjAlumno.Grupo, ObjAlumno.Nivel,
                                     ObjAlumno.StatusMatricula, ObjAlumno.Evento,  ObjAlumno.ConceptoDescuento, ObjAlumno.PorcentajeDescuento, ObjAlumno.OficioSolicito,
                                     ObjAlumno.OficioFirma, ObjAlumno.OficioFecha, ObjAlumno.TipoDescuento, ObjAlumno.Observaciones, ObjAlumno.UsuNombre,
                                     ObjAlumno.FechaInicial, ObjAlumno.FechaFinal, ObjAlumno.NombreEmpleado, ObjAlumno.IdFamiliar, ObjAlumno.Adscripcion, ObjAlumno.NoControl, ObjAlumno.TipoPersonaStr, ObjAlumno.Parentesco,
                                     ObjAlumno.FechaNacimiento, ObjAlumno.Genero, ObjAlumno.IdEmpleado, ObjAlumno.OficioQuienSolicita, ObjAlumno.CicloAlu
                                   };
                String[] ParametrosOut = { "p_Bandera" };

                Cmd = CDDatos.GenerarOracleCommand("UPD_DESCUENTOS_2016", ref Verificador, Parametros, Valores, ParametrosOut);
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
        public void AlumnoInsertarDescuentoOld(ref Alumno ObjAlumno, ref string Verificador)
        {
            CD_Datos CDDatos = new CD_Datos("INGRESOS");
            OracleCommand Cmd = null;
            //if (ObjAlumno.NoControl == string.Empty)
            //    ObjAlumno.NoControl = "0";

            try
            {
                String[] Parametros = { "P_DEPENDENCIA", "P_CICLO_ESCOLAR", "P_MATRICULA", "P_NOMBRE", "P_PATERNO",
                                        "P_MATERNO", "P_CARRERA", "P_IDCARRERA", "P_SEMESTRE", "P_GRUPO",
                                        "P_NIVEL", "P_STATUS", "P_EVENTO", "P_CLAVE_CONCEPTO", "P_PORCENTAJE",
                                        "P_OFICIO_SOLICITUD", "P_OFICIO_FIRMA", "P_OFICIO_FECHA", "P_ID_TIPO_DESCUENTO", "P_NOTAS",
                                        "P_USUARIO", "P_VIGENCIA_INICIAL", "P_VIGENCIA_FINAL", "P_QUIEN_SOLICITA"
                                      };
                object[] Valores = {    ObjAlumno.Dependencia, ObjAlumno.CicloEscolar, ObjAlumno.Matricula, ObjAlumno.Nombre, ObjAlumno.APaterno,
                                        ObjAlumno.AMaterno, ObjAlumno.DescCarrera, ObjAlumno.Carrera, ObjAlumno.Semestre, ObjAlumno.Grupo,
                                        ObjAlumno.Nivel, ObjAlumno.StatusMatricula, ObjAlumno.Evento, ObjAlumno.ConceptoDescuento, ObjAlumno.PorcentajeDescuento,
                                        ObjAlumno.OficioSolicito, ObjAlumno.OficioFirma,ObjAlumno.OficioFecha, ObjAlumno.TipoDescuento, ObjAlumno.Observaciones,
                                        ObjAlumno.UsuNombre, ObjAlumno.FechaInicial, ObjAlumno.FechaFinal, ObjAlumno.OficioQuienSolicita};
                String[] ParametrosOut = { "P_ID_DESCUENTO", "P_BANDERA" };

                Cmd = CDDatos.GenerarOracleCommand("INS_DESCUENTOS_2016", ref Verificador, Parametros, Valores, ParametrosOut);
                ObjAlumno.IdPersona = Convert.ToInt32(Cmd.Parameters["P_ID_DESCUENTO"].Value);

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
        public void AlumnoInsertarDescuento(ref Alumno ObjAlumno, ref string Verificador)
        {
            CD_Datos CDDatos = new CD_Datos("INGRESOS");
            OracleCommand Cmd = null;
            //if (ObjAlumno.NoControl == string.Empty)
            //    ObjAlumno.NoControl = "0";

            try
            {
                String[] Parametros = { "P_DEPENDENCIA", "P_CICLO_ESCOLAR", "P_MATRICULA", "P_NOMBRE", "P_PATERNO",
                                        "P_MATERNO", "P_CARRERA", "P_IDCARRERA", "P_SEMESTRE", "P_GRUPO",
                                        "P_NIVEL", "P_STATUS", "P_EVENTO", "P_CLAVE_CONCEPTO", "P_PORCENTAJE",
                                        "P_OFICIO_SOLICITUD", "P_OFICIO_FIRMA", "P_OFICIO_FECHA", "P_ID_TIPO_DESCUENTO", "P_NOTAS",
                                        "P_USUARIO", "P_VIGENCIA_INICIAL", "P_VIGENCIA_FINAL","P_QUIEN_SOLICITA","P_ASOCIADO", "P_ID_FAMILIAR",
                                        "P_ADSCRIPCION", "P_PLAZA", "P_TIPO_PERSONAL", "P_PARENTESCO", "P_FECHA_NACIMIENTO",
                                        "P_GENERO", "P_ID_EMPLEADO", "P_CICLO_ALUM"
                                      };
                object[] Valores = {    ObjAlumno.Dependencia, ObjAlumno.CicloEscolar, ObjAlumno.Matricula, ObjAlumno.Nombre, ObjAlumno.APaterno,
                                        ObjAlumno.AMaterno, ObjAlumno.DescCarrera, ObjAlumno.Carrera, ObjAlumno.Semestre, ObjAlumno.Grupo,
                                        ObjAlumno.Nivel, ObjAlumno.StatusMatricula, ObjAlumno.Evento, ObjAlumno.ConceptoDescuento, ObjAlumno.PorcentajeDescuento,
                                        ObjAlumno.OficioSolicito, ObjAlumno.OficioFirma,ObjAlumno.OficioFecha, ObjAlumno.TipoDescuento, ObjAlumno.Observaciones,
                                        ObjAlumno.UsuNombre, ObjAlumno.FechaInicial, ObjAlumno.FechaFinal, ObjAlumno.OficioQuienSolicita, ObjAlumno.NombreEmpleado, ObjAlumno.IdFamiliar,
                                        ObjAlumno.Adscripcion, Convert.ToInt32(ObjAlumno.NoControl), ObjAlumno.TipoPersonaStr, ObjAlumno.Parentesco, ObjAlumno.FechaNacimiento,
                                        Convert.ToString(ObjAlumno.Genero), Convert.ToInt32(ObjAlumno.IdEmpleado), ObjAlumno.CicloAlu};
                String[] ParametrosOut = { "P_ID_DESCUENTO", "P_BANDERA" };

                Cmd = CDDatos.GenerarOracleCommand("INS_DESCUENTOS_2016", ref Verificador, Parametros, Valores, ParametrosOut);
                ObjAlumno.IdPersona = Convert.ToInt32(Cmd.Parameters["P_ID_DESCUENTO"].Value);

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
        public void AlumnoEliminarDescuento(Alumno ObjAlumno, ref string Verificador)
        {
            CD_Datos CDDatos = new CD_Datos("INGRESOS");
            OracleCommand Cmd = null;
            try
            {
                String[] Parametros = { "P_ID_DESCUENTO", "P_USUARIO", "P_OBSERVACIONES" };
                object[] Valores = { ObjAlumno.IdPersona, ObjAlumno.UsuNombre,ObjAlumno.Observaciones};
                String[] ParametrosOut = { "p_Bandera" };

                Cmd = CDDatos.GenerarOracleCommand("DEL_DESCUENTOS", ref Verificador, Parametros, Valores, ParametrosOut);


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

        public void ActualizarStatusDescuento(Alumno ObjAlumno, ref string Verificador)
        {
            CD_Datos CDDatos = new CD_Datos("INGRESOS");
            OracleCommand Cmd = null;
            try
            {
                String[] Parametros = { "P_ID_DESCUENTO", "P_STATUS", "P_USUARIO", "P_OBSERVACIONES" };
                object[] Valores = { ObjAlumno.IdPersona, ObjAlumno.StatusMatricula, ObjAlumno.UsuNombre, ObjAlumno.Observaciones };
                String[] ParametrosOut = { "p_Bandera" };

                Cmd = CDDatos.GenerarOracleCommand("UPDA_STATUS_DESCUENTO", ref Verificador, Parametros, Valores, ParametrosOut);


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
        public void GeneraReciboDescuento(ref Alumno ObjAlumno, ref string Verificador)
        {
            CD_Datos CDDatos = new CD_Datos("INGRESOS");
            OracleCommand Cmd = null;
            try
            {
                string Dependencia = ObjAlumno.Dependencia;
                string Nivel = ObjAlumno.Nivel;
                string Verificador2 = string.Empty;
                if (Nivel == "M" || Nivel == "E" || Nivel == "D")
                {
                    AjustaDependencia(ref Dependencia, Nivel, ref Verificador2);
                    //if (Verificador2 == "0")
                    ObjAlumno.Dependencia = Dependencia;
                }

                String[] Parametros = {"p_id", "p_dependencia", "p_matricula", "p_clave_concepto", "p_usuario"};
                object[] Valores = { ObjAlumno.IdPersona, ObjAlumno.Dependencia, ObjAlumno.Matricula,  ObjAlumno.ConceptoDescuento, ObjAlumno.UsuNombre };
                String[] ParametrosOut = { "p_Bandera" };
                Cmd = CDDatos.GenerarOracleCommand("GNR_RECIBO_DESCUENTO_2017", ref Verificador, Parametros, Valores, ParametrosOut);
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
        public void GeneraExencionesAutomaticas(Alumno ObjAlumno, ref string Verificador)
        {
            CD_Datos CDDatos = new CD_Datos("INGRESOS");
            OracleCommand Cmd = null;
            try
            {
                string TipoPersonal = ObjAlumno.Dependencia;
                string Nivel = ObjAlumno.Nivel;
                string Verificador2 = string.Empty;
                if (ObjAlumno.TipoDescuento == "SINSPA")
                    TipoPersonal = "D";
                else
                    TipoPersonal = "A";

                String[] Parametros = { "p_tipo_personal", "p_sindicato", "p_nivel", "p_origen", "p_ciclo_escolar" };
                object[] Valores = { TipoPersonal, ObjAlumno.TipoDescuento, ObjAlumno.Nivel, "ALUMNO", ObjAlumno.CicloEscolar };
                String[] ParametrosOut = { "p_Bandera" };
                Cmd = CDDatos.GenerarOracleCommand("GNR_EXENCIONES_GESTION_RH", ref Verificador, Parametros, Valores, ParametrosOut);
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

        public void AjustaDependencia(ref string Dependencia, string Nivel, ref string Verificador)
        {
            //-----------OBTIENE LA DEPENDENCIA SEGUN EL NIVEL, EJ: 41101 A 41102 PARA POSGRADO-----------//

            CD_Datos CDDatos = new CD_Datos("INGRESOS");
            OracleCommand Cmd = null;
            try
            {
                String[] Parametros = { "p_depedencia", "p_nivel" };
                object[] Valores = { Dependencia, Nivel };
                String[] ParametrosOut = { "p_dependencia_ajustada", "p_bandera" };
                Cmd = CDDatos.GenerarOracleCommand("GNR_DEPENDENCIA_AJUSTADA_2016", ref Verificador, Parametros, Valores, ParametrosOut);
                Dependencia = Cmd.Parameters["p_dependencia_ajustada"].Value.ToString();
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
        /*ALUMNOS O CLIENTES AUTORIZADOS PARA EVENTOS*/
        public void ConsultarAutorizado(ref Alumno ObjAlumno, ref List<Alumno> List)
        {
            CD_Datos CDDatos = new CD_Datos("INGRESOS");
            OracleCommand cmm = null;

            try
            {
                OracleDataReader dr = null;
                string[] Parametros = { "p_evento", "p_sede" };
                object[] Valores = { ObjAlumno.Evento, null /*ObjAlumno.Sede */};
                cmm = CDDatos.GenerarOracleCommandCursor("pkg_pagos.Obt_Grid_Autorizados", ref dr, Parametros, Valores);
                // ObjAlumno.TipoPersona = 0;
                int suspendido = 0;
                int activo = 0;
                int total = 0;
                while (dr.Read())
                {
                    ObjAlumno = new Alumno();

                    ObjAlumno.Matricula = Convert.ToString(dr.GetValue(0));
                    ObjAlumno.Nombre = Convert.ToString(dr.GetValue(1));
                    ObjAlumno.TipoPersonaStr = Convert.ToString(dr.GetValue(2));
                    ObjAlumno.StatusMatricula = Convert.ToString(dr.GetValue(3));
                    ObjAlumno.ImageStatusMatricula ="../Imagenes/"+ Convert.ToString(dr.GetValue(3))+".PNG";
                    ObjAlumno.UsuNombre = Convert.ToString(dr.GetValue(4));
                    ObjAlumno.Sede = Convert.ToString(dr.GetValue(5));
                    ObjAlumno.Nivel = Convert.ToString(dr.GetValue(6));

                    if (ObjAlumno.StatusMatricula == "Activo")
                        activo += 1;
                    else
                        suspendido += 1;
                    total += 1;

                    List.Add(ObjAlumno);

                }
                dr.Close();

                ObjAlumno.NoActivo = activo;
                ObjAlumno.NoSuspendido = suspendido;
                ObjAlumno.TotalMatricula = total;
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
        public void ConsultarAlumnoAutorizadoSel(ref Alumno ObjAlumno, ref string Verificador)
        {
            try
            {

                CD_Datos CDDatos = new CD_Datos("INGRESOS");
                string[] ParametrosIn = { "p_matricula",
                                        "p_evento"};
                object[] Valores = {   ObjAlumno.Matricula,
                                       ObjAlumno.Evento,
                                      
            };
                string[] ParametrosOut ={
                                        
                                          "p_nombre",
                                          "p_Bandera"
                                         
                };

                OracleCommand Cmd = CDDatos.GenerarOracleCommand("SEL_ALUMNO", ref Verificador, ParametrosIn, Valores, ParametrosOut);
                if (Verificador == "0")
                {
                    ObjAlumno = new Alumno();
                    ObjAlumno.Nombre = Convert.ToString(Cmd.Parameters["p_nombre"].Value);
                }
                
                CDDatos.LimpiarOracleCommand(ref Cmd);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void ActualizarStatusAutorizado(ref Alumno ObjAlumno, ref string Verificador)
        {
            try
            {

                CD_Datos CDDatos = new CD_Datos("INGRESOS");
                string[] ParametrosIn = { "p_evento",
                                          "p_matricula",
                                          "p_usuario"};
                object[] Valores = { 
                                        ObjAlumno.Evento,
                                        ObjAlumno.Matricula,
                                        ObjAlumno.UsuNombre
            };
                string[] ParametrosOut ={                                        
                                          "p_Bandera"
                };

                OracleCommand Cmd = CDDatos.GenerarOracleCommand("UPD_AUTORIZADOS", ref Verificador, ParametrosIn, Valores, ParametrosOut);

                CDDatos.LimpiarOracleCommand(ref Cmd);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void AutorizadoInsertar(ref Alumno ObjAlumno, ref string Verificador)
        {
            try
            {

                CD_Datos CDDatos = new CD_Datos("INGRESOS");
                string[] ParametrosIn = { "p_evento",
                                          "p_matricula",
                                          "p_nombre",
                                          "p_status",
                                          "p_usuario",
                                          "p_externo",
                                          "p_Sede",
                                          "p_Nivel"};
                object[] Valores = { 
                                        ObjAlumno.Evento,
                                        ObjAlumno.Matricula,
                                        ObjAlumno.Nombre,
                                        ObjAlumno.StatusMatricula,
                                        ObjAlumno.UsuNombre,
                                        ObjAlumno.TipoPersonaStr,
                                        ObjAlumno.Sede,
                                        ObjAlumno.Nivel
            };
                string[] ParametrosOut ={                                        
                                          "p_Bandera"
                };

                OracleCommand Cmd = CDDatos.GenerarOracleCommand("INS_AUTORIZADOS", ref Verificador, ParametrosIn, Valores, ParametrosOut);

                CDDatos.LimpiarOracleCommand(ref Cmd);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void AutorizadoInsertarMatricula(ref Alumno ObjAlumno, ref string Verificador)
        {
            try
            {

                CD_Datos CDDatos = new CD_Datos("INGRESOS");
                string[] ParametrosIn = { "p_evento",
                                          "p_matricula",
                                          "p_nombre",
                                          "p_status",
                                          "p_usuario",
                                          "p_externo",
                                          "p_Sede",
                                          "p_Nivel"};
                object[] Valores = { 
                                        ObjAlumno.Evento,
                                        ObjAlumno.Matricula,
                                        ObjAlumno.Nombre,
                                        ObjAlumno.StatusMatricula,
                                        ObjAlumno.UsuNombre,
                                        ObjAlumno.TipoPersonaStr,
                                        ObjAlumno.Sede,
                                        ObjAlumno.Nivel
            };
                string[] ParametrosOut ={                                        
                                          "p_Bandera"
                };

                OracleCommand Cmd = CDDatos.GenerarOracleCommand("INS_AUTORIZADOS", ref Verificador, ParametrosIn, Valores, ParametrosOut);

                CDDatos.LimpiarOracleCommand(ref Cmd);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void AutorizadosInsertar(string Evento, List<Alumno> lstAutorizados, ref string Verificador)
        {
            foreach (Alumno lst in lstAutorizados)
            {
                try
                {

                    CD_Datos CDDatos = new CD_Datos("INGRESOS");
                    string[] ParametrosIn = { "p_evento",
                                          "p_matricula",
                                          "p_nombre",
                                          "p_status",
                                          "p_usuario",
                                          "p_externo",
                                          "p_Sede",
                                          "p_Nivel"};
                    object[] Valores = {
                                        Evento,
                                        lst.Matricula,
                                        lst.Nombre,
                                        lst.StatusMatricula,
                                        lst.UsuNombre,
                                        lst.TipoPersonaStr,
                                        lst.Sede,
                                        lst.Nivel
            };
                    string[] ParametrosOut ={
                                          "p_Bandera"
                };

                    OracleCommand Cmd = CDDatos.GenerarOracleCommand("INS_AUTORIZADOS", ref Verificador, ParametrosIn, Valores, ParametrosOut);

                    CDDatos.LimpiarOracleCommand(ref Cmd);

                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }
        public void AutorizadosEliminar(Evento ObjEvento, ref string Verificador)
        {
            CD_Datos CDDatos = new CD_Datos("INGRESOS");
            OracleCommand Cmd = null;
            try
            {
                String[] Parametros = { "P_EVENTO" };
                object[] Valores = { ObjEvento.Eventos };
                String[] ParametrosOut = { "P_BANDERA" };

                Cmd = CDDatos.GenerarOracleCommand("DEL_AUTORIZADOS", ref Verificador, Parametros, Valores, ParametrosOut);
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

        public void ConsultarCorreoAlumno(ref Alumno ObjAlumno, ref string Verificador)
        {
            CD_Datos CDDatos = new CD_Datos("INGRESOS");
            OracleCommand Cmd = null;
            try
            {
                String[] Parametros = { "P_MATRICULA" };
                object[] Valores = { ObjAlumno.Matricula };
                String[] ParametrosOut = { "P_CORREO", "P_BANDERA" };

                Cmd = CDDatos.GenerarOracleCommand("OBT_CORREO_ALUMNO", ref Verificador, Parametros, Valores, ParametrosOut);
                ObjAlumno.Correo = Convert.ToString(Cmd.Parameters["P_CORREO"].Value);

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
