using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OracleClient;
using CapaEntidad;
using System.IO;


namespace CapaDatos
{
    public class CD_Oficio
    {
        public void OficioInsertar(List<Oficio> ListOficio, Alumno ObjAlumno, ref string Verificador)
        {
            CD_Datos CDDatos = new CD_Datos("INGRESOS");
            OracleCommand Cmd = null;
            try
            {
                CDDatos.StartTrans();
                for (int i = 0; i < ListOficio.Count; i++)
                {                    
                    String[] Parametros = { "P_NUM_OFICIO", "P_ID_DESCUENTO", "P_NOMBRE_ARCHIVO" };
                    object[] Valores = { ListOficio[i].NumOficio, ObjAlumno.IdPersona, ListOficio[i].NombreArchivo };
                    String[] ParametrosOut = { "p_Bandera" };
                    Cmd = CDDatos.GenerarOracleCommand("INS_DESCUENTOS_OFICIOS", ref Verificador, Parametros, Valores, ParametrosOut);                    
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
        //public void OficioInsertar(List<Oficio> ListOficio, Alumno ObjAlumno, ref string Verificador)
        //{
        //    CD_Datos CDDatos = new CD_Datos("INGRESOS");
        //    OracleCommand Cmd = null;
        //    try
        //    {
        //        for (int i = 0; i < ListOficio.Count; i++)
        //        {

        //            //String[] Parametros = { "P_ID_DESCUENTO", "P_ARCHIVO", "P_NOMBRE_ARCHIVO" };
        //            //object[] Valores = { ObjAlumno.IdPersona, ListOficio[i].Archivo, ListOficio[i].NombreArchivo };                    
        //            //String[] ParametrosOut = { "p_Bandera" };                    
        //            //Cmd = CDDatos.GenerarOracleCommand_Imagen("INS_DESCUENTOS_OFICIOS", ref Verificador, ObjAlumno.IdPersona, ListOficio[i].Archivo, ListOficio[i].NombreArchivo);

        //            //FileStream FS = new FileStream(ListOficio[i].RutaArchivo, FileMode.Open, FileAccess.Read);
        //            //ListOficio[i].Archivo = new byte[FS.Length];
        //            //FS.Read(ListOficio[i].Archivo, 0, System.Convert.ToInt32(FS.Length));
        //            //FS.Close();

        //            String[] Parametros = { "P_ID_DESCUENTO", "P_ARCHIVO", "P_NOMBRE_ARCHIVO" };
        //            object[] Valores = { ObjAlumno.IdPersona, ListOficio[i].Archivo, ListOficio[i].NombreArchivo };                    
        //            String[] ParametrosOut = { "p_Bandera" };
        //            Cmd = CDDatos.GenerarOracleCommand("INS_DESCUENTOS_OFICIOS", ref Verificador, Parametros, Valores, ParametrosOut);
        //            //Cmd = CDDatos.GenerarOracleCommand_Imagen("INS_DESCUENTOS_OFICIOS", ref Verificador, ObjAlumno.IdPersona, ListOficio[i].Archivo, ListOficio[i].NombreArchivo);
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message);
        //    }
        //    finally
        //    {
        //        CDDatos.LimpiarOracleCommand(ref Cmd);
        //    }
        //}
        public void OficioEditar(List<Oficio> ListOficio, Alumno ObjAlumno, ref string Verificador)
        {
            CD_Datos CDDatos = new CD_Datos("INGRESOS");
            OracleCommand Cmd = null;
            try
            {
                //String[] Parametros = { "P_ID_DESCUENTO" };
                //object[] Valores = { ObjAlumno.IdPersona };
                //String[] ParametrosOut = { "p_Bandera" };
                //Cmd = CDDatos.GenerarOracleCommand("DEL_DESCUENTOS_OFICIOS", ref Verificador, Parametros, Valores, ParametrosOut);
                OficioEliminar(ObjAlumno, ref Verificador);
                OficioInsertar(ListOficio, ObjAlumno, ref Verificador);
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
        public void OficioEliminar(Alumno ObjAlumno, ref string Verificador)
        {
            CD_Datos CDDatos = new CD_Datos("INGRESOS");
            OracleCommand Cmd = null;
            try
            {
                String[] Parametros = { "P_ID_DESCUENTO" };
                object[] Valores = { ObjAlumno.IdPersona };
                String[] ParametrosOut = { "p_Bandera" };
                Cmd = CDDatos.GenerarOracleCommand("DEL_DESCUENTOS_OFICIOS", ref Verificador, Parametros, Valores, ParametrosOut);                
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
        public void OficioConsultaGrid(ref Oficio ObjOficio, ref List<Oficio> List)
        {
            CD_Datos CDDatos = new CD_Datos("INGRESOS");
            OracleCommand cmm = null;
            try
            {
                OracleDataReader dr = null;


                string[] Parametros = { "P_ID_DESCUENTO" };
                object[] Valores = { ObjOficio.IdDescuento };

                cmm = CDDatos.GenerarOracleCommandCursor("PKG_PAGOS.Obt_Grid_Descuentos_Oficios", ref dr, Parametros, Valores);
                while (dr.Read())
                {
                    ObjOficio = new Oficio();
                    ObjOficio.NombreArchivo = Convert.ToString(dr.GetValue(0));
                    ObjOficio.LinkArchivo = Convert.ToString(dr.GetValue(1));
                    ObjOficio.NumOficio = Convert.ToString(dr.GetValue(2));
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
        public void ConsultarIdOficio(ref Oficio ObjOficio, ref string Verificador)
        {
            CD_Datos CDDatos = new CD_Datos("INGRESOS");
            OracleCommand Cmd = null;
            try
            {
                string[] ParametrosIn = { };
                object[] Valores = { };
                string[] ParametrosOut ={
                                          "P_ID_OFICIO",
                                          "P_BANDERA"
                };

                Cmd = CDDatos.GenerarOracleCommand("OBT_DESCUENTOS_OFICIO", ref Verificador, ParametrosIn, Valores, ParametrosOut);
                if (Verificador == "0")
                {
                    ObjOficio = new Oficio();
                    ObjOficio.IdOficio = Convert.ToInt32(Cmd.Parameters["P_ID_OFICIO"].Value);
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
