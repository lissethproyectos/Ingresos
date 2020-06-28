using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapaEntidad
{
    public class Persona
    {
        private int _IdPersona;

        public int IdPersona
        {
            get { return _IdPersona; }
            set { _IdPersona = value; }
        }
        private int _TipoPersona;

        public int TipoPersona
        {
            get { return _TipoPersona; }
            set { _TipoPersona = value; }
        }
        private string _TipoPersonaStr;

        public string TipoPersonaStr
        {
            get { return _TipoPersonaStr; }
            set { _TipoPersonaStr = value; }
        }
        private string _Evento;

        public string Evento
        {
            get { return _Evento.Trim(); }
            set { _Evento = value.Trim(); }
        }
        private char _StatusEvento;

        public char StatusEvento
        {
            get { return _StatusEvento; }
            set { _StatusEvento = value; }
        }
        private string _APaterno;

        public string APaterno
        {
            get { return _APaterno.Trim(); }
            set { _APaterno = value.Trim(); }
        }
        private string _AMaterno;

        public string AMaterno
        {
            get { return _AMaterno.Trim(); }
            set { _AMaterno = value.Trim(); }
        }
        private string _Nombre;

        public string Nombre
        {
            get { return _Nombre.Trim(); }
            set { _Nombre = value.Trim(); }
        }
        private string _Dependencia;

        public string Dependencia
        {
            get { return _Dependencia.Trim(); }
            set { _Dependencia = value.Trim(); }
        }
        private char _Genero;

        public char Genero
        {
            get { return _Genero; }
            set { _Genero = value; }
        }
        private string _GradoEstudio;

        public string GradoEstudio
        {
            get { return _GradoEstudio; }
            set { _GradoEstudio = value; }
        }
        private string _Constancia;

        public string Constancia
        {
            get { return _Constancia.Trim(); }
            set { _Constancia = value.Trim(); }
        }
        private int _PeriodoPago;

        public int PeriodoPago
        {
            get { return _PeriodoPago; }
            set { _PeriodoPago = value; }
        }
        private string _Correo;

        public string Correo
        {
            get { return _Correo.Trim(); }
            set { _Correo = value.Trim(); }
        }
        private string _NoControl;

        public string NoControl
        {
            get { return _NoControl.Trim(); }
            set { _NoControl = value.Trim(); }
        }
        private string _Referencia;

        public string Referencia
        {
            get { return _Referencia.Trim(); }
            set { _Referencia = value.Trim(); }
        }
    }
}
