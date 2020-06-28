using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapaEntidad
{
    public class Mensaje
    {
        private int _IdMensaje;
        public int IdMensaje
        {
            get { return _IdMensaje; }
            set { _IdMensaje = value; }
        }

        private string _TMensaje;
        public string TMensaje
        {
            get { return _TMensaje; }
            set { _TMensaje = value; }
        }

        private string _Fecha_inicial;
        public string Fecha_inicial
        {
            get { return _Fecha_inicial; }
            set { _Fecha_inicial = value; }
        }

        private string _Fecha_final;
        public string Fecha_final
        {
            get { return _Fecha_final; }
            set { _Fecha_final = value; }
        }

        private string _Status;
        public string Status
        {
            get { return _Status; }
            set { _Status = value; }
        }

        private string _Tipo_Usuario;
        public string Tipo_Usuario
        {
            get { return _Tipo_Usuario; }
            set { _Tipo_Usuario = value; }
        }

        private string _Dependencia;
        public string Dependencia
        {
            get { return _Dependencia; }
            set { _Dependencia = value; }
        }

    }
}
