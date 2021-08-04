using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapaEntidad
{
    public class ConceptoCuotaLibre
    {
        private string _Id;
        public string Id
        {
            get { return _Id; }
            set { _Id = value; }
        }

        private int _IdEvento;
        public int IdEvento
        {
            get { return _IdEvento; }
            set { _IdEvento = value; }
        }

        private int _Id_Concepto;
        public int Id_Concepto
        {
            get { return _Id_Concepto; }
            set { _Id_Concepto = value; }
        }

        private string _Concepto;
        public string Concepto
        {
            get { return _Concepto; }
            set { _Concepto = value; }
        }

        private string _Editar;
        public string Editar
        {
            get { return _Editar; }
            set { _Editar = value; }
        }

        private string _Eliminar;
        public string Eliminar
        {
            get { return _Eliminar; }
            set { _Eliminar = value; }
        }

        private string _Nuevo;
        public string Nuevo
        {
            get { return _Nuevo; }
            set { _Nuevo = value; }
        }


        private int _Dependencia;
        public int Dependencia
        {
            get { return _Dependencia; }
            set { _Dependencia = value; }
        }

        private int _Carrera;
        public int Carrera
        {
            get { return _Carrera; }
            set { _Carrera = value; }
        }

        private double _Importe;
        public double Importe
        {
            get { return _Importe; }
            set { _Importe = value; }
        }

        private char _Status;
        public char Status
        {
            get { return _Status; }
            set { _Status = value; }
        }

        private string _StatusDet;
        public string StatusDet
        {
            get { return _StatusDet; }
            set { _StatusDet = value; }
        }

        private string _Observaciones;
        public string Observaciones
        {
            get { return _Observaciones.ToUpper(); }
            set { _Observaciones = value; }
        }

        private string _Evento;
        public string Evento
        {
            get { return _Evento.ToUpper(); }
            set { _Evento = value; }
        }

        private int _Extemporaneo_Dia;
        public int Extemporaneo_Dia
        {
            get { return _Extemporaneo_Dia; }
            set { _Extemporaneo_Dia = value; }
        }

        private string _DescConcepto;
        public string DescConcepto
        {
            get { return _DescConcepto; }
            set { _DescConcepto = value; }
        }

        private string _DescCarrera;
        public string DescCarrera
        {
            get { return _DescCarrera; }
            set { _DescCarrera = value; }
        }

        private string _Tipo;
        public string Tipo
        {
            get { return _Tipo; }
            set { _Tipo = value; }
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

        private int _Id_Tipo_Participante;
        public int Id_Tipo_Participante
        {
            get { return _Id_Tipo_Participante; }
            set { _Id_Tipo_Participante = value; }
        }

        private string _Participante;
        public string Participante
        {
            get { return _Participante; }
            set { _Participante = value; }
        }

        private string _Es_Ponente;
        public string Es_Ponente
        {
            get { return _Es_Ponente; }
            set { _Es_Ponente = value; }
        }

        //private string _Periodo_Pago;
        //public string Periodo_Pago
        //{
        //    get { return _Periodo_Pago; }
        //    set { _Periodo_Pago = value; }
        //}

        private string _Visible_Institucion;
        public string Visible_Institucion
        {
            get { return _Visible_Institucion; }
            set { _Visible_Institucion = value; }
        }

        private string _Visible_Puesto;
        public string Visible_Puesto
        {
            get { return _Visible_Puesto; }
            set { _Visible_Puesto = value; }
        }

        private string _Visible_Grado;
        public string Visible_Grado
        {
            get { return _Visible_Grado; }
            set { _Visible_Grado = value; }
        }

        private string _Requiere_Constancia;
        public string Requiere_Constancia
        {
            get { return _Requiere_Constancia; }
            set { _Requiere_Constancia = value; }
        }


        private string _Grupo_Numero;
        public string Grupo_Numero
        {
            get { return _Grupo_Numero; }
            set { _Grupo_Numero = value; }
        }
        

        ///Campos que son visibles o no en el sistema de ficha referenciada
        private string _Visible_Periodo_Pago;
        public string Visible_Periodo_Pago
        {
            get { return _Visible_Periodo_Pago; }
            set { _Visible_Periodo_Pago = value; }
        }
    }
}
