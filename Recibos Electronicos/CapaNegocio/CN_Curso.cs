using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Text;
using System.Web.UI;
using CapaEntidad;
using CapaDatos;

namespace CapaNegocio
{
    public class CN_Curso
    {
        public void CursoConsultaGrid(Curso ObjCurso, string Busqueda, ref List<Curso> List)
        {
            try
            {
                CD_Curso DatosCurso = new CD_Curso();
                DatosCurso.CursoConsultaGrid(ObjCurso, Busqueda, ref List);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void CursoInsertar(ref Curso ObjCurso, ref string Verificador)
        {
            try
            {
                CD_Curso CDCurso = new CD_Curso();
                CDCurso.CursoInsertar(ref ObjCurso, ref Verificador);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void CursoEditar(ref Curso ObjCurso, ref string Verificador)
        {
            try
            {
                CD_Curso CDCurso = new CD_Curso();
                CDCurso.CursoEditar(ref ObjCurso, ref Verificador);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void CursoEliminar(ref Curso ObjCurso, ref string Verificador)
        {
            try
            {
                CD_Curso CDCurso = new CD_Curso();
                CDCurso.CursoEliminar(ref ObjCurso, ref Verificador);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void ConsultarCursoSel(ref Curso ObjCurso, ref string Verificador)
        {
            try
            {
                CD_Curso CDCurso = new CD_Curso();
                CDCurso.ConsultarCursoSel(ref ObjCurso, ref Verificador);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
