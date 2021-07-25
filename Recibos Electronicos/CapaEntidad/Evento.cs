using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapaEntidad
{
    public class Evento
    {
        private int _TotPagados;
        public int TotPagados
        {
            get { return _TotPagados; }
            set { _TotPagados = value; }
        }
        private string _Status;
        public string Status
        {
            get { return _Status; }
            set { _Status = value; }
        }

        private string _Oficio_s;
        public string Oficio_s
        {
            get { return _Oficio_s; }
            set { _Oficio_s = value; }
        }

        private string _Dependencia;
        public string Dependencia
        {
            get { return _Dependencia; }
            set { _Dependencia = value; }
        }

        private string _Fecha_inicial;
        public string Fecha_inicial
        {
            get { return _Fecha_inicial; }
            set { _Fecha_inicial = value; }
        }

        private string _Fecha_final;
        public string Fecha_final
        {
            get { return _Fecha_final; }
            set { _Fecha_final = value; }
        }

        private string _Eventos;
        public string Eventos
        {
            get { return _Eventos; }
            set { _Eventos = value; }
        }

        private string _Descripcion;
        public string Descripcion
        {
            get { return _Descripcion; }
            set { _Descripcion = value; }
        }

        private string _Nivel;
        public string Nivel
        {
            get { return _Nivel; }
            set { _Nivel = value; }
        }

        private string _Email_Res;
        public string Email_Res
        {
            get { return _Email_Res; }
            set { _Email_Res = value; }
        }

        private string _Email_Corres;
        public string Email_Corres
        {
            get { return _Email_Corres; }
            set { _Email_Corres = value; }
        }

        private string _Concepto;
        public string Concepto
        {
            get { return _Concepto; }
            set { _Concepto = value; }
        }

        private string _Ini_Matricula;
        public string Ini_Matricula
        {
            get { return _Ini_Matricula; }
            set { _Ini_Matricula = value; }
        }

        private string _Autorizacion;
        public string Autorizacion
        {
            get { return _Autorizacion; }
            set { _Autorizacion = value; }
        }

        private bool _VisibleAutorizacion;
        public bool VisibleAutorizacion
        {
            get { return _VisibleAutorizacion; }
            set { _VisibleAutorizacion = value; }
        }

        private string _Logo;
        public string Logo
        {
            get { return _Logo; }
            set { _Logo = value; }
        }

        private string _Tipo_Periodo;
        public string Tipo_Periodo
        {
            get { return _Tipo_Periodo; }
            set { _Tipo_Periodo = value; }
        }

        private string _Oficio;
        public string Oficio
        {
            get { return _Oficio; }
            set { _Oficio = value; }
        }

        private string _FechaOficio;
        public string FechaOficio
        {
            get { return _FechaOficio; }
            set { _FechaOficio = value; }
        }

        private string _NoOficio;
        public string NoOficio
        {
            get { return _NoOficio; }
            set { _NoOficio = value; }
        }


        private string _Observaciones;
        public string Observaciones
        {
            get { return _Observaciones; }
            set { _Observaciones = value; }
        }

        private string _Firma;
        public string Firma
        {
            get { return _Firma; }
            set { _Firma = value; }
        }


        private string _Ruta;
        public string Ruta
        {
            get { return _Ruta; }
            set { _Ruta = value; }
        }

        private string _Tipo;
        public string Tipo
        {
            get { return _Tipo; }
            set { _Tipo = value; }
        }


        private int _Anio;
        public int Anio
        {
            get { return _Anio; }
            set { _Anio = value; }
        }

        private string _Usuario_Solicita;
        public string Usuario_Solicita
        {
            get { return _Usuario_Solicita; }
            set { _Usuario_Solicita = value; }
        }

        private string _Usuario_Autoriza;
        public string Usuario_Autoriza
        {
            get { return _Usuario_Autoriza; }
            set { _Usuario_Autoriza = value; }
        }

        private string _Fecha_Solicitud;
        public string Fecha_Solicitud
        {
            get { return _Fecha_Solicitud; }
            set { _Fecha_Solicitud = value; }
        }

        private string _Fecha_Autorizacion;
        public string Fecha_Autorizacion
        {
            get { return _Fecha_Autorizacion; }
            set { _Fecha_Autorizacion = value; }
        }

        private string _Tipo_Participante;
        public string Tipo_Participante
        {
            get { return _Tipo_Participante; }
            set { _Tipo_Participante = value; }
        }

        private string _Desc_Tipo_Participante;
        public string Desc_Tipo_Participante
        {
            get { return _Desc_Tipo_Participante; }
            set { _Desc_Tipo_Participante = value; }
        }

        private string _Es_Ponente;
        public string Es_Ponente
        {
            get { return _Es_Ponente; }
            set { _Es_Ponente = value; }
        }

        private string _Nueva_Version;
        public string Nueva_Version
        {
            get { return _Nueva_Version; }
            set { _Nueva_Version = value; }
        }

        private bool _EsVisible;
        public bool EsVisible
        {
            get { return _EsVisible; }
            set { _EsVisible = value; }
        }

        private bool _EsVisible2;
        public bool EsVisible2
        {
            get { return _EsVisible2; }
            set { _EsVisible2 = value; }
        }

        private Int32 _Id;
        public Int32 Id
        {
            get { return _Id; }
            set { _Id = value; }
        }

        /*Tabla Ing_Conceptos_Cuota_Libre 
         private int _Concepto_Id;
         public int Concepto_Id
         {
             get { return _Concepto_Id; }
             set { _Concepto_Id = value; }
         }

         private int _Concepto_Dependencia;
         public int Concepto_Dependencia
         {
             get { return _Concepto_Dependencia; }
             set { _Concepto_Dependencia = value; }
         }

         private int _Concepto_Carrera;
         public int Concepto_Carrera
         {
             get { return _Concepto_Carrera; }
             set { _Concepto_Carrera = value; }
         }

         private double _Concepto_Importe;
         public double Concepto_Importe
         {
             get { return _Concepto_Importe; }
             set { _Concepto_Importe = value; }
         }

         private char _Concepto_Status;
         public char Concepto_Status
         {
             get { return _Concepto_Status; }
             set { _Concepto_Status = value; }
         }

         private string _Concepto_Observaciones;
         public string Concepto_Observaciones
         {
             get { return _Concepto_Observaciones.ToUpper(); }
             set { _Concepto_Observaciones = value; }
         }

         private string _Concepto_Evento;
         public string Concepto_Evento
         {
             get { return _Concepto_Evento.ToUpper(); }
             set { _Concepto_Evento = value; }
         }

         private int _Extemporaneo;
         public int Extemporaneo
         {
             get { return _Extemporaneo; }
             set { _Extemporaneo = value; }
         }*/

    }
}
