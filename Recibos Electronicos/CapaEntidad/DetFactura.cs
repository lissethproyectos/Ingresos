using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapaEntidad
{
    public class DetFactura: Factura
    {
        private int _IdDetFact;
        private string _ClaveConcepto;
        private string _DescConcepto;
        private int _Cantidad;
        private string _ValorUnitario;
        private string _Importe;


        public int IdDetFact
        {
            get { return _IdDetFact; }
            set { _IdDetFact = value; }
        }
        public string ClaveConcepto
        {
            get { return _ClaveConcepto; }
            set { _ClaveConcepto = value; }
        }
        public string DescConcepto
        {
            get { return _DescConcepto; }
            set { _DescConcepto = value; }
        }
        public int Cantidad
        {
            get { return _Cantidad; }
            set { _Cantidad = value; }
        }
        public string ValorUnitario
        {
            get { return _ValorUnitario; }
            set { _ValorUnitario = value; }
        }
        public string Importe
        {
            get { return _Importe; }
            set { _Importe = value; }
        }
    }
}
