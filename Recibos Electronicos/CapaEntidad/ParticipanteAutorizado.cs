using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapaEntidad
{
    public class ParticipanteAutorizado
    {
        private string _Evento;
        public string Evento
        {
            get { return _Evento.Trim(); }
            set { _Evento = value.Trim(); }
        }

        private string _Matricula;
        public string Matricula
        {
            get { return _Matricula.Trim(); }
            set { _Matricula = value.Trim(); }
        }

        private string _Status;
        public string Status
        {
            get { return _Status.Trim(); }
            set { _Status = value.Trim(); }
        }

        private string _Nombre;
        public string Nombre
        {
            get { return _Nombre.Trim(); }
            set { _Nombre = value.Trim(); }
        }

        private string _Nivel;
        public string Nivel
        {
            get { return _Nivel.Trim(); }
            set { _Nivel = value.Trim(); }
        }
    }
}
