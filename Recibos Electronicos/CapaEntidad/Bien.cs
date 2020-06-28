using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapaEntidad
{
    public class Bien
    {
        private int _Id_Ficha_Bancaria;
        public int Id_Ficha_Bancaria
        {
            get { return _Id_Ficha_Bancaria; }
            set { _Id_Ficha_Bancaria = value; }
        }

        private string _Id_Inventario;
        public string Id_Inventario
        {
            get { return _Id_Inventario; }
            set { _Id_Inventario = value; }
        }

        private string _No_Inventario;
        public string No_Inventario
        {
            get { return _No_Inventario; }
            set { _No_Inventario = value; }
        }

        private string _Tipo;
        public string Tipo
        {
            get { return _Tipo; }
            set { _Tipo = value; }
        }

        private string _TipoGrupo;
        public string TipoGrupo
        {
            get { return _TipoGrupo; }
            set { _TipoGrupo = value; }
        }

        private string _Grupo;
        public string Grupo
        {
            get { return _Grupo; }
            set { _Grupo = value; }
        }

        private string _Producto;
        public string Producto
        {
            get { return _Producto; }
            set { _Producto = value; }
        }

        private string _Clave;
        public string Clave
        {
            get { return _Clave; }
            set { _Clave = value; }
        }

        private string _Concepto;
        public string Concepto
        {
            get { return _Concepto; }
            set { _Concepto = value; }
        }

        private int _Id_Concepto;
        public int Id_Concepto
        {
            get { return _Id_Concepto; }
            set { _Id_Concepto = value; }
        }

        private string _Descripcion;
        public string Descripcion
        {
            get { return _Descripcion; }
            set { _Descripcion = value; }
        }

        private string _Poliza;
        public string Poliza
        {
            get { return _Poliza; }
            set { _Poliza = value; }
        }

        private double _Costo;
        public double Costo
        {
            get { return _Costo; }
            set { _Costo = value; }
        }

        private double _Total;
        public double Total
        {
            get { return _Total; }
            set { _Total = value; }
        }

        private string _Dependencia;
        public string Dependencia
        {
            get { return _Dependencia; }
            set { _Dependencia = value; }
        }

        private string _Unidad_Medida;
        public string Unidad_Medida
        {
            get { return _Unidad_Medida; }
            set { _Unidad_Medida = value; }
        }

        private double _Cantidad;
        public double Cantidad
        {
            get { return _Cantidad; }
            set { _Cantidad = value; }
        }

        private string _Cta_Mayor;
        public string Cta_Mayor
        {
            get { return _Cta_Mayor; }
            set { _Cta_Mayor = value; }
        }

        private string _Estatus;
        public string Estatus
        {
            get { return _Estatus; }
            set { _Estatus = value; }
        }

        private string _Pagado;
        public string Pagado
        {
            get { return _Pagado; }
            set { _Pagado = value; }
        }
    }
}
