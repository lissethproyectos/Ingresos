using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapaEntidad
{
    public class DetConcepto:ConceptoPago
    {
        private int _IdDetConcepto;

        public int IdDetConcepto
        {
            get { return _IdDetConcepto; }
            set { _IdDetConcepto = value; }
        }

        private double _ImporteDetalle;
        public double ImporteDetalle
        {
            get { return _ImporteDetalle; }
            set { _ImporteDetalle = value; }
        }

        private double _ImporteDetalleInicio;
        public double ImporteDetalleInicio
        {
            get { return _ImporteDetalleInicio; }
            set { _ImporteDetalleInicio = value; }
        }

        private string _ClaveDetalle;
        public string ClaveDetalle
        {
            get { return _ClaveDetalle; }
            set { _ClaveDetalle = value; }
        }
        private string _DescripcionDetalle;

        public string DescripcionDetalle
        {
            get { return _DescripcionDetalle; }
            set { _DescripcionDetalle = value; }
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

        private string _TipoRegistro;

        public string TipoRegistro
        {
            get { return _TipoRegistro; }
            set { _TipoRegistro = value; }
        }
    }
}
