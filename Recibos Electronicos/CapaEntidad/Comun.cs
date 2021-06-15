using System;
using System.Collections.Generic;
using System.Text;

namespace CapaEntidad
{
    public class Comun
    {
        private int _Id;
        private string _IdStr;
        private string _Descripcion;
        private string _Clasificacion;
        private string _EtiquetaDos;
        private string _EtiquetaTres;
        private string _EtiquetaCuatro;
        private string _EtiquetaCinco;
        private string _EtiquetaSeis;
        private string _EtiquetaSiete;
        private string _Contador_Visitas;
        private string _Etiqueta;
        private bool _Habil;
        private bool _Inhabil;

        public bool Habil
        {
            get { return _Habil; }
            set { _Habil = value; }
        }    
        public bool Inhabil
        {
            get { return _Inhabil; }
            set { _Inhabil = value; }
        }
            public string Etiqueta
            {
                get { return _Etiqueta; }
                set { _Etiqueta = value; }
            }
        public string EtiquetaTres
        {
            get { return _EtiquetaTres; }
            set { _EtiquetaTres = value; }
        }
        public string EtiquetaDos
        {
            get { return _EtiquetaDos; }
            set { _EtiquetaDos = value; }
        }
        public string EtiquetaCuatro
        {
            get { return _EtiquetaCuatro; }
            set { _EtiquetaCuatro = value; }
        }
        public string EtiquetaCinco
        {
            get { return _EtiquetaCinco; }
            set { _EtiquetaCinco = value; }
        }
        public string EtiquetaSeis
        {
            get { return _EtiquetaSeis; }
            set { _EtiquetaSeis = value; }
        }
        public string EtiquetaSiete
        {
            get { return _EtiquetaSiete; }
            set { _EtiquetaSiete = value; }
        }
        public string Clasificacion
        {
            get { return _Clasificacion; }
            set { _Clasificacion = value; }
        }
        public string Descripcion
        {
            get { return _Descripcion; }
            set { _Descripcion = value; }
        }
        public string IdStr
        {
            get { return _IdStr; }
            set { _IdStr = value; }
        }
        public int Id
        {
            get { return _Id; }
            set { _Id = value; }
        }
        public string Contador_Visitas
        {
            get { return _Contador_Visitas; }
            set { _Contador_Visitas = value; }
        }

    }
}
