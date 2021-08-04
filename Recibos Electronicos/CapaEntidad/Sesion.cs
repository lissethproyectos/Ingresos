using System;
using System.Collections.Generic;
using System.Text;

namespace CapaEntidad
{
    public class Sesion
    {
        private String _Usu_Nombre;   //(Nombre, Nombre, Contraseña)        
        private string _Usu_Ejercicio;
        private int _Id_Comprobante;       
        private int _Id_Concepto;
        private string _Correo_UNACH;
        private string _Nombre_Completo;

        public string Nombre_Completo
        {
            get { return _Nombre_Completo; }
            set { _Nombre_Completo = value; }
        }

        public string Correo_UNACH
        {
            get { return _Correo_UNACH; }
            set { _Correo_UNACH = value; }
        }
        public int Id_Concepto
        {
            get { return _Id_Concepto; }
            set { _Id_Concepto = value; }
        }


        private string _Usuario;
        public string Usuario
        {
            get { return _Usuario; }
            set { _Usuario = value; }
        }

        private int _Editar;
        public int Editar
        {
            get { return _Editar; }
            set { _Editar = value; }
        }

        private int _Id_Persona;
        public int Id_Persona
        {
            get { return _Id_Persona; }
            set { _Id_Persona = value; }
        }
        
        private string _Dependencia;
        public string Dependencia
        {
            get { return _Dependencia; }
            set { _Dependencia = value; }
        }

        private string _Evento;
        public string Evento
        {
            get { return _Evento; }
            set { _Evento = value; }
        }

        private int _IdEvento;
        public int IdEvento
        {
            get { return _IdEvento; }
            set { _IdEvento = value; }
        }

        private string _Matricula;
        public string Matricula
        {
            get { return _Matricula; }
            set { _Matricula = value; }
        }

        private string _NivelEstudio;
        public string NivelEstudio
        {
            get { return _NivelEstudio; }
            set { _NivelEstudio = value; }
        }

        private char _Exento;
        public char Exento
        {
            get { return _Exento; }
            set { _Exento = value; }
        }

        private string _Reporte;
        public string Reporte
        {
            get { return _Reporte; }
            set { _Reporte = value; }
        }

        private string _ReporteEnExcel;
        public string ReporteEnExcel
        {
            get { return _ReporteEnExcel; }
            set { _ReporteEnExcel = value; }
        }

        private string _ReporteconGraficas;
        public string ReporteconGraficas
        {
            get { return _ReporteconGraficas; }
            set { _ReporteconGraficas = value; }
        }

        public int Id_Comprobante
        {
            get { return _Id_Comprobante; }
            set { _Id_Comprobante = value; }
        }
       
        public string Usu_Ejercicio
        {
            get { return _Usu_Ejercicio.Trim(); }
            set { _Usu_Ejercicio = value.Trim(); }
        }       
        public string Usu_Nombre
        {
            get { return _Usu_Nombre.Trim(); }
            set { _Usu_Nombre = value.Trim(); }
        }

        private int _Usu_TipoUsu;//(1,2,3)
        public int Usu_TipoUsu
        {
            get { return _Usu_TipoUsu; }
            set { _Usu_TipoUsu = value; }
        }

        private string _Usu_Central;//(S,N) Si es un Usuario de Finanzas
        public string Usu_Central
        {
            get { return _Usu_Central; }
            set { _Usu_Central = value; }
        }

        private string _Usu_Central_Tipo;//(S,N) Si es un Usuario de Finanzas
        public string Usu_Central_Tipo
        {
            get { return _Usu_Central_Tipo; }
            set { _Usu_Central_Tipo = value; }
        }

        private string _Usu_Admon;//(S,N) Si es un Usuario de Finanzas
        public string Usu_Admon
        {
            get { return _Usu_Admon; }
            set { _Usu_Admon = value; }
        }

        private String _Usu_NoControl;//(Matricula, RFC, Usuario)
        public string Usu_NoControl
        {
            get { return _Usu_NoControl; }
            set { _Usu_NoControl = value; }
        }

        private int _Row;
        public int Row
        {
            get { return _Row; }
            set { _Row = value; }
        }

        private int _Id_Oficio;
        public int Id_Oficio
        {
            get { return _Id_Oficio; }
            set { _Id_Oficio = value; }
        }

        private string _Status;
        public string Status
        {
            get { return _Status; }
            set { _Status = value; }
        }
    }
}
