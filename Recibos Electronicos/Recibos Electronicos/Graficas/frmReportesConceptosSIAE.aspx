<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmReportesConceptosSIAE.aspx.cs" Inherits="Recibos_Electronicos.Graficas.frmReportesConceptosSIAE" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script type="text/javascript">
        function RedirectGraficas(Cve, Form) {
            //alert(Cve);
            $('#frmGraficas').attr('src', 'https://sysweb.unach.mx/INGRESOS_MVC/Home/Index?WXI=' + Cve + '&Formulario=' + Form);
            //window.location.href = 'https://sysweb.unach.mx/INGRESOS_MVC/Home/Index?WXI=' + Cve + '&Formulario=' + Form;

            $('#frmGraficas').reload();
        }
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container-fluid">
        <div class="row">
            <div class="col">
                <iframe id="frmGraficas" style="width: 100%; height: 900px" frameborder="NO" name="frmGraficas"></iframe>
            </div>
        </div>
    </div>
</asp:Content>
