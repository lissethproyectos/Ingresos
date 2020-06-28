using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapaEntidad
{
    public class Alumno:Persona
    {

        private bool _GenerarPermiso;
        public bool GenerarPermiso
        {
            get { return _GenerarPermiso; }
            set { _GenerarPermiso = value; }
        }

        private string _FechaFinal;
        public string FechaFinal
        {
            get { return _FechaFinal; }
            set { _FechaFinal = value; }
        }

        private string _FechaInicial;
        public string FechaInicial
        {
            get { return _FechaInicial; }
            set { _FechaInicial = value; }
        }

        private string _Observaciones;
        public string Observaciones
        {
            get { return _Observaciones; }
            set { _Observaciones = value; }
        }

        private string _OficioFecha;
        public string OficioFecha
        {
            get { return _OficioFecha; }
            set { _OficioFecha = value; }
        }
        
        private string _OficioFirma;
        public string OficioFirma
        {
            get { return _OficioFirma; }
            set { _OficioFirma = value; }
        }
        
        private string _OficioSolicito;
        public string OficioSolicito
        {
            get { return _OficioSolicito; }
            set { _OficioSolicito = value; }
        }

        private string _OficioQuienSolicita;
        public string OficioQuienSolicita
        {
            get { return _OficioQuienSolicita; }
            set { _OficioQuienSolicita = value; }
        }

        private string _OficioTiene;
        public string OficioTiene
        {
            get { return _OficioTiene; }
            set { _OficioTiene = value; }
        }

        private string _LinkEsquema;
        public string LinkEsquema
        {
            get { return _LinkEsquema; }
            set { _LinkEsquema = value; }
        }

        private string _Esquema;
        public string Esquema
        {
            get { return _Esquema; }
            set { _Esquema = value; }
        }



        private string _Porcentaje;
        public string PorcentajeDescuento
        {
            get { return _Porcentaje; }
            set { _Porcentaje = value; }
        }
        
        private string _TipoDescuento;
        public string TipoDescuento
        {
            get { return _TipoDescuento; }
            set { _TipoDescuento = value; }
        }

        private string _SubTipoDescuento;
        public string SubTipoDescuento
        {
            get { return _SubTipoDescuento; }
            set { _SubTipoDescuento = value; }
        }

        private string _ConceptoDescuento;
        public string ConceptoDescuento
        {
            get { return _ConceptoDescuento; }
            set { _ConceptoDescuento = value; }
        }
        
        private bool _GenerarRecibo;
        public bool GenerarRecibo
        {
            get { return _GenerarRecibo; }
            set { _GenerarRecibo = value; }
        }

        private string _CicloEscolar;
        public string CicloEscolar
        {
            get { return _CicloEscolar; }
            set { _CicloEscolar = value; }
        }

        private string _Nivel;
        public string Nivel
        {
            get { return _Nivel; }
            set { _Nivel = value; }
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

        private string _Carrera;
        public string Carrera
        {
            get { return _Carrera; }
            set { _Carrera = value; }
        }

        private string _DescCarrera;
        public string DescCarrera
        {
            get { return _DescCarrera; }
            set { _DescCarrera = value; }
        }

        private string _DescEscuela;
        public string DescEscuela
        {
            get { return _DescEscuela; }
            set { _DescEscuela = value; }
        }

        private string _Matricula;
        public string Matricula
        {
            get { return _Matricula; }
            set { _Matricula = value; }
        }

        private string _UsuNombre;
        public string UsuNombre
        {
            get { return _UsuNombre; }
            set { _UsuNombre = value; }
        }

        private string _StatusMatricula;
        public string StatusMatricula
        {
            get { return _StatusMatricula; }
            set { _StatusMatricula = value; }
        }

        private string _ImageStatusMatricula;
        public string ImageStatusMatricula
        {
            get { return _ImageStatusMatricula; }
            set { _ImageStatusMatricula = value; }
        }

        private string _SolicitoNombre;
        public string SolicitoNombre
        {
            get { return _SolicitoNombre; }
            set { _SolicitoNombre = value; }
        }

        private string _SolicitoFecha;
        public string SolicitoFecha
        {
            get { return _SolicitoFecha; }
            set { _SolicitoFecha = value; }
        }

        private string _AutorizoNombre;
        public string AutorizoNombre
        {
            get { return _AutorizoNombre; }
            set { _AutorizoNombre = value; }
        }

        private string _AutorizoFecha;
        public string AutorizoFecha
        {
            get { return _AutorizoFecha; }
            set { _AutorizoFecha = value; }
        }

        private string _GeneroNombre;
        public string GeneroNombre
        {
            get { return _GeneroNombre; }
            set { _GeneroNombre = value; }
        }

        private string _GeneroFecha;
        public string GeneroFecha
        {
            get { return _GeneroFecha; }
            set { _GeneroFecha = value; }
        }

        private string _Sede;
        public string Sede
        {
            get { return _Sede; }
            set { _Sede = value; }
        }

        private string _Password;
        public string Password
        {
            get { return _Password; }
            set { _Password = value; }
        }

        private int _NoActivo;
        public int NoActivo
        {
            get { return _NoActivo; }
            set { _NoActivo = value; }
        }

        private int _NoSuspendido;
        public int NoSuspendido
        {
            get { return _NoSuspendido; }
            set { _NoSuspendido = value; }
        }

        private int _TotalMatricula;
        public int TotalMatricula
        {
            get { return _TotalMatricula; }
            set { _TotalMatricula = value; }
        }


/*DATOS DEL PADRE/MADRE*/
        private int _IdEmpleado;
        public int IdEmpleado
        {
            get { return _IdEmpleado; }
            set { _IdEmpleado = value; }
        }

        private int _IdFamiliar;
        public int IdFamiliar
        {
            get { return _IdFamiliar; }
            set { _IdFamiliar = value; }
        }

        private string _NombreEmpleado;
        public string NombreEmpleado
        {
            get { return _NombreEmpleado; }
            set { _NombreEmpleado = value; }
        }

        private string _Adscripcion;
        public string Adscripcion
        {
            get { return _Adscripcion; }
            set { _Adscripcion = value; }
        }

        private string _Parentesco;
        public string Parentesco
        {
            get { return _Parentesco; }
            set { _Parentesco = value; }
        }

        /*-----FIN-----*/

        private string _FechaNacimiento;
        public string FechaNacimiento
        {
            get { return _FechaNacimiento; }
            set { _FechaNacimiento = value; }
        } 

        private Comun _registro = new Comun();
        public Comun registro
        {

            get { return _registro; }
            set { _registro = value; }
        }

        private Oficio _oficio = new Oficio();
        public Oficio oficio
        {

            get { return _oficio; }
            set { _oficio = value; }
        }
    }
}
