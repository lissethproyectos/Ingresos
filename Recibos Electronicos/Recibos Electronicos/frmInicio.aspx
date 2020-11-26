
<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmInicio.aspx.cs" Inherits="Recibos_Electronicos.frmInicio" %>

<%@ Register TagName="uCCorreo" TagPrefix="usr" Src="EnviarCorreo.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .auto-style4 {
            width: 781px;
            text-align: center;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    
        <div class="container">
            <div class="row">
                        <div class="col-sm-6">
            <div class="card">
                <div class="card-body">
                    <h5 class="card-title">
                        <img src="Imagenes/opc1.png" class="auto-style2" />Mis Recibos</h5>
                    <p class="card-text">Podras obtener tu(s) comprobante(s) de pago.</p>
                    <a href="Default.aspx?mnu=MOV" class="btn btn-warning btn-rounded">Continuar</a>
                </div>
            </div>
        </div>
        <div class="col-sm-6">
            <div class="card">
                <div class="card-body">
                    <h5 class="card-title">
                        <img src="Imagenes/opc2.png" class="auto-style2" /> Mis Facturas
                    </h5>
                    <p class="card-text">
                        Podras solicitar y consultar tu(s) factura(s).
                    </p>
                    <a href="Default.aspx?mnu=REP" class="btn btn-warning btn-rounded">Continuar</a>
                </div>
            </div>
        </div>
            </div>
            </div>
    



    <script type="text/javascript" src="Scripts/jsQR.js"></script>
    <script type="text/javascript" src="Scripts/QRModel.js"></script>
</asp:Content>
