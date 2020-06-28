using System;
using System.Collections.Generic;
using System.Text;
using CapaDatos;
using CapaEntidad;

namespace CapaNegocio
{
    public class CN_Usuario
    {
        public void ValidarUsuario(ref Sesion Usuario, ref string Verificador)
        {
            try
            {
                CapaDatos.CD_Usuario CD_Usuario = new CapaDatos.CD_Usuario();
                CD_Usuario.ValidarUsuario(ref Usuario, ref Verificador);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        public void ValidarCliente(ref Sesion Usuario, ref string Verificador)
        {
            try
            {
                CapaDatos.CD_Usuario CD_Usuario = new CapaDatos.CD_Usuario();
                CD_Usuario.ValidarCliente(ref Usuario, ref Verificador);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public void ValidarUsuarioDependencia(ref Usuario Usuario, ref string Verificador)
        {
            try
            {
                CapaDatos.CD_Usuario CD_Usuario = new CapaDatos.CD_Usuario();
                CD_Usuario.ValidarUsuarioDependencia(ref Usuario, ref Verificador);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        public void PermisoUsuario(ref Usuario Usuario, ref string Verificador)
        {
            try
            {
                CapaDatos.CD_Usuario CD_Usuario = new CapaDatos.CD_Usuario();
                CD_Usuario.PermisoUsuario(ref Usuario, ref Verificador);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        public void UsuarioCentral(ref Sesion Sesion, ref string Verificador)
        {
            try
            {
                CD_Usuario CD_Usuario = new CapaDatos.CD_Usuario();
                CD_Usuario.UsuarioCentral(ref Sesion, ref Verificador);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public void UsuarioPermisos(ref Sesion Sesion, string Correo, ref string Verificador)
        {
            try
            {
                CD_Usuario CD_Usuario = new CapaDatos.CD_Usuario();
                CD_Usuario.UsuarioPermisos(ref Sesion, Correo, ref Verificador);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }



        public void Verificar_Correo_Telefono(ref Sesion Sesion, ref string Verificador)
        {
            try
            {
                CD_Usuario CD_Usuario = new CapaDatos.CD_Usuario();
                CD_Usuario.Verificar_Correo_Telefono(ref Sesion, ref Verificador);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public void Act_Correo_Telefono(Usuario Usuario, ref string Verificador)
        {
            try
            {
                CD_Usuario CD_Usuario = new CapaDatos.CD_Usuario();
                CD_Usuario.Act_Correo_Telefono(ref Usuario, ref Verificador);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public void Inserta_Token(ref Usuario objBasicos, ref string Verificador)
        {
            try
            {
                CD_Usuario CD_Usuario = new CD_Usuario();
                CD_Usuario.Inserta_Token(ref objBasicos, ref Verificador);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Inserta_Token_Emp(ref Usuario objBasicos, ref string Verificador)
        {
            try
            {
                CD_Usuario CD_Usuario = new CD_Usuario();
                CD_Usuario.Inserta_Token_Emp(ref objBasicos, ref Verificador);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void ValidarToken(ref CapaEntidad.Usuario Usuario, ref string Verificador)
        {
            try
            {
                CapaDatos.CD_Usuario CD_Usuario = new CapaDatos.CD_Usuario();
                CD_Usuario.ValidarToken(ref Usuario, ref Verificador);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public void EncriptarUsuario(CapaEntidad.Usuario Usuario, ref string WXI, ref string Verificador)
        {
            try
            {
                CapaDatos.CD_Usuario CD_Usuario = new CapaDatos.CD_Usuario();
                CD_Usuario.EncriptarUsuario(Usuario, ref WXI, ref Verificador);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

    }       
}
