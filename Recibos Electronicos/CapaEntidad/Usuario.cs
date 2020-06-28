using System;
using System.Collections.Generic;
using System.Text;

namespace CapaEntidad
{
    public class Usuario
    {
        //private String _Id_Usu; 
        private String _Usu_Nombre;   //(Nombre, Nombre, Contraseña)
        private String _Usu_NoControl;//(Matricula, RFC, Usuario)
        private int _Usu_TipoUsu;//(1=alumno,2=persona externa,3=usuario dependencia)
        private int _Usu_IdModulo; //(Id del Formulario de la tabla Grl_Sistemas)
        private String _Usu_TipoPermiso;
        private String _Correo;
        private String _Telefono;
        private string _Token;
        private string _usuario;
        private string _Password;
        private string _CUsuario;
        private string _Correo_UNACH;
        //private String _Usu_Dependencias;//(Son las dependencias que va a poder visualizar el usuario logeado)


        //public String Id_Usu
        //{
        //    get { return _Id_Usu.Trim(); }
        //    set { _Id_Usu = value.Trim(); }
        //}
        public string Correo_UNACH
        {
            get { return _Correo_UNACH; }
            set { _Correo_UNACH = value; }
        }


        public string usuario
        {
            get { return _usuario; }
            set { _usuario = value; }
        }

        public string Token
        {
            get { return _Token; }
            set { _Token = value; }
        }

        public string CUsuario
        {
            get { return _CUsuario; }
            set { _CUsuario = value; }
        }

        public String Correo
        {
            get { return _Correo.Trim(); }
            set { _Correo = value.Trim(); }
        }

        public String Telefono
        {
            get { return _Telefono.Trim(); }
            set { _Telefono = value.Trim(); }
        }
        public String Usu_Nombre
        {
            get { return _Usu_Nombre.Trim(); }
            set { _Usu_Nombre = value.Trim(); }
        }        
        public String Usu_NoControl
        {
            get { return _Usu_NoControl.Trim(); }
            set { _Usu_NoControl = value.Trim(); }
        }        
        public int Usu_TipoUsu
        {
            get { return _Usu_TipoUsu; }
            set { _Usu_TipoUsu = value; }
        }
        public int Usu_IdModulo
        {
            get { return _Usu_IdModulo; }
            set { _Usu_IdModulo = value; }
        }
        public String Usu_TipoPermiso
        {
            get { return _Usu_TipoPermiso; }
            set { _Usu_TipoPermiso = value; }
        }

        public string Password
        {
            get { return _Password.Trim(); }
            set { _Password = value.Trim(); }
        }
        //public String Usu_Dependencias
        //{
        //    get { return _Usu_Dependencias.Trim(); }
        //    set { _Usu_Dependencias.Trim(); }
        //}
    }
}
