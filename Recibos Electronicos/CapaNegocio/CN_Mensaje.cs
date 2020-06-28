using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CapaEntidad;
using CapaDatos;
namespace CapaNegocio
{
    public class CN_Mensaje
    {
        public void ConsultarMensajes(Mensaje objMensaje, ref List<Mensaje> List)
        {
            try
            {
                CD_Mensaje CDMensaje = new CD_Mensaje();
                CDMensaje.ConsultarMensajes(objMensaje, ref List);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void ObtenerMensajes(ref Mensaje objMensaje, ref string Verificador)
        {
            try
            {
                CD_Mensaje CDMensaje = new CD_Mensaje();
                CDMensaje.ObtenerMensajes(ref objMensaje, ref Verificador);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void MensajeInsertar(Mensaje objMensaje, ref string Verificador)
        {
            try
            {
                CD_Mensaje CDMensaje = new CD_Mensaje();
                CDMensaje.MensajeInsertar(objMensaje, ref Verificador);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void MensajeEditar(Mensaje objMensaje, ref string Verificador)
        {
            try
            {
                CD_Mensaje CDMensaje = new CD_Mensaje();
                CDMensaje.MensajeEditar(objMensaje, ref Verificador);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void MensajeEliminar(Mensaje objMensaje, ref string Verificador)
        {
            try
            {
                CD_Mensaje CDMensaje = new CD_Mensaje();
                CDMensaje.MensajeEliminar(objMensaje, ref Verificador);                
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
