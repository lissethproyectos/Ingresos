using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapaEntidad
{
    public class Factura
    {
        private string _Status_Carga;
        private string _ID_FACT; //En la DB tiene ID
        private string _ID_FACT_EFEC; //En la DB tiene ID
        private String _FACT_FOLIO;
        private string _FACT_FECHA_FACTURA;
        private string _FACT_FECHA_CAPTURA;
        private string _FACT_TOTAL;
        private string _FACT_OBSERVACIONES;
        private string _FACT_DEPENDENCIA;
        private string _FACT_NOMBRE;
        private string _FACT_CLIENTE;
        private string _FACT_FOLIOBANCARIO;
        private string _FACT_BANCO;
        private string _FACT_REFERENCIA;
        private string _FACT_CARRERA;
        private string _FACT_MATRICULA;
        private string _FACT_CONFIRMADO;
        private string _CICLO_ESCOLAR;
        private string _PAGADO;
        private string _FACT_RECEPTOR_FORMA_PAGO;
        private int _ID_CODIGO_QR;
        private string _FACT_NIVEL;
        //Variable agregados por Lisseth
        private string _FACT_RECEPTOR_TIPO_PERS;
        private string _FACT_RECEPTOR_RFC;
        private string _FACT_RECEPTOR_DOMICILIO;
        private string _FACT_RECEPTOR_COLONIA;
        private string _FACT_RECEPTOR_LUGAR;
        private string _FACT_RECEPTOR_CP;
        private string _FACT_RECEPTOR_CORREO;
        private string _FACT_RECEPTOR_TELEFONO;
        private string _FACT_EXPEDIDO_DOMICILIO;
        private string _FACT_EXPEDIDO_COLONIA;
        private string _FACT_EXPEDIDO_PAIS;
        private string _FACT_FECHA_CFD;
        private string _FACT_FECHA_DISPERSION;
        private string _FACT_TOTAL_LETRAS;
        private string _FACT_CERTIFICADO;
        private string _FACT_SUBTOTAL;
        private double _FACT_IMPORTE_CONVENIO;
        private string _FACT_IMPUESTO_TASA;
        private string _FACT_SELLO_DIGITAL;
        private string _FACT_NO_CERTIFICADO;
        private string _FACT_ANIO_APROBACION;
        private string _FACT_STATUS;
        private string _FACT_STATUS_NOTAS;
        private string _FACT_RECEPTOR_MUNICIPIO;
        private string _FACT_RECEPTOR_ESTADO;
        private string _FACT_RECEPTOR_METODO_PAGO;
        private string _FACT_RECEPTOR_STATUS;
        private string _FACT_RECEPTOR_STATUS_NOTAS;
        private string _FACT_STATUS_CAJA;
        private string _RUTA_ADJUNTO;
        private string _RUTA_ADJUNTO_OFICIO;
        private string _RUTA_ADJUNTO_CONVENIO;
        private string _OFICIO;
        private string _FECHA_OFICIO;
        private string _FACT_TIPO;
        private string _FACT_NOTAS;
        private byte[] _ADJUNTO;
        private string _EXTENSION_ADJUNTO;
        private int _ID_FICHA_BANCARIA;
        private int _FACT_DIAS_EMISION;
        private string _FACT_FOLIO_FACTURA;
        private string _FACT_MODIFICABLE;
        private string _CFDI;
        private string _FACT_TIPO_SERVICIO;
        private int _FACT_DIAS_SOLICITUD;
        private string _FACT_DESC_STATUS_SOLICITUD;
        private string  _STATUS_REF_ANTICIPADA;
        private string _FACT_SEMESTRE;
        private string _FACT_CONCEPTOS;
        private string _FACT_IMPORTE;
        private string _TOOLTIP;
        //Metodos agregados por Lisseth

        public string FACT_NIVEL
        {
            get { return _FACT_NIVEL; }
            set { _FACT_NIVEL = value; }
        }
        public string FACT_DESC_STATUS_SOLICITUD
        {
            get { return _FACT_DESC_STATUS_SOLICITUD; }
            set { _FACT_DESC_STATUS_SOLICITUD = value; }
        }

        private string _COLOR;

        public string COLOR
        {
            get { return _COLOR; }
            set { _COLOR = value; }
        }

        public int FACT_DIAS_SOLICITUD
        {
            get { return _FACT_DIAS_SOLICITUD; }
            set { _FACT_DIAS_SOLICITUD = value; }
        }

        public byte[] ADJUNTO
        {
            get { return _ADJUNTO; }
            set { _ADJUNTO = value; }
        }
        public string PAGADO
        {
            get { return _PAGADO; }
            set { _PAGADO = value; }
        }

        public string CFDI
        {
            get { return _CFDI; }
            set { _CFDI = value; }
        }

        //public string FACT_METODO_PAGO
        //{
        //    get { return _FACT_METODO_PAGO; }
        //    set { _FACT_METODO_PAGO = value; }
        //}

        public string FACT_TIPO_SERVICIO
        {
            get { return _FACT_TIPO_SERVICIO; }
            set { _FACT_TIPO_SERVICIO = value; }
        }

        private bool _VISIBLE1;
        public bool VISIBLE1
        {
            get { return _VISIBLE1; }
            set { _VISIBLE1 = value; }
        }

        private bool _VISIBLE2;
        public bool VISIBLE2
        {
            get { return _VISIBLE2; }
            set { _VISIBLE2 = value; }
        }

        private bool _VISIBLE3 = false;
        public bool VISIBLE3
        {
            get { return _VISIBLE3; }
            set { _VISIBLE3 = value; }
        }

        private bool _VISIBLE4 = false;
        public bool VISIBLE4
        {
            get { return _VISIBLE4; }
            set { _VISIBLE4 = value; }
        }

        private bool _VISIBLE5 = false;
        public bool VISIBLE5
        {
            get { return _VISIBLE5; }
            set { _VISIBLE5 = value; }
        }

        private bool _HABILITADO;
        public bool HABILITADO
        {
            get { return _HABILITADO; }
            set { _HABILITADO = value; }
        }





        public string FACT_NOTAS
        {
            get { return _FACT_NOTAS; }
            set { _FACT_NOTAS = value; }
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
        public string OFICIO
        {
            get { return _OFICIO; }
            set { _OFICIO = value; }
        }

             public string FECHA_OFICIO
        {
            get { return _FECHA_OFICIO; }
            set { _FECHA_OFICIO = value; }
        }

        public string STATUS_REF_ANTICIPADA
        {
            get { return _STATUS_REF_ANTICIPADA; }
            set { _STATUS_REF_ANTICIPADA = value; }
        }
        public string EXTENSION_ADJUNTO
        {
            get { return _EXTENSION_ADJUNTO; }
            set { _EXTENSION_ADJUNTO = value; }
        }
        public string FACT_DEPENDENCIA
        {
            get { return _FACT_DEPENDENCIA; }
            set { _FACT_DEPENDENCIA = value; }
        }
        public string FACT_FOLIOBANCARIO
        {
            get { return _FACT_FOLIOBANCARIO; }
            set { _FACT_FOLIOBANCARIO = value; }
        }
        public string FACT_OBSERVACIONES
        {
            get { return _FACT_OBSERVACIONES; }
            set { _FACT_OBSERVACIONES = value; }
        }
        public string FACT_BANCO
        {
            get { return _FACT_BANCO; }
            set { _FACT_BANCO = value; }
        }
        public string CICLO_ESCOLAR
        {
            get { return _CICLO_ESCOLAR; }
            set { _CICLO_ESCOLAR = value; }
        }
        public string FACT_REFERENCIA
        {
            get { return _FACT_REFERENCIA; }
            set { _FACT_REFERENCIA = value; }
        }

        public string TOOLTIP
        {
            get { return _TOOLTIP; }
            set { _TOOLTIP = value; }
        }
        public string FACT_CARRERA
        {
            get { return _FACT_CARRERA; }
            set { _FACT_CARRERA = value; }
        }

        public string FACT_SEMESTRE
        {
            get { return _FACT_SEMESTRE; }
            set { _FACT_SEMESTRE = value; }
        }
        public string FACT_NOMBRE
        {
            get { return _FACT_NOMBRE; }
            set { _FACT_NOMBRE = value; }
        }
        public string FACT_CLIENTE
        {
            get { return _FACT_CLIENTE; }
            set { _FACT_CLIENTE = value; }
        }
        public string FACT_MATRICULA
        {
            get { return _FACT_MATRICULA; }
            set { _FACT_MATRICULA = value; }
        }
        public string ID_FACT
        {
            get { return _ID_FACT; }
            set { _ID_FACT = value; }
        }
        public string ID_FACT_EFEC
        {
            get { return _ID_FACT_EFEC; }
            set { _ID_FACT_EFEC = value; }
        }
        public String FACT_FOLIO
        {
            get { return _FACT_FOLIO.Trim(); }
            set { _FACT_FOLIO = value.Trim(); }
        }
        public string FACT_FECHA_FACTURA
        {
            get { return _FACT_FECHA_FACTURA; }
            set { _FACT_FECHA_FACTURA = value; }
        }
        public string FACT_FOLIO_FACTURA
        {
            get { return _FACT_FOLIO_FACTURA; }
            set { _FACT_FOLIO_FACTURA = value; }
        }
        public string FACT_FECHA_CAPTURA
        {
            get { return _FACT_FECHA_CAPTURA; }
            set { _FACT_FECHA_CAPTURA = value; }
        }
        public int FACT_DIAS_EMISION
        {
            get { return _FACT_DIAS_EMISION; }
            set { _FACT_DIAS_EMISION = value; }
        }
        public string FACT_TOTAL
        {
            get { return _FACT_TOTAL; }
            set { _FACT_TOTAL = value; }
        }
        public string Status_Carga

        {
            get { return _Status_Carga; }
            set { _Status_Carga = value; }
        }
        public string FACT_TIPO
        {
            get { return _FACT_TIPO; }
            set { _FACT_TIPO = value; }
        }
        public string FACT_RECEPTOR_TIPO_PERS
        {
            get { return _FACT_RECEPTOR_TIPO_PERS; }
            set { _FACT_RECEPTOR_TIPO_PERS = value; }
        }
        public string FACT_RECEPTOR_RFC
        {
            get { return _FACT_RECEPTOR_RFC; }
            set { _FACT_RECEPTOR_RFC = value; }
        }
        public string FACT_RECEPTOR_DOMICILIO
        {
            get { return _FACT_RECEPTOR_DOMICILIO; }
            set { _FACT_RECEPTOR_DOMICILIO = value; }
        }
        public string FACT_RECEPTOR_COLONIA
        {
            get { return _FACT_RECEPTOR_COLONIA; }
            set { _FACT_RECEPTOR_COLONIA = value; }
        }
        public string FACT_RECEPTOR_LUGAR
        {
            get { return _FACT_RECEPTOR_LUGAR; }
            set { _FACT_RECEPTOR_LUGAR = value; }
        }
        public string FACT_RECEPTOR_MUNICIPIO
        {
            get { return _FACT_RECEPTOR_MUNICIPIO; }
            set { _FACT_RECEPTOR_MUNICIPIO = value; }
        }
        public string FACT_RECEPTOR_CP
        {
            get { return _FACT_RECEPTOR_CP; }
            set { _FACT_RECEPTOR_CP = value; }
        }
        public string FACT_RECEPTOR_ESTADO
        {
            get { return _FACT_RECEPTOR_ESTADO; }
            set { _FACT_RECEPTOR_ESTADO = value; }
        }
        public string FACT_RECEPTOR_METODO_PAGO
        {
            get { return _FACT_RECEPTOR_METODO_PAGO; }
            set { _FACT_RECEPTOR_METODO_PAGO = value; }
        }

        public string FACT_RECEPTOR_FORMA_PAGO
        {
            get { return _FACT_RECEPTOR_FORMA_PAGO; }
            set { _FACT_RECEPTOR_FORMA_PAGO = value; }
        }


        public string FACT_CONCEPTOS
        {
            get { return _FACT_CONCEPTOS; }
            set { _FACT_CONCEPTOS = value; }
        }
        public string FACT_RECEPTOR_TELEFONO
        {
            get { return _FACT_RECEPTOR_TELEFONO; }
            set { _FACT_RECEPTOR_TELEFONO = value; }
        }
        public string FACT_RECEPTOR_CORREO
        {
            get { return _FACT_RECEPTOR_CORREO; }
            set { _FACT_RECEPTOR_CORREO = value; }
        }
        public string FACT_RECEPTOR_STATUS
        {
            get { return _FACT_RECEPTOR_STATUS; }
            set { _FACT_RECEPTOR_STATUS = value; }
        }
        public string FACT_RECEPTOR_STATUS_NOTAS
        {
            get { return _FACT_RECEPTOR_STATUS_NOTAS; }
            set { _FACT_RECEPTOR_STATUS_NOTAS = value; }
        }
        public string FACT_STATUS_CAJA
        {
            get { return _FACT_STATUS_CAJA; }
            set { _FACT_STATUS_CAJA = value; }
        }
        public string FACT_EXPEDIDO_DOMICILIO
        {
            get { return _FACT_EXPEDIDO_DOMICILIO; }
            set { _FACT_EXPEDIDO_DOMICILIO = value; }
        }
        public string FACT_EXPEDIDO_COLONIA
        {
            get { return _FACT_EXPEDIDO_COLONIA; }
            set { _FACT_EXPEDIDO_COLONIA = value; }
        }
        public string FACT_EXPEDIDO_PAIS
        {
            get { return _FACT_EXPEDIDO_PAIS; }
            set { _FACT_EXPEDIDO_PAIS = value; }
        }
        public string FACT_FECHA_CFD
        {
            get { return _FACT_FECHA_CFD; }
            set { _FACT_FECHA_CFD = value; }
        }
        public string FACT_FECHA_DISPERSION
        {
            get { return _FACT_FECHA_DISPERSION; }
            set { _FACT_FECHA_DISPERSION = value; }
        }
        public string FACT_MODIFICABLE
        {
            get { return _FACT_MODIFICABLE; }
            set { _FACT_MODIFICABLE = value; }
        }
        public string FACT_TOTAL_LETRAS
        {
            get { return _FACT_TOTAL_LETRAS; }
            set { _FACT_TOTAL_LETRAS = value; }
        }
        public string FACT_CERTIFICADO
        {
            get { return _FACT_CERTIFICADO; }
            set { _FACT_CERTIFICADO = value; }
        }
        public string FACT_SUBTOTAL
        {
            get { return _FACT_SUBTOTAL; }
            set { _FACT_SUBTOTAL = value; }
        }
        public double FACT_IMPORTE_CONVENIO
        {
            get { return _FACT_IMPORTE_CONVENIO; }
            set { _FACT_IMPORTE_CONVENIO = value; }
        }
        public string FACT_IMPUESTO_TASA
        {
            get { return _FACT_IMPUESTO_TASA; }
            set { _FACT_IMPUESTO_TASA = value; }
        }

        public string FACT_IMPORTE
        {
            get { return _FACT_IMPORTE; }
            set { _FACT_IMPORTE = value; }
        }
        public string FACT_SELLO_DIGITAL
        {
            get { return _FACT_SELLO_DIGITAL; }
            set { _FACT_SELLO_DIGITAL = value; }
        }
        public string FACT_NO_CERTIFICADO
        {
            get { return _FACT_NO_CERTIFICADO; }
            set { _FACT_NO_CERTIFICADO = value; }
        }
        public string FACT_ANIO_APROBACION
        {
            get { return _FACT_ANIO_APROBACION; }
            set { _FACT_ANIO_APROBACION = value; }
        }
        public string FACT_STATUS
        {
            get { return _FACT_STATUS; }
            set { _FACT_STATUS = value; }
        }
        public string FACT_STATUS_NOTAS
        {
            get { return _FACT_STATUS_NOTAS; }
            set { _FACT_STATUS_NOTAS = value; }
        }
        public string FACT_CONFIRMADO
        {
            get { return _FACT_CONFIRMADO; }
            set { _FACT_CONFIRMADO = value; }
        }
        public int ID_FICHA_BANCARIA
        {
            get { return _ID_FICHA_BANCARIA; }
            set { _ID_FICHA_BANCARIA = value; }
        }
        public int ID_CODIGO_QR
        {
            get { return _ID_CODIGO_QR; }
            set { _ID_CODIGO_QR = value; }
        }



        /*CAMPOS MULTIPAGOS*/
        private MultiPago _multipago = new MultiPago();
        public MultiPago multipago
        {

            get { return _multipago; }
            set { _multipago = value; }
        }
    }
}
