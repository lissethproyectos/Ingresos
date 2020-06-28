using System;
using System.Collections.Generic;
using System.Text;

namespace CapaEntidad
{
    public class Curso
    {
        private int _IdCurso;
        private string _Dependencia;
        private string _CicloEscolar;
        private string _Nivel;
        private string _Status;
        private string _Evento;
        private int _IdMateria;
        private string _DescMateria;
        private int _IdConcepto;
        private string _DescConcepto;
        private double _Importe;
        private double _Importe_Extemporaneo;
        private string _Fecha_Limite;
        private string _DescCarrera;
        private string _IdCarrera;
        private int _Semestre;
        private string _Grupo;
        private string _Plan;
        private int _IdMateriaOpt;
        private string _Oficio;


        public string Oficio
        {
            get { return _Oficio; }
            set { _Oficio = value; }
        }

        public string Plan
        {
            get { return _Plan; }
            set { _Plan = value; }
        }

        public int IdMateriaOpt
        {
            get { return _IdMateriaOpt; }
            set { _IdMateriaOpt = value; }
        }

        public int IdCurso
        {
            get { return _IdCurso; }
            set { _IdCurso = value; }
        }
        public string Status
        {
            get { return _Status; }
            set { _Status = value; }
        }
        public string Nivel
        {
            get { return _Nivel; }
            set { _Nivel = value; }
        }
        public string CicloEscolar
        {
            get { return _CicloEscolar; }
            set { _CicloEscolar = value; }
        }
        public string Dependencia
        {
            get { return _Dependencia.Trim(); }
            set { _Dependencia = value.Trim(); }
        }
        public string Evento
        {
            get { return _Evento.Trim(); }
            set { _Evento = value.Trim(); }
        }
        public int IdMateria
        {
            get { return _IdMateria; }
            set { _IdMateria = value; }
        }
        public string DescMateria
        {
            get { return _DescMateria.Trim(); }
            set { _DescMateria = value.Trim(); }
        }
        public int IdConcepto
        {
            get { return _IdConcepto; }
            set { _IdConcepto = value; }
        }
        public string DescConcepto
        {
            get { return _DescConcepto.Trim(); }
            set { _DescConcepto = value.Trim(); }
        }
        public double Importe
        {
            get { return _Importe; }
            set { _Importe = value; }
        }
        public double Importe_Extemporaneo
        {
            get { return _Importe_Extemporaneo; }
            set { _Importe_Extemporaneo = value; }
        }
        public string Fecha_Limite
        {
            get { return _Fecha_Limite.Trim(); }
            set { _Fecha_Limite = value.Trim(); }
        }
        public string DescCarrera
        {
            get { return _DescCarrera.Trim(); }
            set { _DescCarrera = value.Trim(); }
        }
        public string IdCarrera
        {
            get { return _IdCarrera.Trim(); }
            set { _IdCarrera = value.Trim(); }
        }
        public int Semestre
        {
            get { return _Semestre; }
            set { _Semestre = value; }
        }
        public string Grupo
        {
            get { return _Grupo; }
            set { _Grupo = value; }
        }
    }
}
