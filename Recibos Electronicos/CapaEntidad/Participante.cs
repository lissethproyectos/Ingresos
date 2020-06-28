using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapaEntidad
{
    public class Participante:Persona
    {
        private string _Celular;

        public string Celular
        {
            get { return _Celular.Trim(); }
            set { _Celular = value.Trim(); }
        }
        private string _TelParticular;

        public string TelParticular
        {
            get { return _TelParticular.Trim(); }
            set { _TelParticular = value.Trim(); }
        }
        
        private string _CargoProcedencia;

        public string CargoProcedencia
        {
            get { return _CargoProcedencia.Trim(); }
            set { _CargoProcedencia = value.Trim(); }
        }
        
        private string _CiudadProcedencia;

        public string CiudadProcedencia
        {
            get { return _CiudadProcedencia.Trim(); }
            set { _CiudadProcedencia = value.Trim(); }
        }
        private string _DomicilioProcedencia;

        public string DomicilioProcedencia
        {
            get { return _DomicilioProcedencia.Trim(); }
            set { _DomicilioProcedencia = value.Trim(); }
        }
        private string _EstadoProcedencia;

        public string EstadoProcedencia
        {
            get { return _EstadoProcedencia; }
            set { _EstadoProcedencia = value; }
        }
        private string _TelProcedencia;

        public string TelProcedencia
        {
            get { return _TelProcedencia.Trim(); }
            set { _TelProcedencia = value.Trim(); }
        }

        private string _Ponencia1;

        public string Ponencia1
        {
            get { return _Ponencia1.Trim(); }
            set { _Ponencia1 = value.Trim(); }
        }
        private string _Ponencia2;

        public string Ponencia2
        {
            get { return _Ponencia2.Trim(); }
            set { _Ponencia2 = value.Trim(); }
        }
       
        
        private string _Operacion;

        public string Operacion
        {
            get { return _Operacion.Trim(); }
            set { _Operacion = value.Trim(); }
        }
        private string _Donativo;

        public string Donativo
        {
            get { return _Donativo.Trim(); }
            set { _Donativo = value.Trim(); }
        }
        private string _CP;

        public string CP
        {
            get { return _CP.Trim(); }
            set { _CP = value.Trim(); }
        }
        private string _Colonia;

        public string Colonia
        {
            get { return _Colonia.Trim(); }
            set { _Colonia = value.Trim(); }
        }


        //private ConceptoCuotaLibre _conceptosEvento = new ConceptoCuotaLibre();
        //public ConceptoCuotaLibre conceptosEvento
        //{

        //    get { return _conceptosEvento; }
        //    set { _conceptosEvento = value; }
        //}
    }
}
