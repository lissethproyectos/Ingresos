using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapaNegocio
{
    public class CN_Bien
    {
        public void ConsultarGrid(string Tipo_Bien, Bien Parametros, string Buscar,  string Grupo, ref List<Bien> List)
        {
            try
            {
                CD_Bien DatosBien = new CD_Bien();
                DatosBien.ConsultarGrid(Tipo_Bien, Parametros, Buscar, Grupo, ref List);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void ConsultarGridCatProductosServicios(string Tipo_Bien, ref List<Bien> List)
        {
            try
            {
                CD_Bien DatosBien = new CD_Bien();
                DatosBien.ConsultarGridCatProductosServicios(Tipo_Bien, ref List);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void ConsultarGridServicios(string Dependencia, string Buscar, ref List<Bien> List)
        {
            try
            {
                CD_Bien DatosBien = new CD_Bien();
                DatosBien.ConsultarGridServicios(Dependencia, Buscar, ref List);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void ConsultarGridDetalle(Bien objBien, ref List<Bien> List)
        {
            try
            {
                CD_Bien DatosBien = new CD_Bien();
                DatosBien.ConsultarGridDetalle(objBien, ref List);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void InsertarFichaReferenciada(ref FichaReferenciada FichaReferenciada, ref string Verificador)
        {
            try
            {
                CD_Bien CDFichaReferenciada = new CD_Bien();
                CDFichaReferenciada.InsertarFichaReferenciada(ref FichaReferenciada, ref Verificador);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void GenerarID(ref FichaReferenciada FichaReferenciada)
        {
            try
            {
                CD_Bien CDFichaReferenciada = new CD_Bien();
                CDFichaReferenciada.GenerarID(ref FichaReferenciada);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void GenerarReferencia(ref FichaReferenciada FichaReferenciada)
        {
            try
            {
                CD_Bien CDFichaReferenciada = new CD_Bien();
                CDFichaReferenciada.GenerarReferencia(ref FichaReferenciada);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void InsertarDetalleConceptoPago(int Id_Ficha_Bancaria, ref string Verificador, ref List<Bien> List)
        {
            try
            {
                CD_Bien CDConceptoPago = new CD_Bien();
                CDConceptoPago.InsertarDetalleConceptoPago(Id_Ficha_Bancaria, ref Verificador, ref List);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void EditarConceptoPago(ConceptoPago ObjConceptoPago, ref string Verificador)
        {
            try
            {
                CD_Bien CDConceptoPago = new CD_Bien();
                CDConceptoPago.EditarConceptoPago(ObjConceptoPago, ref Verificador);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void EliminarDetalleConceptoPago(int Id_Ficha_Bancaria, ref string Verificador)
        {
            try
            {
                CD_Bien CDBien = new CD_Bien();
                CDBien.EliminarDetalleConceptoPago(Id_Ficha_Bancaria, ref Verificador);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void InsertarBien(Bien ObjBien, ref string Verificador)
        {
            try
            {
                CD_Bien CDBien = new CD_Bien();
                CDBien.InsertarBien(ObjBien, ref Verificador);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void InsertarServicio(Bien ObjServicio, ref string Verificador)
        {
            try
            {
                CD_Bien CDBien = new CD_Bien();
                CDBien.InsertarServicio(ObjServicio, ref Verificador);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void EliminarBien(Bien ObjBien, ref string Verificador)
        {
            try
            {
                CD_Bien CDBien = new CD_Bien();
                CDBien.EliminarBien(ObjBien, ref Verificador);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void EditarBien(Bien ObjBien, ref string Verificador)
        {
            try
            {
                CD_Bien CDBien = new CD_Bien();
                CDBien.EditarBien(ObjBien, ref Verificador);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void EliminarServicio(Bien ObjBien, ref string Verificador)
        {
            try
            {
                CD_Bien CDBien = new CD_Bien();
                CDBien.EliminarServicio(ObjBien, ref Verificador);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void EditarServicio(Bien ObjBien, ref string Verificador)
        {
            try
            {
                CD_Bien CDBien = new CD_Bien();
                CDBien.EditarServicio(ObjBien, ref Verificador);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void ConsultarServicio(ref Bien ObjBien, ref string Verificador)
        {
            try
            {
                CD_Bien CDBien = new CD_Bien();
                CDBien.ConsultarServicio(ref ObjBien, ref Verificador);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void EliminarDetallePago_Ventas(int Ficha_Bancaria, ref string Verificador)
        {
            try
            {
                CD_Bien CDConceptoPago = new CD_Bien();
                CDConceptoPago.EliminarDetallePago_Ventas(Ficha_Bancaria, ref Verificador);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void EliminarConceptoPago(int Ficha_Bancaria, ref string Verificador)
        {
            try
            {
                CD_Bien CDConceptoPago = new CD_Bien();
                CDConceptoPago.EliminarConceptoPago(Ficha_Bancaria, ref Verificador);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public void InsertarDetallePago_Ventas(int Id_Ficha_Bancaria, ref string Verificador, List<Bien> List)
        {
            try
            {
                CD_Bien CDConceptoPago = new CD_Bien();
                CDConceptoPago.InsertarDetallePago_Ventas(Id_Ficha_Bancaria, ref Verificador, List);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
