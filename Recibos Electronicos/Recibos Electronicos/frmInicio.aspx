<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmInicio.aspx.cs" Inherits="Recibos_Electronicos.frmInicio" %>

<%@ Register TagName="uCCorreo" TagPrefix="usr" Src="EnviarCorreo.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        
        .auto-style9 {
            width: 170px;
            height: 170px;
            margin-bottom: 2px;
        }
        .auto-style10 {
            width: 155px;
            height: 155px;
            margin-bottom: 2px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container">
        <div class="row">
            <div class="col-sm-4">
                <div class="card">
                    <div class="card-body">                                                
                        <h5 class="card-title">
                            <img src="../Imagenes/opc2.png" class="auto-style9"/> Recibos</h5>
                        <p class="card-text">
Comprobantes Electrónicos de pagos realizados a través de una ficha referenciada, por medio de tdc, debito, clabe, cie o ventanilla bancaria.                        <br />
                            
                        </p>
                        <a href="Principal.aspx" class="btn btn-warning btn-rounded">Continuar</a>
                    </div>
                </div>
            </div>
            <div class="col-sm-4">
                <div class="card">
                    <div class="card-body">
                        <h5 class="card-title">
                            <img src="Imagenes/pres8.png" class="auto-style9" />
                            Administración
                        </h5>
                        <p class="card-text">
                            Carga de layout, vigencia de referencias, gestión de usuarios, edición de recibos, etc.
                        <br />
                            <br />
                            
                        </p>
                        <a href="Default.aspx?mnu=REP" class="btn btn-warning btn-rounded">Continuar</a>
                    </div>
                </div>
            </div>
            <div class="col-sm-4">
                <div class="card">
                    <div class="card-body">
                        <h5 class="card-title">
                            <img src="Imagenes/pres7-1.png" class="auto-style9"/>Dashboard</h5>

                        <p class="card-text">Gráficas de ingresos por examén de admisión, curso de nivelación, inscripción u reinscripción.</p>
                        <br />
                        <a href="Graficas/frmReportesConceptosSIAE.aspx" class="btn btn-warning btn-rounded">Continuar</a>
                    </div>
                </div>
            </div>
        </div>
        <br />
        <div class="row"><div class="col alert alert-warning">
            Tienes 5 registros en el monitor.
                         </div></div>
    </div>




    <script type="text/javascript" src="Scripts/jsQR.js"></script>
    <script type="text/javascript" src="Scripts/QRModel.js"></script>
</asp:Content>
