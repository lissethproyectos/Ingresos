using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CapaDatos;
using CapaEntidad;
namespace CapaNegocio
{
   public  class CN_Evento
    {
        public void ConsultarEventos(ref Evento Objeventos, ref List<Evento> List, string Busqueda)
        {
            try
            {
                CD_Evento CDeventos = new CD_Evento();
                CDeventos.ConsultarEventos(ref Objeventos, ref List, Busqueda);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void ConsultarOficios(string Evento, ref List<Evento> List)
        {
            try
            {
                CD_Evento CDeventos = new CD_Evento();
                CDeventos.ConsultarOficios(Evento, ref List);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void ConsultarOficiosEvento(string Evento, ref List<Oficio> List)
        {
            try
            {
                CD_Evento CDeventos = new CD_Evento();
                CDeventos.ConsultarOficiosEvento(Evento, ref List);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void EventoEditar(Evento objeventos, string Usuario,  ref string Verificador)
        {
            try
            {
                CD_Evento CDeventos = new CD_Evento();
                CDeventos.EventoEditar(objeventos, Usuario, ref Verificador);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void EventoEditarStatus(ref Evento objeventos, ref string Verificador)
        {
            try
            {
                CD_Evento CDeventos = new CD_Evento();
                CDeventos.EventoEditarStatus(ref objeventos, ref Verificador);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void EventoInsertar(Evento Eventos, string Usuario, ref string Verificador)
        {
            try
            {
             
               CD_Evento CDeventos = new CD_Evento();
                CDeventos.EventoInsertar(Eventos, Usuario, ref Verificador);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void EventoInsertarDetPart(ref ConceptoCuotaLibre Eventos, ref string Verificador)
        {
            try
            {

                CD_Evento CDeventos = new CD_Evento();
                CDeventos.EventoInsertarDetPart(ref Eventos, ref Verificador);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void EventoInsertarDetConcept(ConceptoCuotaLibre Eventos, ref string Verificador)
        {
            try
            {

                CD_Evento CDeventos = new CD_Evento();
                CDeventos.EventoInsertarDetConcept(Eventos, ref Verificador);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void EventoEspecialInsertar(Evento Eventos, string Usuario, string VersionNueva, ref string Verificador)
        {
            try
            {

                CD_Evento CDeventos = new CD_Evento();
                CDeventos.EventoEspecialInsertar(Eventos, Usuario, VersionNueva, ref Verificador);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void EventoInsertarDetalle(List<TipoParticipante> lstParticipante, string Evento, ref string Verificador)
        {
            try
            {

                CD_Evento CDeventos = new CD_Evento();
                CDeventos.EventoInsertarDetalle(lstParticipante, Evento, ref Verificador);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void EventoInsertarConfiguracion(List<ConceptoCuotaLibre> lstConfiguracion, string Evento, ref string Verificador)
        {
            try
            {

                CD_Evento CDeventos = new CD_Evento();
                CDeventos.EventoInsertarConfiguracion(lstConfiguracion, Evento, ref Verificador);
                if(Verificador=="0")
                    CDeventos.EventoInsertarConfiguracionDetalle(lstConfiguracion, Evento, ref Verificador);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void EventoEditarDetalle(List<TipoParticipante> lstParticipante, string Evento, ref string Verificador)
        {
            try
            {

                CD_Evento CDeventos = new CD_Evento();
                CDeventos.EventoEditarDetalle(lstParticipante, Evento, ref Verificador);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void Insertar_Oficios(string Evento, List<Oficio> lstOficios, ref string Verificador)
        {
            try
            {

                CD_Evento CDeventos = new CD_Evento();
                CDeventos.Insertar_Oficios(Evento, lstOficios, ref Verificador);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void EventoEliminarDetalle(string Evento, ref string Verificador)
        {
            try
            {

                CD_Evento CDeventos = new CD_Evento();
                CDeventos.EventoEliminarDetalle(Evento, ref Verificador);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void EventoEliminarDetalleParticipante(List<TipoParticipante> lstParticipante, ref string Verificador)
        {
            try
            {

                CD_Evento CDeventos = new CD_Evento();
                CDeventos.EventoEliminarDetalleParticipante(lstParticipante, ref Verificador);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void EventoEliminarEventoParticipante(string Evento, ref string Verificador)
        {
            try
            {

                CD_Evento CDeventos = new CD_Evento();
                CDeventos.EventoEliminarEventoParticipante(Evento, ref Verificador);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void EventoEliminarDetalleConcepto(List<Concepto> lstConceptos, ref string Verificador)
        {
            try
            {

                CD_Evento CDeventos = new CD_Evento();
                CDeventos.EventoEliminarDetalleConcepto(lstConceptos, ref Verificador);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void Insertar_oficio(Evento Eventos, ref string Verificador)
        {
            try
            {

                CD_Evento CDeventos = new CD_Evento();
                CDeventos.Insertar_oficio(Eventos, ref Verificador);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void Editar_oficio(Evento Eventos, ref string Verificador)
        {
            try
            {

                CD_Evento CDeventos = new CD_Evento();
                CDeventos.Editar_oficio(Eventos, ref Verificador);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void ConceptoCuotaLibreInsertar(List<ConceptoCuotaLibre> List, ref string Verificador)
        {
            try
            {

                CD_Evento CDeventos = new CD_Evento();
                CDeventos.ConceptoCuotaLibreInsertar(List, ref Verificador);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void insertarConceptoCuotaLibre(ref ConceptoCuotaLibre objConceptoCuotaLibre, ref string Verificador)
        {
            try
            {
                CD_Evento CDCD_Evento = new CD_Evento();
                CDCD_Evento.insertarConceptoCuotaLibre(ref objConceptoCuotaLibre, ref Verificador);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void ConsultarUnevento(ref Evento objeventos, ref string Verificador)
        {
            try
            {
               CD_Evento CDevento = new CD_Evento();
               CDevento.ConsultarUnevento(ref  objeventos, ref Verificador);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void ConsultarOficio(ref Evento objeventos, ref string Verificador)
        {
            try
            {
                CD_Evento CDevento = new CD_Evento();
                CDevento.ConsultarOficio(ref objeventos, ref Verificador);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void ConsultarCveEvento(ref Evento objeventos, ref string Verificador)
        {
            try
            {
                CD_Evento CDevento = new CD_Evento();
                CDevento.ConsultarCveEvento(ref objeventos, ref Verificador);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void ConsultarEventos_conceptos(ref ConceptoCuotaLibre ObjConceptoCuotaLibre, ref List<ConceptoCuotaLibre> List)
        {
            try
            {
                CD_Evento CDeventos = new CD_Evento();
                CDeventos.ConsultarEventos_conceptos(ref ObjConceptoCuotaLibre, ref List);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void ConsultarEventos_Detalle(ref ConceptoCuotaLibre ObjConceptoCuotaLibre, ref List<ConceptoCuotaLibre> List)
        {
            try
            {
                CD_Evento CDeventos = new CD_Evento();
                CDeventos.ConsultarEventos_Detalle(ref ObjConceptoCuotaLibre, ref List);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void ConsultarEvento_Participantes(ref ConceptoCuotaLibre ObjParticipantes, ref List<ConceptoCuotaLibre> List)
        {
            try
            {
                CD_Evento CDeventos = new CD_Evento();
                CDeventos.ConsultarEvento_Participantes(ref ObjParticipantes, ref List);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void ConsultarEventoDetParticipantes(ConceptoCuotaLibre ObjParticipantes, ref List<ConceptoCuotaLibre> List)
        {
            try
            {
                CD_Evento CDeventos = new CD_Evento();
                CDeventos.ConsultarEventoDetParticipantes(ObjParticipantes, ref List);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void ConsultarEventoDetConceptos(ConceptoCuotaLibre ObjParticipantes, ref List<ConceptoCuotaLibre> List)
        {
            try
            {
                CD_Evento CDeventos = new CD_Evento();
                CDeventos.ConsultarEventoDetConceptos(ObjParticipantes, ref List);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void ConsultarEventoParticipantes(string Evento, ref TipoParticipante ObjParticipantes, ref List<TipoParticipante> List)
        {
            try
            {
                CD_Evento CDeventos = new CD_Evento();
                CDeventos.ConsultarEventoParticipantes(Evento, ref ObjParticipantes, ref List);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void Eliminar_Concepto_evento(ref ConceptoCuotaLibre ObjConceptoCuotaLibre, ref string Verificador)
        {
            try
            {

                CD_Evento CDEvento = new CD_Evento();
                CDEvento.Eliminar_Concepto_evento(ref ObjConceptoCuotaLibre, ref Verificador);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void Eliminar_Oficio(Evento objeventos, ref string Verificador)
        {
            try
            {

                CD_Evento CDEvento = new CD_Evento();
                CDEvento.Eliminar_Oficio(ref objeventos, ref Verificador);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void Eliminar_Oficios(Evento objeventos, ref string Verificador)
        {
            try
            {

                CD_Evento CDEvento = new CD_Evento();
                CDEvento.Eliminar_Oficios(objeventos, ref Verificador);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void ConsultarEventosRef(Evento Objeventos, string Usuario, string Status, string Reporte, ref List<Evento> List)
        {
            try
            {

                CD_Evento CDeventos = new CD_Evento();
                CDeventos.ConsultarEventosRef(Objeventos, Usuario, Status, Reporte, ref List);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void ConsultarEventosTipoUsu(Evento Objeventos, string Usuario, string TipoUsuario, string Status, string Buscar, ref List<Evento> List)
        {
            try
            {

                CD_Evento CDeventos = new CD_Evento();
                CDeventos.ConsultarEventosTipoUsu(Objeventos, Usuario, TipoUsuario, Status, Buscar, ref List);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void Editar_VigenciaEvento(Evento objeventos, ref string Verificador)
        {
            try
            {

                CD_Evento CDEvento = new CD_Evento();
                CDEvento.Editar_VigenciaEvento(objeventos, ref Verificador);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void Insertar_TipoPersona(ConceptoCuotaLibre objParticipante, ref string Verificador)
        {
            try
            {
                CD_Evento CDEvento = new CD_Evento();
                CDEvento.Insertar_TipoPersona(objParticipante, ref Verificador);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


    }
}
