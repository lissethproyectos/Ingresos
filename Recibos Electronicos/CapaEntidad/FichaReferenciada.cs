using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapaEntidad
{
    public class FichaReferenciada
    {
        private int _IdFichaBancaria;
        public int IdFichaBancaria
        {
            get { return _IdFichaBancaria; }
            set { _IdFichaBancaria = value; }
        }

        private string _ConceptoRef;
        public string ConceptoRef
        {
            get { return _ConceptoRef; }
            set { _ConceptoRef = value; }
        }

        private string _Usuario;
        public string Usuario
        {
            get { return _Usuario; }
            set { _Usuario = value; }
        }

        private string _Referencia;
        public string Referencia
        {
            get { return _Referencia; }
            set { _Referencia = value; }
        }

        private string _UsuarioRegistra;
        public string UsuarioRegistra
        {
            get { return _UsuarioRegistra.Trim(); }
            set { _UsuarioRegistra = value.Trim(); }
        }

        //--DATOS FISCALES--//
        private string _TipoPersonaFiscal;
        public string TipoPersonaFiscal
        {
            get { return _TipoPersonaFiscal.Trim(); }
            set { _TipoPersonaFiscal = value.Trim(); }
        }

        private string _RFC;
        public string RFC
        {
            get { return _RFC.Trim(); }
            set { _RFC = value.Trim(); }
        }

        private string _RazonSocial;
        public string RazonSocial
        {
            get { return _RazonSocial.Trim(); }
            set { _RazonSocial = value.Trim(); }
        }

        private string _Domicilio;
        public string Domicilio
        {
            get { return _Domicilio.Trim(); }
            set { _Domicilio = value.Trim(); }
        }

        public string CalleFiscal
        {
            get { return _CalleFiscal.Trim(); }
            set { _CalleFiscal = value.Trim(); }
        }
        private string _CalleFiscal;

        public string ColoniaFiscal
        {
            get { return _ColoniaFiscal.Trim(); }
            set { _ColoniaFiscal = value.Trim(); }
        }
        private string _ColoniaFiscal;

        public string CPFiscal
        {
            get { return _CPFiscal.Trim(); }
            set { _CPFiscal = value.Trim(); }
        }
        private string _CPFiscal;

        public string EstadoFiscal
        {
            get { return _EstadoFiscal.Trim(); }
            set { _EstadoFiscal = value.Trim(); }
        }
        private string _EstadoFiscal;

        public string MunicipioFiscal
        {
            get { return _MunicipioFiscal.Trim(); }
            set { _MunicipioFiscal = value.Trim(); }
        }
        private string _MunicipioFiscal;

        public string TelefonoFiscal
        {
            get { return _TelefonoFiscal.Trim(); }
            set { _TelefonoFiscal = value.Trim(); }
        }
        private string _TelefonoFiscal;

        private string _CorreoFiscal;
        public string CorreoFiscal
        {
            get { return _CorreoFiscal.Trim(); }
            set { _CorreoFiscal = value.Trim(); }
        }

        private string _ComprobanteFiscal;
        public string ComprobanteFiscal
        {
            get { return _ComprobanteFiscal.Trim(); }
            set { _ComprobanteFiscal = value.Trim(); }
        }

        private string _MetodoPagoFiscal;
        public string MetodoPagoFiscal
        {
            get { return _MetodoPagoFiscal.Trim(); }
            set { _MetodoPagoFiscal = value.Trim(); }
        }
        //--FIN DATOS FISCALES--//

        private string _Ciudad;
        public string Ciudad
        {
            get { return _Ciudad.Trim(); }
            set { _Ciudad = value.Trim(); }
        }

        private double _Importetotal;
        public double Importetotal
        {
            get { return _Importetotal; }
            set { _Importetotal = value; }
        }

        private int _Vigencia;
        public int Vigencia
        {
            get { return _Vigencia; }
            set { _Vigencia = value; }
        }

        private string _Nombre;
        public string Nombre
        {
            get { return _Nombre; }
            set { _Nombre = value; }
        }

        private string _XMLCadena;
        public string XMLCadena
        {
            get { return _XMLCadena; }
            set { _XMLCadena = value; }
        }

        private string _Evento;
        public string Evento
        {
            get { return _Evento.Trim(); }
            set { _Evento = value.Trim(); }
        }

        private string _Dependencia;
        public string Dependencia
        {
            get { return _Dependencia.Trim(); }
            set { _Dependencia = value.Trim(); }
        }

        private string _NoControl;
        public string NoControl
        {
            get { return _NoControl.Trim(); }
            set { _NoControl = value.Trim(); }
        }

        private int _CicloEscolar;
        public int CicloEscolar
        {
            get { return _CicloEscolar; }
            set { _CicloEscolar = value; }
        }

        private string _Grupo;
        public string Grupo
        {
            get { return _Grupo; }
            set { _Grupo = value; }
        }

        private string _Semestre;
        public string Semestre
        {
            get { return _Semestre; }
            set { _Semestre = value; }
        }

        private string _Carrera;
        public string Carrera
        {
            get { return _Carrera; }
            set { _Carrera = value; }
        }

        private string _FechaVigencia;
        public string FechaVigencia
        {
            get { return _FechaVigencia; }
            set { _FechaVigencia = value; }
        }

        private string _Nivel;
        public string Nivel
        {
            get { return _Nivel; }
            set { _Nivel = value; }
        }


       

}
    

}
