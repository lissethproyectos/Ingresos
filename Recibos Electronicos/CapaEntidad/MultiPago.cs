using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapaEntidad
{
    public class MultiPago
    {
        private string _Origen = string.Empty;
        public string Origen
        {
            get { return _Origen; }
            set { _Origen = value; }
        }

        private int _Id_Fact = 0;
        public int Id_Fact
        {
            get { return _Id_Fact; }
            set { _Id_Fact = value; }
        }

        private int _IdFichaBancaria = 0;
        public int IdFichaBancaria
        {
            get { return _IdFichaBancaria; }
            set { _IdFichaBancaria = value; }
        }

        private string _Carrera = string.Empty;
        public string Carrera
        {
            get { return _Carrera; }
            set { _Carrera = value; }
        }

        private string _Account = string.Empty;
        public string Account
        {
            get { return _Account; }
            set { _Account = value; }
        }

        private string _Order = string.Empty;
        public string Order
        {
            get { return _Order; }
            set { _Order = value; }
        }

        private string _Reference = string.Empty;
        public string Reference
        {
            get { return _Reference; }
            set { _Reference = value; }
        }

        private string _Node = string.Empty;
        public string Node
        {
            get { return _Node; }
            set { _Node = value; }
        }

        private string _Concept = string.Empty;
        public string Concept
        {
            get { return _Concept; }
            set { _Concept = value; }
        }

        private string _Amount = string.Empty;
        public string Amount
        {
            get { return _Amount; }
            set { _Amount = value; }
        }

        private string _Currency = string.Empty;
        public string Currency
        {
            get { return _Currency; }
            set { _Currency = value; }
        }

        private string _PaymentMethod = string.Empty;
        public string PaymentMethod
        {
            get { return _PaymentMethod; }
            set { _PaymentMethod = value; }
        }

        private string _PaymentMethodComplete = string.Empty;
        public string PaymentMethodComplete
        {
            get { return _PaymentMethodComplete; }
            set { _PaymentMethodComplete = value; }
        }

        private string _Response = string.Empty;
        public string Response
        {
            get { return _Response; }
            set { _Response = value; }
        }

        private string _ResponseComplete = string.Empty;
        public string ResponseComplete
        {
            get { return _ResponseComplete; }
            set { _ResponseComplete = value; }
        }

        private string _Responsemsg = string.Empty;
        public string Responsemsg
        {
            get { return _Responsemsg; }
            set { _Responsemsg = value; }
        }

        private string _ResponseMsgComplete = string.Empty;
        public string ResponseMsgComplete
        {
            get { return _ResponseMsgComplete; }
            set { _ResponseMsgComplete = value; }
        }

        private string _Authorization = string.Empty;
        public string Authorization
        {
            get { return _Authorization; }
            set { _Authorization = value; }
        }

        private string _AuthorizationComplete = string.Empty;
        public string AuthorizationComplete
        {
            get { return _AuthorizationComplete; }
            set { _AuthorizationComplete = value; }
        }

        private string _Pan = string.Empty;
        public string Pan
        {
            get { return _Pan; }
            set { _Pan = value; }
        }

        private string _PanComplete = string.Empty;
        public string PanComplete
        {
            get { return _PanComplete; }
            set { _PanComplete = value; }
        }

        private string _Date = string.Empty;
        public string Date
        {
            get { return _Date; }
            set { _Date = value; }
        }

        private string _Signature = string.Empty;
        public string Signature
        {
            get { return _Signature; }
            set { _Signature = value; }
        }

        private string _Customername = string.Empty;
        public string Customername
        {
            get { return _Customername; }
            set { _Customername = value; }
        }

        private string _Promo_Msi = string.Empty;
        public string Promo_Msi
        {
            get { return _Promo_Msi; }
            set { _Promo_Msi = value; }
        }

        private string _Bankcode = string.Empty;
        public string Bankcode
        {
            get { return _Bankcode; }
            set { _Bankcode = value; }
        }

        private string _Saleid = string.Empty;
        public string Saleid
        {
            get { return _Saleid; }
            set { _Saleid = value; }
        }

        private string _Sale_Historyid = string.Empty;
        public string Sale_Historyid
        {
            get { return _Sale_Historyid; }
            set { _Sale_Historyid = value; }
        }

        private string _Trx_Historyid = string.Empty;
        public string Trx_Historyid
        {
            get { return _Trx_Historyid; }
            set { _Trx_Historyid = value; }
        }

        private string _Trx_Historyidcomplete = string.Empty;
        public string Trx_Historyidcomplete
        {
            get { return _Trx_Historyidcomplete; }
            set { _Trx_Historyidcomplete = value; }
        }

        private string _Bankname = string.Empty;
        public string Bankname
        {
            get { return _Bankname; }
            set { _Bankname = value; }
        }

        private string _Folio = string.Empty;
        public string Folio
        {
            get { return _Folio; }
            set { _Folio = value; }
        }

        private string _Cardholdername = string.Empty;
        public string Cardholdername
        {
            get { return _Cardholdername; }
            set { _Cardholdername = value; }
        }

        private string _Cardholdernamecomplete = string.Empty;
        public string Cardholdernamecomplete
        {
            get { return _Cardholdernamecomplete; }
            set { _Cardholdernamecomplete = value; }
        }

        private string _Authorization_Mp1 = string.Empty;
        public string Authorization_Mp1
        {
            get { return _Authorization_Mp1; }
            set { _Authorization_Mp1 = value; }
        }

        private string _Phone = string.Empty;
        public string Phone
        {
            get { return _Phone; }
            set { _Phone = value; }
        }

        private string _Email = string.Empty;
        public string Email
        {
            get { return _Email; }
            set { _Email = value; }
        }

        private string _Promo = string.Empty;
        public string Promo
        {
            get { return _Promo; }
            set { _Promo = value; }
        }

        private string _Promo_msi_bank = string.Empty;
        public string Promo_msi_bank
        {
            get { return _Promo_msi_bank; }
            set { _Promo_msi_bank = value; }
        }

        private string _Securepayment = string.Empty;
        public string Securepayment
        {
            get { return _Securepayment; }
            set { _Securepayment = value; }
        }

        private string _Cardtype = string.Empty;
        public string Cardtype
        {
            get { return _Cardtype; }
            set { _Cardtype = value; }
        }

        private int _Contador = 0;
        public int Contador
        {
            get { return _Contador; }
            set { _Contador = value; }
        }
    }
}
