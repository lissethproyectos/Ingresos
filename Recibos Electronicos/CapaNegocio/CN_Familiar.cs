using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CapaEntidad;
using CapaDatos;

namespace CapaNegocio
{
    public class CN_Familiar
    {
        public void FamiliarInsertar(Alumno objFamiliar, ref string Verificador)
        {
            try
            {
                CD_Familiar CDFamiliar = new CD_Familiar();
                CDFamiliar.FamiliarInsertar(objFamiliar, ref Verificador);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
