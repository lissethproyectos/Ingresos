using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapaEntidad
{
    public class Facturacion
    {


        private int _ID_FACT; //En la DB tiene ID
        private string _DEPENDENCIA;
        private string _TIPO;
        private string _RECEPTOR_RFC;
        private string _RECEPTOR_NOMBRE;
        private string _RECEPTOR_CODIGO;
        private string _RECEPTOR_DOMICILIO;
        private string _RECEPTOR_COLONIA;
        private string _RECEPTOR_CP;
        private string _RECEPTOR_ESTADO;
        private string _RECEPTOR_MUNICIPIO;
        private string _RECEPTOR_METODO_PAGO;
        private string _RECEPTOR_METODO_PAGO_FA;
        private string _RECEPTOR_TELEFONO;
        private string _RECEPTOR_CORREO;
        private int _ID_FICHA_BANCARIA;
        private string _RECEPTOR_TIPO_PERS;
        private string _RECEPTOR_STATUS;
        private string _DESC_RECEPTOR_STATUS;
        private string _RECEPTOR_FECHA_STATUS;
        private int _DIAS_SOLICITUD = 0;
        private string _USUARIO;
        private string _COLOR;
        private string _FOLIO_PAGO;
        private string _FECHA_PAGO;
        private double _IMPORTE_PAGO = 0;
        private double _IVA_PAGO = 0;
        private double _TOTAL_PAGO = 0;
        private string _NUM_OFICIO;
        private string _FECHA_OFICIO;
        private double _IMPORTE_CONVENIO = 0;
        private double _IVA_CONVENIO = 0;
        private double _TOTAL_CONVENIO;
        private string _OBSERVACIONES_CONVENIO;
        private string _RUTA_ADJUNTO;
        private string _RUTA_ADJUNTO_OFICIO;
        private string _RUTA_ADJUNTO_CONVENIO;
        private string _RUTA_ADJUNTO_REP;
        private string _RUTA_ADJUNTO_CONSTANCIA;

        private string _CFDI;
        private string _RECEPTOR_TIPO_SERVICIO;
        private string _CONFIRMADO;
        private string _RECEPTOR_FORMA_PAGO;
        private string _TIPO_SERVICIO;
        private string _OBSERVACIONES;
        private string _RECEPTOR_STATUS_NOTAS;
        private string _CONCEPTOS;
        private string _NUMERO_INTERIOR;
        private string _NUMERO_EXTERIOR;
        private string _RECHAZADO;
        private bool _VISIBLE1;
        private bool _VISIBLE2;
        private string _FECHA_REP;
        private string _FOLIO_REP;
        private string _FOLIO_PAGADO;

        public string FOLIO_PAGADO
        {
            get { return _FOLIO_PAGADO; }
            set { _FOLIO_PAGADO = value; }
        }
        public string FOLIO_REP
        {
            get { return _FOLIO_REP; }
            set { _FOLIO_REP = value; }
        }

        public string FECHA_REP
        {
            get { return _FECHA_REP; }
            set { _FECHA_REP = value; }
        }
        public bool VISIBLE1
        {
            get { return _VISIBLE1; }
            set { _VISIBLE1 = value; }
        }

        public bool VISIBLE2
        {
            get { return _VISIBLE2; }
            set { _VISIBLE2 = value; }
        }

        public string RECHAZADO
        {
            get { return _RECHAZADO; }
            set { _RECHAZADO = value; }
        }
        public int DIAS_SOLICITUD
        {
            get { return _DIAS_SOLICITUD; }
            set { _DIAS_SOLICITUD = value; }

        }
        public string NUMERO_EXTERIOR
        {
            get { return _NUMERO_EXTERIOR; }
            set { _NUMERO_EXTERIOR = value; }
        }
        public string NUMERO_INTERIOR
        {
            get { return _NUMERO_INTERIOR; }
            set { _NUMERO_INTERIOR = value; }
        }
        public string CONCEPTOS
        {
            get { return _CONCEPTOS; }
            set { _CONCEPTOS = value; }
        }
        public string RECEPTOR_STATUS_NOTAS
        {
            get { return _RECEPTOR_STATUS_NOTAS; }
            set { _RECEPTOR_STATUS_NOTAS = value; }
        }

        public string RECEPTOR_FORMA_PAGO
        {
            get { return _RECEPTOR_FORMA_PAGO; }
            set { _RECEPTOR_FORMA_PAGO = value; }
        }

        public string RECEPTOR_CODIGO
        {
            get { return _RECEPTOR_CODIGO; }
            set { _RECEPTOR_CODIGO = value; }
        }

        public string CONFIRMADO
        {
            get { return _CONFIRMADO; }
            set { _CONFIRMADO = value; }
        }
        public string OBSERVACIONES
        {
            get { return _OBSERVACIONES; }
            set { _OBSERVACIONES = value; }
        }
        public string TIPO_SERVICIO
        {
            get { return _TIPO_SERVICIO; }
            set { _TIPO_SERVICIO = value; }
        }
        //public string NOTAS_CONVENIO
        //{
        //    get { return _NOTAS_CONVENIO; }
        //    set { _NOTAS_CONVENIO = value; }
        //}
        public string FECHA_OFICIO
        {
            get { return _FECHA_OFICIO; }
            set { _FECHA_OFICIO = value; }
        }

        public string DEPENDENCIA
        {
            get { return _DEPENDENCIA; }
            set { _DEPENDENCIA = value; }
        }
        public string COLOR
        {
            get { return _COLOR; }
            set { _COLOR = value; }
        }

        public int ID_FICHA_BANCARIA
        {
            get { return _ID_FICHA_BANCARIA; }
            set { _ID_FICHA_BANCARIA = value; }
        }
        public string RECEPTOR_CORREO
        {
            get { return _RECEPTOR_CORREO; }
            set { _RECEPTOR_CORREO = value; }
        }
        public int ID_FACT
        {
            get { return _ID_FACT; }
            set { _ID_FACT = value; }
        }
        public string TIPO
        {
            get { return _TIPO; }
            set { _TIPO = value; }
        }
        public string RECEPTOR_RFC
        {
            get { return _RECEPTOR_RFC; }
            set { _RECEPTOR_RFC = value; }
        }
        public string RECEPTOR_NOMBRE
        {
            get { return _RECEPTOR_NOMBRE; }
            set { _RECEPTOR_NOMBRE = value; }
        }
        public string RECEPTOR_DOMICILIO
        {
            get { return _RECEPTOR_DOMICILIO; }
            set { _RECEPTOR_DOMICILIO = value; }
        }
        public string RECEPTOR_COLONIA
        {
            get { return _RECEPTOR_COLONIA; }
            set { _RECEPTOR_COLONIA = value; }
        }
        public string RECEPTOR_CP
        {
            get { return _RECEPTOR_CP; }
            set { _RECEPTOR_CP = value; }
        }
        public string RECEPTOR_ESTADO
        {
            get { return _RECEPTOR_ESTADO; }
            set { _RECEPTOR_ESTADO = value; }
        }
        public string RECEPTOR_MUNICIPIO
        {
            get { return _RECEPTOR_MUNICIPIO; }
            set { _RECEPTOR_MUNICIPIO = value; }
        }
        public string RECEPTOR_METODO_PAGO
        {
            get { return _RECEPTOR_METODO_PAGO; }
            set { _RECEPTOR_METODO_PAGO = value; }
        }
        public string RECEPTOR_METODO_PAGO_FA
        {
            get { return _RECEPTOR_METODO_PAGO_FA; }
            set { _RECEPTOR_METODO_PAGO_FA = value; }
        }

        public string RECEPTOR_TELEFONO
        {
            get { return _RECEPTOR_TELEFONO; }
            set { _RECEPTOR_TELEFONO = value; }
        }
        public string RECEPTOR_TIPO_PERS
        {
            get { return _RECEPTOR_TIPO_PERS; }
            set { _RECEPTOR_TIPO_PERS = value; }
        }
        public string RECEPTOR_STATUS
        {
            get { return _RECEPTOR_STATUS; }
            set { _RECEPTOR_STATUS = value; }
        }

        public string DESC_RECEPTOR_STATUS
        {
            get { return _DESC_RECEPTOR_STATUS; }
            set { _DESC_RECEPTOR_STATUS = value; }
        }

        public string RECEPTOR_FECHA_STATUS
        {
            get { return _RECEPTOR_FECHA_STATUS; }
            set { _RECEPTOR_FECHA_STATUS = value; }
        }
        public string USUARIO
        {
            get { return _USUARIO; }
            set { _USUARIO = value; }
        }
        public string FOLIO_PAGO
        {
            get { return _FOLIO_PAGO; }
            set { _FOLIO_PAGO = value; }
        }
        public string FECHA_PAGO
        {
            get { return _FECHA_PAGO; }
            set { _FECHA_PAGO = value; }
        }
        public double IMPORTE_PAGO
        {
            get { return _IMPORTE_PAGO; }
            set { _IMPORTE_PAGO = value; }
        }
        public double IVA_PAGO
        {
            get { return _IVA_PAGO; }
            set { _IVA_PAGO = value; }
        }
        public double TOTAL_PAGO
        {
            get { return _TOTAL_PAGO; }
            set { _TOTAL_PAGO = value; }
        }
        public string NUM_OFICIO
        {
            get { return _NUM_OFICIO; }
            set { _NUM_OFICIO = value; }
        }

        public double IMPORTE_CONVENIO
        {
            get { return _IMPORTE_CONVENIO; }
            set { _IMPORTE_CONVENIO = value; }
        }

        public double IVA_CONVENIO
        {
            get { return _IVA_CONVENIO; }
            set { _IVA_CONVENIO = value; }
        }
        public double TOTAL_CONVENIO
        {
            get { return _TOTAL_CONVENIO; }
            set { _TOTAL_CONVENIO = value; }
        }
        public string OBSERVACIONES_CONVENIO
        {
            get { return _OBSERVACIONES_CONVENIO; }
            set { _OBSERVACIONES_CONVENIO = value; }
        }
        public string RUTA_ADJUNTO
        {
            get { return _RUTA_ADJUNTO; }
            set { _RUTA_ADJUNTO = value; }
        }
        public string RUTA_ADJUNTO_OFICIO
        {
            get { return _RUTA_ADJUNTO_OFICIO; }
            set { _RUTA_ADJUNTO_OFICIO = value; }
        }
        public string RUTA_ADJUNTO_CONVENIO
        {
            get { return _RUTA_ADJUNTO_CONVENIO; }
            set { _RUTA_ADJUNTO_CONVENIO = value; }
        }
        public string RUTA_ADJUNTO_REP
        {
            get { return _RUTA_ADJUNTO_REP; }
            set { _RUTA_ADJUNTO_REP = value; }
        }

        public string RUTA_ADJUNTO_CONSTANCIA
        {
            get { return _RUTA_ADJUNTO_CONSTANCIA; }
            set { _RUTA_ADJUNTO_CONSTANCIA = value; }
        }
        public string CFDI
        {
            get { return _CFDI; }
            set { _CFDI = value; }
        }
        public string RECEPTOR_TIPO_SERVICIO
        {
            get { return _RECEPTOR_TIPO_SERVICIO; }
            set { _RECEPTOR_TIPO_SERVICIO = value; }
        }

    }
}