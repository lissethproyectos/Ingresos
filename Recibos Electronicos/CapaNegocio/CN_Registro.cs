using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CapaDatos;
using CapaEntidad;

namespace CapaNegocio
{
    public class CN_Registro
    {
        public void ConsultarRegistros1(ref List<Registro> List)
        {
            try
            {
                CD_Registro CDRegistro = new CD_Registro();
                CDRegistro.ConsultarRegistros1(ref List);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void ConsultarRegistros2(ref List<Registro> List)
        {
            try
            {
                CD_Registro CDRegistro = new CD_Registro();
                CDRegistro.ConsultarRegistros2(ref List);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void ConsultarRegistros( ref List<Registro> List)
        {
            try
            {
                CD_Registro CDRegistro = new CD_Registro();
                CDRegistro.ConsultarRegistros(ref List);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void SincronizarRegistros(Registro ObjRegistro, ref string Verificador)
        {
            try
            {
                CD_Registro CDRegistro = new CD_Registro();
                CDRegistro.SincronizarRegistros(ObjRegistro, ref Verificador);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void refresh_vmaterilaizada(Registro ObjRegistro, ref string Verificador)
        {
            try
            {
                CD_Registro CDRegistro = new CD_Registro();
                CDRegistro.refresh_vmaterilaizada(ObjRegistro, ref Verificador);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void habilita_vmaterilaizada(Registro ObjRegistro, ref string Verificador)
        {
            try
            {
                CD_Registro CDRegistro = new CD_Registro();
                CDRegistro.habilita_vmaterilaizada(ObjRegistro, ref Verificador);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public void ConsultarRegistroMatricula(ref Registro ObjRegistro, ref List<Registro> List)
        {
            try
            {
                CD_Registro CDRegistro = new CD_Registro();
                CDRegistro.ConsultarRegistroMatricula(ref ObjRegistro, ref List);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void InhabilInsertar(ref Registro inhabil, ref string Verificador)
        {
            try
            {
                CD_Registro CDInhabil = new CD_Registro();
                CDInhabil.InhabilInsertar(ref inhabil, ref Verificador);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }



        public void InhabilEditar(ref Registro id , ref string Verificador)
        {
            try
            {
                CD_Registro CDinhabil = new CD_Registro();
               CDinhabil.InhabilEditar(ref id, ref Verificador);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void ConsultarDiaInhabil(ref Registro Objinhabil, ref List< Registro> List)
        {
            try
            {
                CD_Registro CDinhabil = new CD_Registro();
                CDinhabil.ConsultarDiaInhabil(ref  Objinhabil, ref List);
                
              

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }



        public void Consultarinhabil(ref Registro Objinhabil, ref string Verificador)
        {
            try
            {
                CD_Registro CDinhabil = new CD_Registro();
                CDinhabil.Consultarinhabil(ref  Objinhabil, ref Verificador);                
              
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void Eliminar_Dia_Inhabil(ref Registro Objinhabil, ref string Verificador)
        {
            try
            {
                CD_Registro CDMovto_Inhabil = new CD_Registro();
                CDMovto_Inhabil.Eliminar_Dia_Inhabil(Objinhabil , ref Verificador);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
