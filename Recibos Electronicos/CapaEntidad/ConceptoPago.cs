 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapaEntidad
{
    public class ConceptoPago:Usuario
    {
        private int _Id;

        public int Id
        {
            get { return _Id; }
            set { _Id = value; }
        }
        private int _IdConcepto;

        public int IdConcepto
        {
            get { return _IdConcepto; }
            set { _IdConcepto = value; }
        }

        private int _IdFichaBancaria;

        public int IdFichaBancaria
        {
            get { return _IdFichaBancaria; }
            set { _IdFichaBancaria = value; }
        }
        
        private string _Tipo;

        public string Tipo
        {
            get { return _Tipo; }
            set { _Tipo = value; }
        }

        private string _SubTipo;

        public string SubTipo
        {
            get { return _SubTipo; }
            set { _SubTipo = value; }
        }

        private string _ClaveConcepto;

        public string ClaveConcepto
        {
            get { return _ClaveConcepto; }
            set { _ClaveConcepto = value; }
        }

        private string _DescripcionConcepto;

        public string Descripcion
        {
            get { return _DescripcionConcepto; }
            set { _DescripcionConcepto = value; }
        }
        private double _ImporteConcepto;

        public double ImporteConcepto
        {
            get { return _ImporteConcepto; }
            set { _ImporteConcepto = value; }
        }

        private char _EmitirWeb;

        public char EmitirWeb
        {
            get { return _EmitirWeb; }
            set { _EmitirWeb = value; }
        }

        private char _Status;

        public char Status
        {
            get { return _Status; }
            set { _Status = value; }
        }
        private string _StatusStr;

        public string StatusStr
        {
            get { return _StatusStr; }
            set { _StatusStr = value; }
        }
        private char _Bloqueado;

        public char Bloqueado
        {
            get { return _Bloqueado; }
            set { _Bloqueado = value; }
        }
        private char _AplicaDescuento;

        public char AplicaDescuento
        {
            get { return _AplicaDescuento; }
            set { _AplicaDescuento = value; }
        }
        private char _PermiteDuplicidad;

        public char PermiteDuplicidad
        {
            get { return _PermiteDuplicidad; }
            set { _PermiteDuplicidad = value; }
        }
        private char _CobroXMateria;

        public char CobroXMateria
        {
            get { return _CobroXMateria; }
            set { _CobroXMateria = value; }
        }
        private string _CobroXMateriaStr;

        public string CobroXMateriaStr
        {
            get { return _CobroXMateriaStr; }
            set { _CobroXMateriaStr = value; }
        }
        private char _Periodo;

        public char Periodo
        {
            get { return _Periodo; }
            set { _Periodo = value; }
        }
        private string _MaxMateria="99";

        public string MaxMateria
        {
            get { return _MaxMateria; }
            set { _MaxMateria = value; }  
        }
        private string _FechaFinal;

        public string FechaFinal
        {
            get { return _FechaFinal; }
            set { _FechaFinal = value; }
        }
        private string _FechaInicial;

        public string FechaInicial
        {
            get { return _FechaInicial; }
            set { _FechaInicial = value; }
        }
        private string _Nivel;

        public string Nivel
        {
            get { return _Nivel; }
            set { _Nivel = value; }
        }

        private string _DescNivel;

        public string DescNivel
        {
            get { return _DescNivel; }
            set { _DescNivel = value; }
        }
        private string _Anexo;

        public string Anexo
        {
            get { return _Anexo; }
            set { _Anexo = value; }
        }
        private int _Donativo;

        public int Donativo
        {
            get { return _Donativo; }
            set { _Donativo = value; }
        }
        private string _Carrera;

        public string Carrera
        {
            get { return _Carrera; }
            set { _Carrera = value; }
        }
        private string _TipoPersonaStr; 

        public string TipoPersonaStr
        {
            get { return _TipoPersonaStr; }
            set { _TipoPersonaStr = value; }
        }
        private string _Dependencia;

        public string Dependencia
        {
            get { return _Dependencia.Trim(); }
            set { _Dependencia = value.Trim(); }
        }

       
        private int _DiasVigencia;

        public int DiasVigencia
        {
            get { return _DiasVigencia; }
            set { _DiasVigencia = value; }
        }

        private string _FechaVigencia;
        public string FechaVigencia
        {
            get { return _FechaVigencia; }
            set { _FechaVigencia = value; }
        }

        private int _CicloEscolar;
        public int CicloEscolar
        {
            get { return _CicloEscolar; }
            set { _CicloEscolar = value; }
        }

        private string _Evento=string.Empty;
        public string Evento
        {
            get { return _Evento.Trim(); }
            set { _Evento = value.Trim(); }
        }

        private string _Seleccionable;
        public string Seleccionable
        {
            get { return _Seleccionable.Trim(); }
            set { _Seleccionable = value.Trim(); }
        }

        private string _Observaciones;
        public string Observaciones
        {
            get { return _Observaciones.Trim(); }
            set { _Observaciones = value.Trim(); }
        }

        private string _Porcentaje;
        public string Porcentaje
        {
            get { return _Porcentaje; }
            set { _Porcentaje = value; }
        }


        private bool _Habilita;
        public bool Habilita
        {
            get { return _Habilita; }
            set { _Habilita = value; }
        }

        private bool _VisibleTxtImporte;
        public bool VisibleTxtImporte
        {
            get { return _VisibleTxtImporte; }
            set { _VisibleTxtImporte = value; }
        }

        private bool _VisibleLblImporte;
        public bool VisibleLblImporte
        {
            get { return _VisibleLblImporte; }
            set { _VisibleLblImporte = value; }
        }

        //private Comun _tiporegistro = new Comun();
        //public Comun tiporegistro
        //{

        //    get { return _tiporegistro; }
        //    set { _tiporegistro = value; }
        //}
    }
}
