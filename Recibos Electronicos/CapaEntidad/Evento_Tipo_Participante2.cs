using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapaEntidad
{
    public class Evento_Tipo_Participante2
    {
        private string _Id;
        public string Id
        {
            get { return _Id; }
            set { _Id = value; }
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

        private string _Requiere_Constancia;
        public string Requiere_Constancia
        {
            get { return _Requiere_Constancia; }
            set { _Requiere_Constancia = value; }
        }

        private string _Es_Ponente;
        public string Es_Ponente
        {
            get { return _Es_Ponente; }
            set { _Es_Ponente = value; }
        }

        private string _Participante;
        public string Participante
        {
            get { return _Participante; }
            set { _Participante = value; }
        }

        private string _Evento;
        public string Evento
        {
            get { return _Evento; }
            set { _Evento = value; }
        }

        private ConceptoCuotaLibre _conceptos_evento = new ConceptoCuotaLibre();
        public ConceptoCuotaLibre conceptos_evento
        {

            get { return _conceptos_evento; }
            set { _conceptos_evento = value; }
        }

    }
}
