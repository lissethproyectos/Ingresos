using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapaEntidad
{
    public class Retencion
    {
        private string _Dependencia;
        public string Dependencia
        {
            get { return _Dependencia; }
            set { _Dependencia = value; }
        }

        private string _Cuenta;
        public string Cuenta
        {
            get { return _Cuenta; }
            set { _Cuenta = value; }
        }

        private string _Concepto;
        public string Concepto
        {
            get { return _Concepto; }
            set { _Concepto = value; }
        }

        private string _Tipo_Beneficiario;
        public string Tipo_Beneficiario
        {
            get { return _Tipo_Beneficiario; }
            set { _Tipo_Beneficiario = value; }
        }

        private string _Beneficiario;
        public string Beneficiario
        {
            get { return _Beneficiario; }
            set { _Beneficiario = value; }
        }

        private string _Poliza;
        public string Poliza
        {
            get { return _Poliza; }
            set { _Poliza = value; }
        }

        private string _Cedula;
        public string Cedula
        {
            get { return _Cedula; }
            set { _Cedula = value; }
        }

        private string _Cargo;
        public string Cargo
        {
            get { return _Cargo; }
            set { _Cargo = value; }
        }

        private string _Abono;
        public string Abono
        {
            get { return _Abono; }
            set { _Abono = value; }
        }

        private double _Impuesto;
        public double Impuesto
        {
            get { return _Impuesto; }
            set { _Impuesto = value; }
        }

        private string _MesAnio;
        public string MesAnio
        {
            get { return _MesAnio; }
            set { _MesAnio = value; }
        }


        private int _Anio;
        public int Anio
        {
            get { return _Anio; }
            set { _Anio = value; }
        }

        private string _Mes;
        public string Mes
        {
            get { return _Mes; }
            set { _Mes = value; }
        }
    }
}
