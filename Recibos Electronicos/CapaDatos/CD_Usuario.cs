using System;
using System.Collections.Generic;
using System.Text;
using System.Data.OracleClient;
using System.Globalization;
using CapaEntidad;
#region Hecho por
//Nombre:      Melissa Alejandra Rodríguez González
//Correo:      melissargz@hotmail.com
//Institución: Unach
#endregion

namespace CapaDatos
{
    public class CD_Usuario
    {
        public void ValidarUsuario(ref Sesion Usuario,ref string  Verificador )
        {
            CD_Datos _CD_Datos = new CD_Datos();
            OracleCommand cmm = null;
            try
            {
              string[] ParametrosIn ={ "p_usuario", "p_contrasena", "p_tipo_usuario", "p_sistema" };
              
              string[] Valores ={ Usuario.Usu_Nombre, Usuario.Usu_NoControl, Usuario.Usu_TipoUsu.ToString(), "14" };
             
                
              string[] ParametrosOut ={ "p_Bandera"};
             
              cmm= _CD_Datos.GenerarOracleCommand("PKG_FELECTRONICA_2016.VAL_USUARIO", ref Verificador , ParametrosIn, Valores,ParametrosOut);

              
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + "Se ha perdido la conexión, por favor intente más tarde");
            }
            finally 
            {
                _CD_Datos.LimpiarOracleCommand(ref cmm);
            }
        
        }
        public void ValidarUsuarioFactura(ref Usuario usuario, ref string Verificador)
        {
            CD_Datos _CD_Datos = new CD_Datos();
            OracleCommand cmm = null;
            try
            {
                string[] ParametrosIn = { "P_USUARIO" };

                string[] Valores = { usuario.Usu_Nombre };


                string[] ParametrosOut = { "P_TIPO_USUARIO", "P_BANDERA" };

                cmm = _CD_Datos.GenerarOracleCommand("USUARIO_CENTRAL_FACTURACION", ref Verificador, ParametrosIn, Valores, ParametrosOut);
                usuario.Tipo_Usu_Factura = Convert.ToString(cmm.Parameters["P_TIPO_USUARIO"].Value);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + "Se ha perdido la conexión, por favor intente más tarde");
            }
            finally
            {
                _CD_Datos.LimpiarOracleCommand(ref cmm);
            }

        }

        public void ValidarCliente(ref Sesion Usuario, ref string Verificador)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand Cmd = null;
            try
            {

                String[] Parametros = { "P_CLAVE" };
                Object[] Valores = { Usuario.Usu_Nombre };
                String[] ParametrosOut = { "P_BANDERA" };
                Cmd = CDDatos.GenerarOracleCommand("VAL_USUARIO_CLIENTE", ref Verificador, Parametros, Valores, ParametrosOut);
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

        public void ValidarUsuarioDependencia(ref CapaEntidad.Usuario Usuario, ref string Verificador)
        {
            CD_Datos _CD_Datos = new CD_Datos();
            OracleCommand cmm = null;
            try
            {
                string[] ParametrosIn = { "P_USUARIO", "P_PASSWORD" };

                string[] Valores = { Usuario.Usu_Nombre, Usuario.Usu_NoControl };


                string[] ParametrosOut = { "P_STATUS", "P_BANDERA" };

                cmm = _CD_Datos.GenerarOracleCommand("VAL_USUARIO_SISTEMA", ref Verificador, ParametrosIn, Valores, ParametrosOut);
                //objComision.FECHA = Convert.ToString(cmm.Parameters["P_FECHA"].Value);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + "Se ha perdido la conexión, por favor intente más tarde");
            }
            finally
            {
                _CD_Datos.LimpiarOracleCommand(ref cmm);
            }

        }

        public void ObtenerUsuario(ref Usuario ObjUsuario, ref string Verificador)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand Cmd = null;
            try
            {
                string[] ParametrosIn = { "P_CORREO", "P_ID_SISTEMA" };
                object[] Valores = { ObjUsuario.Correo_UNACH, 14 };
                string[] ParametrosOut = { "P_USUARIO", "P_BANDERA" };

                Cmd = CDDatos.GenerarOracleCommand("VAL_USUARIO_SISTEMA", ref Verificador, ParametrosIn, Valores, ParametrosOut);
                if (Verificador == "0")
                {
                    ObjUsuario = new Usuario();
                    ObjUsuario.CUsuario = Convert.ToString(Cmd.Parameters["P_USUARIO"].Value);
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


        public void PermisoUsuario(ref Usuario Usuario, ref string Verificador)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand Cmd = null;
            try
            {

                String[] Parametros = { "P_usuario", "P_Id_Sistema", "P_Id_Modulo" };
                Object[] Valores = { Usuario.Usu_Nombre,"14",Usuario.Usu_IdModulo};
                String[] ParametrosOut = { "P_Clave", "p_Bandera" };
                Cmd = CDDatos.GenerarOracleCommand("OBT_PERMISOS_USUARIO", ref Verificador, Parametros, Valores, ParametrosOut);
                if (Verificador == "0")
                {
                    Usuario.Usu_TipoPermiso = Convert.ToString(Cmd.Parameters["P_Clave"].Value);
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
        public void UsuarioCentral(ref Sesion Sesion, ref string Verificador)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand Cmd = null;
            try
            {

                String[] Parametros = { "P_USUARIO" };
                Object[] Valores = { Sesion.Usu_Nombre };
                String[] ParametrosOut = { "P_RESULTADO", "P_TIPO_USUARIO", "P_BANDERA" };
                Cmd = CDDatos.GenerarOracleCommand("USUARIO_CENTRAL", ref Verificador, Parametros, Valores, ParametrosOut);
                if (Verificador == "0")
                {
                    Sesion.Usu_Central = Convert.ToString(Cmd.Parameters["P_RESULTADO"].Value);
                    Sesion.Usu_Central_Tipo = Convert.ToString(Cmd.Parameters["P_TIPO_USUARIO"].Value);
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
        public void UsuarioPermisos(ref Sesion Sesion, string Correo, ref string Verificador)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand Cmd = null;
            try
            {

                String[] Parametros = { "P_CORREO" };
                Object[] Valores = { Correo };
                String[] ParametrosOut = { "P_USUARIO", "P_TIPO_USUARIO", "P_RESULTADO", "P_BANDERA" };
                Cmd = CDDatos.GenerarOracleCommand("OBT_USUARIO_PERMISOS", ref Verificador, Parametros, Valores, ParametrosOut);
                if (Verificador == "0")
                {
                    Sesion.Usuario = Convert.ToString(Cmd.Parameters["P_USUARIO"].Value);
                    Sesion.Usu_Central = Convert.ToString(Cmd.Parameters["P_RESULTADO"].Value);
                    Sesion.Usu_Central_Tipo = Convert.ToString(Cmd.Parameters["P_TIPO_USUARIO"].Value);
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

        public void Verificar_Correo_Telefono(ref Sesion Sesion, ref string Verificador)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand Cmd = null;
            try
            {

                String[] Parametros = { "P_USUARIO" };
                Object[] Valores = { Sesion.Usu_Nombre };
                String[] ParametrosOut = { "P_RESULTADO", "p_bandera" };
                Cmd = CDDatos.GenerarOracleCommand("OBT_STATUS_MAIL_TEL_USER", ref Verificador, Parametros, Valores, ParametrosOut);
                if (Verificador == "0")
                {
                    Sesion.Status = Convert.ToString(Cmd.Parameters["P_RESULTADO"].Value);
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

        public void Act_Correo_Telefono(ref Usuario Usuario, ref string Verificador)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand Cmd = null;
            try
            {
                String[] Parametros = { "P_usuario", "p_correo", "p_telefonos" };
                object[] Valores = { Usuario.Usu_Nombre, Usuario.Correo, Usuario.Telefono };
                String[] ParametrosOut = { "p_Bandera" };

                Cmd = CDDatos.GenerarOracleCommand("UPD_EMAIL_TEL_USU", ref Verificador, Parametros, Valores, ParametrosOut);
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

        public void Inserta_Token(ref Usuario Usuario, ref string Verificador)
        {
            CD_Datos CDDatos = new CD_Datos("INGRESOS");
            OracleCommand Cmd = null;
            try
            {
                String[] Parametros = { "p_token", "p_usuario" };
                object[] Valores = { Usuario.Token, Usuario.CUsuario };
                String[] ParametrosOut = { "p_bandera" };

                Cmd = CDDatos.GenerarOracleCommand("SIGA09.ins_sistemas_token", ref Verificador, Parametros, Valores, ParametrosOut);
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

        public void Inserta_Token_Emp(ref Usuario Usuario, ref string Verificador)
        {
            CD_Datos CDDatos = new CD_Datos("INGRESOS");
            OracleCommand Cmd = null;
            try
            {
                String[] Parametros = { "p_token", "p_usuario", "p_id_sistema" };
                object[] Valores = { Usuario.Token, Usuario.CUsuario, "15533" };
                String[] ParametrosOut = { "p_bandera" };


                Cmd = CDDatos.GenerarOracleCommand("SIGA09.ins_sistemas_token", ref Verificador, Parametros, Valores, ParametrosOut);
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


        public void ValidarToken(ref Usuario ObjUsuario, ref string Verificador)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand Cmd = null;
            try
            {
                string[] ParametrosIn = { "p_token" };
                object[] Valores = { ObjUsuario.Token };
                string[] ParametrosOut = { "p_usuario", "p_contrasena", "p_bandera" };

                Cmd = CDDatos.GenerarOracleCommand("SIGA09.SEL_SISTEMAS_TOKEN", ref Verificador, ParametrosIn, Valores, ParametrosOut);
                if (Verificador == "0")
                {
                    ObjUsuario = new Usuario();
                    ObjUsuario.Usu_Nombre = Convert.ToString(Cmd.Parameters["p_usuario"].Value);
                    ObjUsuario.Password = Convert.ToString(Cmd.Parameters["p_contrasena"].Value);

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


        public void EncriptarUsuario(Usuario ObjUsuario, ref string WXI, ref string Verificador)
        {
            CD_Datos CDDatos = new CD_Datos("INGRESOS");
            OracleCommand Cmd = null;
            try
            {
                string[] ParametrosIn = { "P_USUARIO" };
                object[] Valores = { ObjUsuario.Usu_Nombre };
                string[] ParametrosOut = { "P_WXI", "P_BANDERA" };

                Cmd = CDDatos.GenerarOracleCommand("OBT_WXI", ref Verificador, ParametrosIn, Valores, ParametrosOut);
                if (Verificador == "0")
                {
                    ObjUsuario = new Usuario();
                    WXI = Convert.ToString(Cmd.Parameters["P_WXI"].Value);        
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
