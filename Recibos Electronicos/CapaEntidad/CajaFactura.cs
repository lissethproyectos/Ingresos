using System;
using System.Collections.Generic;
using System.Text;

namespace CapaEntidad
{
    public class CajaFactura : Factura
    {
        private string _Fecha_Fact_Cja; //Es la fecha en que se genero la factura atraves del sistema de caja
        private string _Ruta;
        private string _Ruta_Pdf;
        private string _Ruta_Xml;
        private string _Folio_Fact_Cja;
        private int _Avance;
        private int _IdCajaFact;
        private byte[] _Blob_Pdf;
        private byte[] _Blob_Xml;
        private byte[] _ArchivoBlob;
        private bool _ItsOk;
        private string _NombreArchivo;
        private string _ExtensionArchivo;
        private string _NombreArchivoPDF;
        private string _NombreArchivoXML;


        public bool ItsOk
        {
            get { return _ItsOk; }
            set { _ItsOk = value; }
        }

        public byte[] Blob_Pdf
        {
            get { return _Blob_Pdf; }
            set { _Blob_Pdf = value; }
        }

        public byte[] Blob_Xml
        {
            get { return _Blob_Xml; }
            set { _Blob_Xml = value; }
        }

        public byte[] ArchivoBlob
        {
            get { return _ArchivoBlob; }
            set { _ArchivoBlob = value; }
        }

        //public string Ruta
        //{
        //    get { return _Ruta; }
        //    set { _Ruta = value; }
        //}

        public string Ruta_Pdf
        {
            get { return _Ruta_Pdf; }
            set { _Ruta_Pdf = value; }
        }

        public string Ruta_Xml
        {
            get { return _Ruta_Xml; }
            set { _Ruta_Xml = value; }
        }

        public string Folio_Fact_Cja
        {
            get { return _Folio_Fact_Cja; }
            set { _Folio_Fact_Cja = value; }
        }

        public int IdCajaFact
        {
            get { return _IdCajaFact; }
            set { _IdCajaFact = value; }
        }

        public string Fecha_Fact_Cja
        {
            get { return _Fecha_Fact_Cja; }
            set { _Fecha_Fact_Cja = value; }
        }



        public int Avance
        {
            get { return _Avance; }
            set { _Avance = value; }
        }

        public string NombreArchivo
        {
            get { return _NombreArchivo; }
            set { _NombreArchivo = value; }
        }
        public string NombreArchivoXML
        {
            get { return _NombreArchivoXML; }
            set { _NombreArchivoXML = value; }
        }

        public string NombreArchivoPDF
        {
            get { return _NombreArchivoPDF; }
            set { _NombreArchivoPDF = value; }
        }

        public string ExtensionArchivo
        {
            get { return _ExtensionArchivo; }
            set { _ExtensionArchivo = value; }
        }


    }
}
