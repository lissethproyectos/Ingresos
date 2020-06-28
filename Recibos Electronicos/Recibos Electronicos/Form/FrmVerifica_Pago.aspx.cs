using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using CapaEntidad;
using CapaNegocio;

namespace Recibos_Electronicos.Form
{
    public partial class FrmVerifica_Pago : System.Web.UI.Page
    {
        #region <Variables>
        CN_Comun CNComun = new CN_Comun();
        CN_Factura CNFactura = new CN_Factura();
        Factura ObjFactura = new Factura();
        string Verificador = "";
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Inicializar();
            }
        }
        protected void imgbtnBuscar_Click(object sender, ImageClickEventArgs e)
        {
            VerificaPago_Sauce();
        }
        #region <Funciones y Sub>
        private void Inicializar()
        {            
            CargarCombos();
            //CargarGrid();
        }
        private void CargarCombos()
        {
            try
            {
                CNComun.LlenaCombo("pkg_pagos.Obt_Ciclos_Escolares", ref ddlCiclo, "INGRESOS");
            }
            catch (Exception ex)
            {
                lblMsj.Text = ex.Message;
            }
        }
        private void CargarGrid()
        {
            try
            {
                DataTable dt = new DataTable();
                grvFacturas.DataSource = dt;
                grvFacturas.DataSource = GetList();
                grvFacturas.DataBind();
            }
            catch (Exception ex)
            {
                lblMsj.Text = ex.Message;
            }
        }
        private List<Factura> GetList()
        {
            try
            {
                List<Factura> List = new List<Factura>();
                ObjFactura.FACT_MATRICULA = txtMatricula.Text;
                CNFactura.FacturaConsultaGrid_Ref_Sauce(ObjFactura, ddlCiclo.SelectedValue, ref List);

                return List;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        private void VerificaPago_Sauce()
        {
            try
            {
                ObjFactura.FACT_MATRICULA = txtMatricula.Text;
                CNFactura.FacturaConsultaPago_Sauce(ref ObjFactura, ddlCiclo.SelectedValue, ref Verificador);
                if (Verificador == "0")
                {
                    CargarGrid();
                }
                else
                {
                    lblMsj.Text = Verificador;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        //private List<Factura> GetList()
        //{
        //    try
        //    {
        //        List<Factura> List = new List<Factura>();
        //        ObjFactura.FACT_MATRICULA = txtMatricula.Text;
        //        CNFactura.FacturaConsultaPago_Sauce(ref ObjFactura, ddlCiclo.SelectedValue, ref Verificador);                
                
        //        return List;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message);
        //    }
        //}       
        #endregion
    }
}