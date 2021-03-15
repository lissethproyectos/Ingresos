using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;

namespace UV.Models
{
    public class EMPLEADO : PERSONA
    {
        public string categoria { get; set; }
        public string adscripcion { get; set; }
        public string tipo { get; set; }
        public string plaza { get; set; }
        public string idemp { get; set; }

    }

    public class DOCENTE : PERSONA
    {
        public int identificador { get; set; }
       
    }

    public class DOCENTE_ADMIVO
    {
        public int identificador { get; set; }
        public string rol { get; set; }
        public string nombre { get; set; }
        public string ap_paterno { get; set; }
        public string ap_materno { get; set; }
        public string genero { get; set; }
        public string facultad { get; set; }
    }


    public class EMP_DOCENTE
    {
        public int identificador { get; set; }
        public string rol { get; set; }
        public string nombre { get; set; }
        public string ap_paterno { get; set; }
        public string ap_materno { get; set; }
        public string genero { get; set; }
        public string facultad { get; set; }
    }

    public class EMP_ADMIVO
    {
        public int identificador { get; set; }
        public string rol { get; set; }
        public string nombre { get; set; }
        public string ap_paterno { get; set; }
        public string ap_materno { get; set; }
        public string genero { get; set; }
        public string adscripcion { get; set; }
    }

    public class RESULTADO
    {
        public bool error { get; set; }
        public string mensaje_error { get; set; }
        public List<EMPLEADO> usuario = new List<EMPLEADO>();
        //EMPLEADO USUARIO = new EMPLEADO();
        //public EMPLEADO USUARIO { get; set; }
    }

    public class RESULTADO_DOCENTE
    {
        public bool error { get; set; }
        public string mensaje_error { get; set; }
        public List<DOCENTE> usuario = new List<DOCENTE>();
    }

    public class RESULTADO_DOCENTE_ADMIVO
    {
        public bool error { get; set; }
        public string mensaje_error { get; set; }
        public List<DOCENTE_ADMIVO> usuario = new List<DOCENTE_ADMIVO>();
    }

    public class RESULTADO_EMP_DOCENTE
    {
        [Column(Order = 1)]
        public bool error { get; set; }
        [Column(Order = 2)]
        public string message { get; set; }
        [Column(Order = 3)]
        public List<EMP_DOCENTE> data = new List<EMP_DOCENTE>();
    }

    public class RESULTADO_EMP_ADMIVO
    {
        public bool error { get; set; }
        public string message { get; set; }
        public List<EMP_ADMIVO> data = new List<EMP_ADMIVO>();
    }
}