using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapaEntidad
{
    public class Oficio
    {
        private string _NumOficio;
        public string NumOficio
        {
            get { return _NumOficio; }
            set { _NumOficio = value; }
        }

        private int _IdOficio;
        public int IdOficio
        {
            get { return _IdOficio; }
            set { _IdOficio = value; }
        }

        private int _IdDescuento;
        public int IdDescuento
        {
            get { return _IdDescuento; }
            set { _IdDescuento = value; }
        }

        private byte[] _Archivo;
        public byte[] Archivo
        {
            get { return _Archivo; }
            set { _Archivo = value; }
        }

        private string _TipoArchivo;
        public string TipoArchivo
        {
            get { return _TipoArchivo; }
            set { _TipoArchivo = value; }
        }

        private string _NombreArchivo;
        public string NombreArchivo
        {
            get { return _NombreArchivo; }
            set { _NombreArchivo = value; }
        }

        private string _LinkArchivo;
        public string LinkArchivo
        {
            get { return _LinkArchivo; }
            set { _LinkArchivo = value; }
        }

        private string _RutaArchivo;
        public string RutaArchivo
        {
            get { return _RutaArchivo; }
            set { _RutaArchivo = value; }
        }


        private string _FechaOficio;
        public string FechaOficio
        {
            get { return _FechaOficio; }
            set { _FechaOficio = value; }
        }

        private string _FirmaOficio;
        public string FirmaOficio
        {
            get { return _FirmaOficio; }
            set { _FirmaOficio = value; }
        }

        private string _Observaciones;
        public string Observaciones
        {
            get { return _Observaciones; }
            set { _Observaciones = value; }
        }

    }
}
