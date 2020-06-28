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
    public class CD_Comun
    {
        //----------------Ingresando nombre de Esquema BD----------------------------------------------------------------
        public void LlenaCombo(string SP, ref List<Comun> list, string usuBD)
        {
            CD_Datos CDDatos = new CD_Datos(usuBD);
            OracleCommand Cmm = null;
            try
            {
                OracleDataReader dr = null;
                Cmm = CDDatos.GenerarOracleCommandCursor(SP, ref dr);

                Comun Comun = default(Comun);
                while (dr.Read())
                {

                    Comun = new Comun();
                    Comun.IdStr = Convert.ToString(dr.GetValue(0));
                    Comun.Descripcion = Convert.ToString(dr.GetValue(1));
                    if (dr.FieldCount == 3)
                    {

                        Comun.Etiqueta = Convert.ToString(dr.GetValue(2));

                    }
                    else if (dr.FieldCount == 4)
                    {

                        Comun.Etiqueta = Convert.ToString(dr.GetValue(2));
                        Comun.EtiquetaDos = Convert.ToString(dr.GetValue(3));
                    }
                    else if (dr.FieldCount == 5)
                    {

                        Comun.Etiqueta = Convert.ToString(dr.GetValue(2));
                        Comun.EtiquetaDos = Convert.ToString(dr.GetValue(3));
                        Comun.EtiquetaTres = Convert.ToString(dr.GetValue(4));
                    }
                    else if (dr.FieldCount == 6)
                    {

                        Comun.Etiqueta = Convert.ToString(dr.GetValue(2));
                        Comun.EtiquetaDos = Convert.ToString(dr.GetValue(3));
                        Comun.EtiquetaTres = Convert.ToString(dr.GetValue(4));
                        Comun.EtiquetaCuatro = Convert.ToString(dr.GetValue(5));
                    }
                    list.Add(Comun);
                }
                dr.Close();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                CDDatos.LimpiarOracleCommand(ref Cmm);
            }
        }
        public void LlenaCombo(string SP, ref List<Comun> list, string parametro1, string Valor1, string usuBD)
        {
            CD_Datos CDDatos = new CD_Datos(usuBD);
            OracleCommand Cmm = null;
            try
            {
                OracleDataReader dr = null;


                string[] Parametros = { parametro1 };
                object[] Valores = { Valor1 };

                Cmm = CDDatos.GenerarOracleCommandCursor(SP, ref dr, Parametros, Valores);

                Comun Comun = default(Comun);
                while (dr.Read())
                {
                    Comun = new Comun();
                    Comun.IdStr = Convert.ToString(dr.GetValue(0));
                    Comun.Descripcion = Convert.ToString(dr.GetValue(1));
                    if (dr.FieldCount == 3)
                    {

                        Comun.EtiquetaDos = Convert.ToString(dr.GetValue(2));

                    }
                    else if (dr.FieldCount == 4)
                    {

                        Comun.EtiquetaDos = Convert.ToString(dr.GetValue(2));
                        Comun.EtiquetaTres = Convert.ToString(dr.GetValue(3));
                    }
                    else if (dr.FieldCount == 5)
                    {

                        Comun.EtiquetaDos = Convert.ToString(dr.GetValue(2));
                        Comun.EtiquetaTres = Convert.ToString(dr.GetValue(3));
                        Comun.EtiquetaCuatro = Convert.ToString(dr.GetValue(4));
                    }
                    list.Add(Comun);
                }
                dr.Close();
                // CDDatos.LimpiarOracleCommand(ref Cmm);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                CDDatos.LimpiarOracleCommand(ref Cmm);
            }
        }
        public void LlenaCombo(string SP, ref List<Comun> list, string parametro1, string parametro2, string Valor1, string Valor2, string usuBD)
        {
            CD_Datos CDDatos = new CD_Datos(usuBD);
            OracleCommand Cmm = null;
            try
            {
                OracleDataReader dr = null;


                string[] Parametros = { parametro1, parametro2};
                object[] Valores = { Valor1, Valor2};

                Cmm = CDDatos.GenerarOracleCommandCursor(SP, ref dr, Parametros, Valores);

                Comun Comun = default(Comun);
                while (dr.Read())
                {
                    Comun = new Comun();
                    Comun.IdStr = Convert.ToString(dr.GetValue(0));
                    Comun.Descripcion = Convert.ToString(dr.GetValue(1));
                    if (dr.FieldCount == 3)
                    {

                        Comun.EtiquetaDos = Convert.ToString(dr.GetValue(2));

                    }
                    else if (dr.FieldCount == 4)
                    {

                        Comun.EtiquetaDos = Convert.ToString(dr.GetValue(2));
                        Comun.EtiquetaTres = Convert.ToString(dr.GetValue(3));
                    }
                    else if (dr.FieldCount == 5)
                    {

                        Comun.EtiquetaDos = Convert.ToString(dr.GetValue(2));
                        Comun.EtiquetaTres = Convert.ToString(dr.GetValue(3));
                        Comun.EtiquetaCuatro = Convert.ToString(dr.GetValue(4));
                    }
                    list.Add(Comun);
                }
                dr.Close();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                CDDatos.LimpiarOracleCommand(ref Cmm);
            }
        }
        public void LlenaCombo(string SP, ref List<Comun> list, string parametro1, string parametro2, string parametro3, string Valor1, string Valor2, string Valor3, string usuBD)
        {
            CD_Datos CDDatos = new CD_Datos(usuBD);
            OracleCommand Cmm = null;
            try
            {
                OracleDataReader dr = null;


                string[] Parametros = { parametro1, parametro2, parametro3 };
                object[] Valores = { Valor1, Valor2, Valor3 };

                Cmm = CDDatos.GenerarOracleCommandCursor(SP, ref dr, Parametros, Valores);

                Comun Comun = default(Comun);
                while (dr.Read())
                {
                    Comun = new Comun();
                    Comun.IdStr = Convert.ToString(dr.GetValue(0));
                    Comun.Descripcion = Convert.ToString(dr.GetValue(1));
                    if (dr.FieldCount == 3)
                    {

                        Comun.EtiquetaDos = Convert.ToString(dr.GetValue(2));

                    }
                    else if (dr.FieldCount == 4)
                    {

                        Comun.EtiquetaDos = Convert.ToString(dr.GetValue(2));
                        Comun.EtiquetaTres = Convert.ToString(dr.GetValue(3));
                    }
                    else if (dr.FieldCount == 5)
                    {

                        Comun.EtiquetaDos = Convert.ToString(dr.GetValue(2));
                        Comun.EtiquetaTres = Convert.ToString(dr.GetValue(3));
                        Comun.EtiquetaCuatro = Convert.ToString(dr.GetValue(4));
                    }
                    list.Add(Comun);
                }
                dr.Close();
              
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                CDDatos.LimpiarOracleCommand(ref Cmm);
            }
        }
        public void LlenaCombo(string SP, ref List<Comun> list, string parametro1, string parametro2, string parametro3, string parametro4, string Valor1, string Valor2, string Valor3, string Valor4, string usuBD)
        {
            CD_Datos CDDatos = new CD_Datos(usuBD);
            OracleCommand Cmm = null;
            try
            {
                OracleDataReader dr = null;


                string[] Parametros = { parametro1, parametro2, parametro3, parametro4 };
                object[] Valores = { Valor1, Valor2, Valor3, Valor4 };

                Cmm = CDDatos.GenerarOracleCommandCursor(SP, ref dr, Parametros, Valores);

                Comun Comun = default(Comun);
                while (dr.Read())
                {
                    Comun = new Comun();
                    Comun.IdStr = Convert.ToString(dr.GetValue(0));
                    Comun.Descripcion = Convert.ToString(dr.GetValue(1));
                    if (dr.FieldCount == 3)
                    {

                        Comun.EtiquetaDos = Convert.ToString(dr.GetValue(2));

                    }
                    else if (dr.FieldCount == 4)
                    {

                        Comun.EtiquetaDos = Convert.ToString(dr.GetValue(2));
                        Comun.EtiquetaTres = Convert.ToString(dr.GetValue(3));
                    }
                    else if (dr.FieldCount == 5)
                    {

                        Comun.EtiquetaDos = Convert.ToString(dr.GetValue(2));
                        Comun.EtiquetaTres = Convert.ToString(dr.GetValue(3));
                        Comun.EtiquetaCuatro = Convert.ToString(dr.GetValue(4));
                    }
                    list.Add(Comun);
                }
                dr.Close();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                CDDatos.LimpiarOracleCommand(ref Cmm);
            }
        }
        //-----------------------------****------------------------------------------------------------------------------------------------------------------------------------------
        public Comun Consultar_Total_Visitas(ref Comun ObjComun)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand cmm = null;
            try
            {
                OracleDataReader dr = null;

                cmm = CDDatos.GenerarOracleCommandCursor("PKG_FELECTRONICA.Obt_Contador_Visitas", ref dr);
                while (dr.Read())
                {
                    ObjComun = new Comun();
                    ObjComun.Contador_Visitas = Convert.ToString(dr.GetValue(0));
                }
                dr.Close();
                return ObjComun;
                
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
        public void LlenaCombo(string SP, ref List<Comun> list)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand Cmm = null;
            try
            {
                OracleDataReader dr = null;

                Cmm = CDDatos.GenerarOracleCommandCursor(SP, ref dr);

                Comun Comun = default(Comun);
                while (dr.Read())
                {

                    Comun = new Comun();
                    Comun.IdStr = Convert.ToString(dr.GetValue(0));
                    Comun.Descripcion = Convert.ToString(dr.GetValue(1));
                    if (dr.FieldCount == 3)
                    {
                        Comun.EtiquetaDos = Convert.ToString(dr.GetValue(2));

                    }
                    else if (dr.FieldCount == 4)
                    {

                        Comun.EtiquetaDos = Convert.ToString(dr.GetValue(2));
                        Comun.EtiquetaTres = Convert.ToString(dr.GetValue(3));
                    }
                    else if (dr.FieldCount == 5)
                    {

                        Comun.EtiquetaDos = Convert.ToString(dr.GetValue(2));
                        Comun.EtiquetaTres = Convert.ToString(dr.GetValue(3));
                        Comun.EtiquetaCuatro = Convert.ToString(dr.GetValue(4));
                    }
                    list.Add(Comun);
                }
                dr.Close();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                CDDatos.LimpiarOracleCommand(ref Cmm);
            }
        }
        public void LlenaCombo(string SP, ref List<Comun> list, string parametro1, string Valor1)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand Cmm = null;
            try
            {
                OracleDataReader dr = null;


                string[] Parametros = { parametro1 };
                object[] Valores = { Valor1 };

                Cmm = CDDatos.GenerarOracleCommandCursor(SP, ref dr, Parametros, Valores);

                Comun Comun = default(Comun);
                while (dr.Read())
                {
                    Comun = new Comun();
                    Comun.IdStr = Convert.ToString(dr.GetValue(0));
                    Comun.Descripcion = Convert.ToString(dr.GetValue(1));
                    if (dr.FieldCount == 3)
                    {

                        Comun.EtiquetaDos = Convert.ToString(dr.GetValue(2));

                    }
                    else if (dr.FieldCount == 4)
                    {

                        Comun.EtiquetaDos = Convert.ToString(dr.GetValue(2));
                        Comun.EtiquetaTres = Convert.ToString(dr.GetValue(3));
                    }
                    else if (dr.FieldCount == 5)
                    {

                        Comun.EtiquetaDos = Convert.ToString(dr.GetValue(2));
                        Comun.EtiquetaTres = Convert.ToString(dr.GetValue(3));
                        Comun.EtiquetaCuatro = Convert.ToString(dr.GetValue(4));
                    }
                    list.Add(Comun);
                }
                dr.Close();
                
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                CDDatos.LimpiarOracleCommand(ref Cmm);
            }
        }
        public void LlenaCombo(string SP, ref List<Comun> list, string parametro1, string parametro2, string Valor1, string Valor2)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand Cmm = null;
            try
            {
                OracleDataReader dr = null;


                string[] Parametros = { parametro1, parametro2 };
                object[] Valores = { Valor1, Valor2 };

                Cmm = CDDatos.GenerarOracleCommandCursor(SP, ref dr, Parametros, Valores);

                Comun Comun = default(Comun);
                while (dr.Read())
                {
                    Comun = new Comun();
                    Comun.IdStr = Convert.ToString(dr.GetValue(0));
                    Comun.Descripcion = Convert.ToString(dr.GetValue(1));
                    if (dr.FieldCount == 3)
                    {

                        Comun.EtiquetaDos = Convert.ToString(dr.GetValue(2));

                    }
                    else if (dr.FieldCount == 4)
                    {

                        Comun.EtiquetaDos = Convert.ToString(dr.GetValue(2));
                        Comun.EtiquetaTres = Convert.ToString(dr.GetValue(3));
                    }
                    else if (dr.FieldCount == 5)
                    {

                        Comun.EtiquetaDos = Convert.ToString(dr.GetValue(2));
                        Comun.EtiquetaTres = Convert.ToString(dr.GetValue(3));
                        Comun.EtiquetaCuatro = Convert.ToString(dr.GetValue(4));
                    }
                    list.Add(Comun);
                }
                dr.Close();
              
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                CDDatos.LimpiarOracleCommand(ref Cmm);
            }
        }
        public void LlenaCombo(string SP, ref List<Comun> list, string parametro1, string parametro2, string parametro3, string Valor1, string Valor2, string Valor3)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand Cmm = null;
            try
            {
                OracleDataReader dr = null;


                string[] Parametros = { parametro1, parametro2, parametro3 };
                object[] Valores = { Valor1, Valor2, Valor3 };

                Cmm = CDDatos.GenerarOracleCommandCursor(SP, ref dr, Parametros, Valores);

                Comun Comun = default(Comun);
                while (dr.Read())
                {
                    Comun = new Comun();
                    Comun.IdStr = Convert.ToString(dr.GetValue(0));
                    Comun.Descripcion = Convert.ToString(dr.GetValue(1));
                    if (dr.FieldCount == 3)
                    {

                        Comun.EtiquetaDos = Convert.ToString(dr.GetValue(2));

                    }
                    else if (dr.FieldCount == 4)
                    {

                        Comun.EtiquetaDos = Convert.ToString(dr.GetValue(2));
                        Comun.EtiquetaTres = Convert.ToString(dr.GetValue(3));
                    }
                    else if (dr.FieldCount == 5)
                    {

                        Comun.EtiquetaDos = Convert.ToString(dr.GetValue(2));
                        Comun.EtiquetaTres = Convert.ToString(dr.GetValue(3));
                        Comun.EtiquetaCuatro = Convert.ToString(dr.GetValue(4));
                    }
                    list.Add(Comun);
                }
                dr.Close();
               
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                CDDatos.LimpiarOracleCommand(ref Cmm);
            }
        }
        public void LlenaCombo(string SP, ref List<Comun> list, string parametro1, string parametro2, string parametro3, string parametro4, string parametro5, string Valor1, string Valor2, string Valor3, string Valor4, string Valor5)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand Cmm = null;
            try
            {
                OracleDataReader dr = null;


                string[] Parametros = { parametro1, parametro2, parametro3, parametro4, parametro5 };
                object[] Valores = { Valor1, Valor2, Valor3, Valor4, Valor5 };

                Cmm = CDDatos.GenerarOracleCommandCursor(SP, ref dr, Parametros, Valores);

                Comun Comun = default(Comun);
                while (dr.Read())
                {
                    Comun = new Comun();
                    Comun.IdStr = Convert.ToString(dr.GetValue(0));
                    Comun.Descripcion = Convert.ToString(dr.GetValue(1));
                    if (dr.FieldCount == 3)
                    {

                        Comun.EtiquetaDos = Convert.ToString(dr.GetValue(2));

                    }
                    else if (dr.FieldCount == 4)
                    {

                        Comun.EtiquetaDos = Convert.ToString(dr.GetValue(2));
                        Comun.EtiquetaTres = Convert.ToString(dr.GetValue(3));
                    }
                    else if (dr.FieldCount == 5)
                    {

                        Comun.EtiquetaDos = Convert.ToString(dr.GetValue(2));
                        Comun.EtiquetaTres = Convert.ToString(dr.GetValue(3));
                        Comun.EtiquetaCuatro = Convert.ToString(dr.GetValue(4));
                    }
                    list.Add(Comun);
                }
                dr.Close();
               
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                CDDatos.LimpiarOracleCommand(ref Cmm);
            }
        }
        public void LlenaCombo(string SP, ref List<Comun> list, string parametro1, string parametro2, string parametro3, string parametro4, string Valor1, string Valor2, string Valor3, string Valor4)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand Cmm = null;
            try
            {
                OracleDataReader dr = null;


                string[] Parametros = { parametro1, parametro2, parametro3, parametro4 };
                object[] Valores = { Valor1, Valor2, Valor3, Valor4 };

                Cmm = CDDatos.GenerarOracleCommandCursor(SP, ref dr, Parametros, Valores);

                Comun Comun = default(Comun);
                while (dr.Read())
                {
                    Comun = new Comun();
                    Comun.IdStr = Convert.ToString(dr.GetValue(0));
                    Comun.Descripcion = Convert.ToString(dr.GetValue(1));
                    if (dr.FieldCount == 3)
                    {

                        Comun.EtiquetaDos = Convert.ToString(dr.GetValue(2));

                    }
                    else if (dr.FieldCount == 4)
                    {

                        Comun.EtiquetaDos = Convert.ToString(dr.GetValue(2));
                        Comun.EtiquetaTres = Convert.ToString(dr.GetValue(3));
                    }
                    else if (dr.FieldCount == 5)
                    {

                        Comun.EtiquetaDos = Convert.ToString(dr.GetValue(2));
                        Comun.EtiquetaTres = Convert.ToString(dr.GetValue(3));
                        Comun.EtiquetaCuatro = Convert.ToString(dr.GetValue(4));
                    }
                    else if (dr.FieldCount == 6)
                    {

                        Comun.EtiquetaDos = Convert.ToString(dr.GetValue(2));
                        Comun.EtiquetaTres = Convert.ToString(dr.GetValue(3));
                        Comun.EtiquetaCuatro = Convert.ToString(dr.GetValue(4));
                        Comun.EtiquetaCinco = Convert.ToString(dr.GetValue(5));
                    }
                    list.Add(Comun);
                }
                dr.Close();
                
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                CDDatos.LimpiarOracleCommand(ref Cmm);
            }
        }


        //----------------Llena Listas
        public void LlenaLista(string SP, ref List<Comun> list, string parametro1, string valor1, string usuBD)
        {
            CD_Datos CDDatos = new CD_Datos(usuBD);
            OracleCommand Cmm = null;
            try
            {
                OracleDataReader dr = null;
                string[] Parametros = { parametro1 };
                object[] Valores = { valor1 };
                Cmm = CDDatos.GenerarOracleCommandCursor(SP, ref dr, Parametros, Valores);

                Comun Comun = default(Comun);
                while (dr.Read())
                {

                    Comun = new Comun();
                    Comun.IdStr = Convert.ToString(dr.GetValue(0));
                    Comun.Descripcion = Convert.ToString(dr.GetValue(1));
                    if (dr.FieldCount == 3)
                    {
                        Comun.EtiquetaDos = Convert.ToString(dr.GetValue(2));

                    }
                    else if (dr.FieldCount == 4)
                    {

                        Comun.EtiquetaDos = Convert.ToString(dr.GetValue(2));
                        Comun.EtiquetaTres = Convert.ToString(dr.GetValue(3));
                    }
                    else if (dr.FieldCount == 5)
                    {

                        Comun.EtiquetaDos = Convert.ToString(dr.GetValue(2));
                        Comun.EtiquetaTres = Convert.ToString(dr.GetValue(3));
                        Comun.EtiquetaCuatro = Convert.ToString(dr.GetValue(4));
                    }
                    list.Add(Comun);
                }
                dr.Close();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                CDDatos.LimpiarOracleCommand(ref Cmm);
            }
        }
        public void LlenaLista(string SP, ref List<Comun> list, string parametro1, string valor1)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand Cmm = null;
            try
            {
                OracleDataReader dr = null;
                string[] Parametros = { parametro1 };
                object[] Valores = { valor1 };
                Cmm = CDDatos.GenerarOracleCommandCursor(SP, ref dr, Parametros, Valores);

                Comun Comun = default(Comun);
                while (dr.Read())
                {

                    Comun = new Comun();
                    Comun.IdStr = Convert.ToString(dr.GetValue(0));
                    Comun.Descripcion = Convert.ToString(dr.GetValue(1));
                    if (dr.FieldCount == 3)
                    {
                        Comun.EtiquetaDos = Convert.ToString(dr.GetValue(2));

                    }
                    else if (dr.FieldCount == 4)
                    {

                        Comun.EtiquetaDos = Convert.ToString(dr.GetValue(2));
                        Comun.EtiquetaTres = Convert.ToString(dr.GetValue(3));
                    }
                    else if (dr.FieldCount == 5)
                    {

                        Comun.EtiquetaDos = Convert.ToString(dr.GetValue(2));
                        Comun.EtiquetaTres = Convert.ToString(dr.GetValue(3));
                        Comun.EtiquetaCuatro = Convert.ToString(dr.GetValue(4));
                    }
                    list.Add(Comun);
                }
                dr.Close();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                CDDatos.LimpiarOracleCommand(ref Cmm);
            }
        }
        public void LlenaLista(string SP, ref List<Comun> list, string parametro1, string parametro2, string valor1, string valor2, string usuBD)
        {
            CD_Datos CDDatos = new CD_Datos(usuBD);
            OracleCommand Cmm = null;
            try
            {
                OracleDataReader dr = null;
                string[] Parametros = { parametro1, parametro2 };
                object[] Valores = { valor1, valor2 };
                Cmm = CDDatos.GenerarOracleCommandCursor(SP, ref dr, Parametros, Valores);

                Comun Comun = default(Comun);
                while (dr.Read())
                {

                    Comun = new Comun();
                    Comun.IdStr = Convert.ToString(dr.GetValue(0));
                    Comun.Descripcion = Convert.ToString(dr.GetValue(1));
                    if (dr.FieldCount == 3)
                    {
                        Comun.EtiquetaDos = Convert.ToString(dr.GetValue(2));

                    }
                    else if (dr.FieldCount == 4)
                    {

                        Comun.EtiquetaDos = Convert.ToString(dr.GetValue(2));
                        Comun.EtiquetaTres = Convert.ToString(dr.GetValue(3));
                    }
                    else if (dr.FieldCount == 5)
                    {

                        Comun.EtiquetaDos = Convert.ToString(dr.GetValue(2));
                        Comun.EtiquetaTres = Convert.ToString(dr.GetValue(3));
                        Comun.EtiquetaCuatro = Convert.ToString(dr.GetValue(4));
                    }
                    list.Add(Comun);
                }
                dr.Close();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                CDDatos.LimpiarOracleCommand(ref Cmm);
            }
        }
        public void LlenaLista(string SP, ref List<Comun> list, string parametro1, string parametro2, string parametro3, string valor1, string valor2, string valor3, string usuBD)
        {
            CD_Datos CDDatos = new CD_Datos(usuBD);
            OracleCommand Cmm = null;
            try
            {
                OracleDataReader dr = null;
                string[] Parametros = { parametro1, parametro2, parametro3 };
                object[] Valores = { valor1, valor2, valor3 };
                Cmm = CDDatos.GenerarOracleCommandCursor(SP, ref dr, Parametros, Valores);

                Comun Comun = default(Comun);
                while (dr.Read())
                {

                    Comun = new Comun();
                    Comun.IdStr = Convert.ToString(dr.GetValue(0));
                    Comun.Descripcion = Convert.ToString(dr.GetValue(1));
                    if (dr.FieldCount == 3)
                    {
                        Comun.EtiquetaDos = Convert.ToString(dr.GetValue(2));

                    }
                    else if (dr.FieldCount == 4)
                    {

                        Comun.EtiquetaDos = Convert.ToString(dr.GetValue(2));
                        Comun.EtiquetaTres = Convert.ToString(dr.GetValue(3));
                    }
                    else if (dr.FieldCount == 5)
                    {

                        Comun.EtiquetaDos = Convert.ToString(dr.GetValue(2));
                        Comun.EtiquetaTres = Convert.ToString(dr.GetValue(3));
                        Comun.EtiquetaCuatro = Convert.ToString(dr.GetValue(4));
                    }
                    list.Add(Comun);
                }
                dr.Close();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                CDDatos.LimpiarOracleCommand(ref Cmm);
            }
        }

        //--Combo por Grupo--//
        public void LlenaComboG(string SP, ref List<Comun> list, string usuBD)
        {
            CD_Datos CDDatos = new CD_Datos(usuBD);
            OracleCommand Cmm = null;
            try
            {
                OracleDataReader dr = null;
                Cmm = CDDatos.GenerarOracleCommandCursor(SP, ref dr);

                Comun Comun = default(Comun);
                while (dr.Read())
                {

                    Comun = new Comun();
                    Comun.IdStr = Convert.ToString(dr.GetValue(0));
                    Comun.Descripcion = Convert.ToString(dr.GetValue(1));
                    Comun.Clasificacion = Convert.ToString(dr.GetValue(2));
                    if (dr.FieldCount == 3)
                    {

                        Comun.Etiqueta = Convert.ToString(dr.GetValue(2));

                    }
                    else if (dr.FieldCount == 4)
                    {

                        Comun.Etiqueta = Convert.ToString(dr.GetValue(2));
                        Comun.EtiquetaDos = Convert.ToString(dr.GetValue(3));
                    }
                    else if (dr.FieldCount == 5)
                    {

                        Comun.Etiqueta = Convert.ToString(dr.GetValue(2));
                        Comun.EtiquetaDos = Convert.ToString(dr.GetValue(3));
                        Comun.EtiquetaTres = Convert.ToString(dr.GetValue(4));
                    }
                    else if (dr.FieldCount == 6)
                    {

                        Comun.Etiqueta = Convert.ToString(dr.GetValue(2));
                        Comun.EtiquetaDos = Convert.ToString(dr.GetValue(3));
                        Comun.EtiquetaTres = Convert.ToString(dr.GetValue(4));
                        Comun.EtiquetaCuatro = Convert.ToString(dr.GetValue(5));
                    }
                    list.Add(Comun);
                }
                dr.Close();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                CDDatos.LimpiarOracleCommand(ref Cmm);
            }
        }
        public void LlenaComboG(string SP, ref List<Comun> list, string parametro1, string Valor1)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand Cmm = null;
            try
            {
                OracleDataReader dr = null;
                string[] Parametros = { parametro1 };
                object[] Valores = { Valor1 };
                Cmm = CDDatos.GenerarOracleCommandCursor(SP, ref dr, Parametros, Valores);
                Comun Comun = default(Comun);
                while (dr.Read())
                {

                    Comun = new Comun();
                    Comun.IdStr = Convert.ToString(dr.GetValue(0));
                    Comun.Descripcion = Convert.ToString(dr.GetValue(1));
                    Comun.Clasificacion = Convert.ToString(dr.GetValue(2));
                    if (dr.FieldCount == 3)
                    {

                        Comun.Etiqueta = Convert.ToString(dr.GetValue(2));

                    }
                    else if (dr.FieldCount == 4)
                    {

                        Comun.Etiqueta = Convert.ToString(dr.GetValue(2));
                        Comun.EtiquetaDos = Convert.ToString(dr.GetValue(3));
                    }
                    else if (dr.FieldCount == 5)
                    {

                        Comun.Etiqueta = Convert.ToString(dr.GetValue(2));
                        Comun.EtiquetaDos = Convert.ToString(dr.GetValue(3));
                        Comun.EtiquetaTres = Convert.ToString(dr.GetValue(4));
                    }
                    else if (dr.FieldCount == 6)
                    {

                        Comun.Etiqueta = Convert.ToString(dr.GetValue(2));
                        Comun.EtiquetaDos = Convert.ToString(dr.GetValue(3));
                        Comun.EtiquetaTres = Convert.ToString(dr.GetValue(4));
                        Comun.EtiquetaCuatro = Convert.ToString(dr.GetValue(5));
                    }
                    list.Add(Comun);
                }
                dr.Close();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                CDDatos.LimpiarOracleCommand(ref Cmm);
            }
        }
        public void LlenaComboG(string SP, ref List<Comun> list, string parametro1, string Valor1, string usuBD)
        {
            CD_Datos CDDatos = new CD_Datos(usuBD);
            OracleCommand Cmm = null;
            try
            {
                OracleDataReader dr = null;


                string[] Parametros = { parametro1 };
                object[] Valores = { Valor1 };

                Cmm = CDDatos.GenerarOracleCommandCursor(SP, ref dr, Parametros, Valores);

                Comun Comun = default(Comun);
                while (dr.Read())
                {
                    Comun = new Comun();
                    Comun.IdStr = Convert.ToString(dr.GetValue(0));
                    Comun.Descripcion = Convert.ToString(dr.GetValue(1));
                    Comun.Clasificacion = Convert.ToString(dr.GetValue(2));
                    if (dr.FieldCount == 3)
                    {

                        Comun.EtiquetaDos = Convert.ToString(dr.GetValue(2));

                    }
                    else if (dr.FieldCount == 4)
                    {

                        Comun.EtiquetaDos = Convert.ToString(dr.GetValue(2));
                        Comun.EtiquetaTres = Convert.ToString(dr.GetValue(3));
                    }
                    else if (dr.FieldCount == 5)
                    {

                        Comun.EtiquetaDos = Convert.ToString(dr.GetValue(2));
                        Comun.EtiquetaTres = Convert.ToString(dr.GetValue(3));
                        Comun.EtiquetaCuatro = Convert.ToString(dr.GetValue(4));
                    }
                    else if (dr.FieldCount == 6)
                    {

                        Comun.EtiquetaDos = Convert.ToString(dr.GetValue(2));
                        Comun.EtiquetaTres = Convert.ToString(dr.GetValue(3));
                        Comun.EtiquetaCuatro = Convert.ToString(dr.GetValue(4));
                        Comun.EtiquetaCinco = Convert.ToString(dr.GetValue(5));
                    }
                    list.Add(Comun);
                }
                dr.Close();
                // CDDatos.LimpiarOracleCommand(ref Cmm);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                CDDatos.LimpiarOracleCommand(ref Cmm);
            }
        }
        /*public void LlenaComboG(string SP, ref List<Comun> list, string parametro1, string Valor1, string usuBD)
        {
            CD_Datos CDDatos = new CD_Datos(usuBD);
            OracleCommand Cmm = null;
            try
            {
                OracleDataReader dr = null;


                string[] Parametros = { parametro1 };
                object[] Valores = { Valor1 };

                Cmm = CDDatos.GenerarOracleCommandCursor(SP, ref dr, Parametros, Valores);

                Comun Comun = default(Comun);
                while (dr.Read())
                {
                    Comun = new Comun();
                    Comun.IdStr = Convert.ToString(dr.GetValue(0));
                    Comun.Descripcion = Convert.ToString(dr.GetValue(1));
                    Comun.Clasificacion = Convert.ToString(dr.GetValue(2));
                    if (dr.FieldCount == 3)
                    {

                        Comun.EtiquetaDos = Convert.ToString(dr.GetValue(2));

                    }
                    else if (dr.FieldCount == 4)
                    {

                        Comun.EtiquetaDos = Convert.ToString(dr.GetValue(2));
                        Comun.EtiquetaTres = Convert.ToString(dr.GetValue(3));
                    }
                    else if (dr.FieldCount == 5)
                    {

                        Comun.EtiquetaDos = Convert.ToString(dr.GetValue(2));
                        Comun.EtiquetaTres = Convert.ToString(dr.GetValue(3));
                        Comun.EtiquetaCuatro = Convert.ToString(dr.GetValue(4));
                    }
                    list.Add(Comun);
                }
                dr.Close();
                // CDDatos.LimpiarOracleCommand(ref Cmm);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                CDDatos.LimpiarOracleCommand(ref Cmm);
            }
        }
        */
        public void LlenaComboG(string SP, ref List<Comun> list)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand Cmm = null;
            try
            {
                OracleDataReader dr = null;

                Cmm = CDDatos.GenerarOracleCommandCursor(SP, ref dr);

                Comun Comun = default(Comun);
                while (dr.Read())
                {

                    Comun = new Comun();
                    Comun.IdStr = Convert.ToString(dr.GetValue(0));
                    Comun.Descripcion = Convert.ToString(dr.GetValue(1));
                    Comun.Clasificacion = Convert.ToString(dr.GetValue(2));
                    if (dr.FieldCount == 3)
                    {
                        Comun.EtiquetaDos = Convert.ToString(dr.GetValue(2));

                    }
                    else if (dr.FieldCount == 4)
                    {

                        Comun.EtiquetaDos = Convert.ToString(dr.GetValue(2));
                        Comun.EtiquetaTres = Convert.ToString(dr.GetValue(3));
                    }
                    else if (dr.FieldCount == 5)
                    {

                        Comun.EtiquetaDos = Convert.ToString(dr.GetValue(2));
                        Comun.EtiquetaTres = Convert.ToString(dr.GetValue(3));
                        Comun.EtiquetaCuatro = Convert.ToString(dr.GetValue(4));
                    }
                    list.Add(Comun);
                }
                dr.Close();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                CDDatos.LimpiarOracleCommand(ref Cmm);
            }
        }
        //--Termina Combo por Grupo//

        //-- --//
        public void Graficas(string SP, string Usuario, ref string[] datosX, ref int[] datosY, string UsuBD)
        {
            CD_Datos CDDatos = new CD_Datos(UsuBD);
            OracleCommand cmm = null;
            int i = 0;
            try
            {
                OracleDataReader dr = null;
                String[] Parametros = { "p_usuario" };
                String[] Valores = { Usuario };

                cmm = CDDatos.GenerarOracleCommandCursor(SP, ref dr, Parametros, Valores);

                while (dr.Read())
                {
                    //string s = Convert.ToString(dr.GetValue(1));

                    Array.Resize(ref datosX, datosX.Length + 1);
                    Array.Resize(ref datosY, datosY.Length + 1);

                    datosX[i] = Convert.ToString(dr.GetValue(0));
                    datosY[i] = Convert.ToInt32(dr.GetValue(1));
                    i++;
                }

                //Array.Resize(ref datosX, i);

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





        //--Mensajes a los Usuarios Dependencias--//
        public void Consultar_Observaciones(string Usuario, int Id_Sistema, string TipoUsuario, ref string observaciones, string Usu_Central, ref string Verificador)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand Cmd = null;
            try
            {
                string[] ParametrosIn = { "P_USUARIO", "P_TIPO_USUARIO", "P_USUARIO_CENTRAL" };
                object[] Valores = { Usuario, TipoUsuario, Usu_Central };
                string[] ParametrosOut = { "P_OBSERVACIONES", "P_OBSERVACIONES2", "P_BANDERA" };

                Cmd = CDDatos.GenerarOracleCommand("OBT_OBSERVACIONES", ref Verificador, ParametrosIn, Valores, ParametrosOut);
                if (Verificador == "0")
                {
                    observaciones = Convert.ToString(Cmd.Parameters["p_observaciones"].Value)+ Convert.ToString(Cmd.Parameters["P_OBSERVACIONES2"].Value);
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
