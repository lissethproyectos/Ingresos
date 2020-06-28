using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapaEntidad
{
    public class Configuracion_Evento
    {
        public Configuracion_Evento()
        {
            GRUPO = new HashSet<TipoParticipante>();
        }
        public ICollection<TipoParticipante> GRUPO { get; private set; }

    }

    public class TipoParticipante
    {

        public string Id { get; set; }
        public string Tipo_Participante { get; set; }
        public string Desc_Tipo_Participante { get; set; }
        public string Requiere_Constancia { get; set; }
        public string Es_Ponente { get; set; }
        public string Participante { get; set; }
        public string Evento { get; set; }
        public string Nuevo { get; set; }
        public string Editar { get; set; }
        public string Eliminar { get; set; }
        public string Es_Concepto { get; set; }

        public TipoParticipante()
        {
            Conceptos = new HashSet<Concepto>();
        }
        public ICollection<Concepto> Conceptos { get; private set; }

        //public TipoParticipante(string Tipo_Participante, string Desc_Tipo_Participante, string Requiere_Constancia, string Es_Ponente, string Participante, string Evento)
        //{
        //    this.Tipo_Participante = Tipo_Participante;
        //    this.Desc_Tipo_Participante = Desc_Tipo_Participante;
        //    this.Requiere_Constancia = Requiere_Constancia;
        //    this.Es_Ponente = Es_Ponente;
        //    this.Participante = Participante;
        //    this.Evento = Evento;
        //}
    }

    public class Concepto
    {
        public string Tipo_Participante { get; set; }
        public int IdConcepto { get; set; }
        public string CveConcepto { get; set; }
        public string DescConcepto { get; set; }
        public double Importe { get; set; }
        public string Evento { get; set; }
        public string Dependencia { get; set; }
        public string Status { get; set; }
        public string Nuevo { get; set; }
        public string Editar { get; set; }
        public string Eliminar { get; set; }



        public string Desc_Tipo_Participante { get; set; }
        public string Es_Ponente { get; set; }
        public string Requiere_Constancia { get; set; }

    }



}
