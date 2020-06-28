using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CapaEntidad;
using CapaDatos;

namespace CapaNegocio
{
    public class CN_Participante
    {
        public void ConsultarParticipante(ref Participante Participante, ref string Verificador)
        {
            try
            {
                CD_Participante CDParticipante = new CD_Participante();
                CDParticipante.ConsultarParticipante(ref Participante, ref Verificador);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        public void ConsultarEvento(ref Participante Participante, ref string Verificador)
        {
            try
            {
            CD_Participante CDParticipante = new CD_Participante();
            CDParticipante.ConsultarEvento(ref Participante, ref Verificador);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        public void InsertarParticipante(ref Participante Participante, ref string Verificador)
        {
            try
            {
            CD_Participante CDParticipante = new CD_Participante();
            CDParticipante.InsertarParticipante(ref Participante, ref Verificador);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        public void ActualizarParticipante(ref Participante Participante, ref string Verificador)
        {
            try
            {
            CD_Participante CDParticipante = new CD_Participante();
            CDParticipante.ActualizarParticipante(ref Participante, ref Verificador);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}
