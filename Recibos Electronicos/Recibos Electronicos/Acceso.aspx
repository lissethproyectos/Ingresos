<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Acceso.aspx.cs" Inherits="Recibos_Electronicos.Acceso" %>

<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>



<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
    <link type="image/x-icon" href="https://sysweb.unach.mx/resources/imagenes/favicon.ico" rel="shortcut icon" />
    <link rel="stylesheet" href="bootstrap/css/bootstrap.min.css">
    <link rel="stylesheet" type="text/css" href="bootstrap/css/mdb.css">

    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.4.1/jquery.min.js"></script>
    <script src="bootstrap/js/bootstrap.min.js"></script>


    <link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.3.1/css/all.css" integrity="sha384-mzrmE5qonljUremFsqc01SB46JvROS7bZs3IO2EmfFsd15uHvIt+Y8vEf7N7fWAU" crossorigin="anonymous" />
    <title>SYSWEB-COIN</title>

</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>


        <div class="page-header" style="background-color: #18386b">
            <div class="row">
                <div class="col-md-4">
                    <img id="imgSYSWEB" src="https://sysweb.unach.mx/resources/imagenes/sysweb2018230.png" class="img-fluid d-none d-sm-none d-md-block" alt="Responsive image" style="cursor: pointer" />
                </div>
                <div class="col-md-4 text-center text-white">
                    <%--                    <h1><small style="color: #FFFFFF">Recaudación de Pagos </small></h1>--%>
                    <h4>Recaudación de Pagos</h4>
                    <h5>Ingresos</h5>
                </div>
                <div class="col-md-4">
                    <img src="https://sysweb.unach.mx/resources/imagenes/unach.jpg" class="img-fluid d-none d-sm-none d-md-block" alt="Responsive image" style="cursor: pointer" />
                </div>
            </div>
        </div>
        <div class="bg-light">
            <article class="card-body mx-auto" style="max-width: 450px;">	
	                <div class="card">
                        <div class="card-header">				            
				                <div class="d-flex justify-content-end social_icon">
                                    <%--<h5>Iniciar Sesión</h5>--%>
					                <span>
                                        <button id="imgFacebook" type="button" class="btn btn-primary btn-lg">
                                            <i class="fab fa-facebook-square"></i> 
                                        </button>
					                &nbsp;
                                        <button type="button" class="btn btn-info btn-lg" data-toggle="modal" data-target="#exampleModal">
                                            <i class="fas fa-phone-square"></i> 
                                        </button>
					                </span>
				                </div>
			                </div>
			            <div class="card-body">
                            <h5>Iniciar Sesión</h5>
                            <div class="form-group input-group">
                                <div class="input-group-prepend">
		                <span class="input-group-text"> <i class="fa fa-cog"></i> </span>
		            </div>
                          
                                        <asp:DropDownList ID="DDLTipoUsuario" runat="server" class="form-control">
                                            <asp:ListItem Value="5">Seleccionar</asp:ListItem>
                                            <asp:ListItem Value="1">Alumno ó Aspirante</asp:ListItem>   
                                            <asp:ListItem Value="3">Usuario Dependencia</asp:ListItem>                    
                                            <asp:ListItem Value="4">Referencia Bancaria (recibo de pago de EVENTO)</asp:ListItem>
                                            <asp:ListItem Value="6">Cliente UNACH</asp:ListItem>
                                        </asp:DropDownList>
	                        </div> <!-- form-group end.// -->
                            <div class="form-group input-group">
                                <div id="listUser" class="input-group-prepend">
		                            <span class="input-group-text"> <i class="fa fa-user"></i> </span>
		                         </div>
		                        <div id="listCve" class="input-group-prepend">
		                            <span class="input-group-text"> <i class="fa fa-at"></i> </span>
		                         </div>
                                 <div id="listReferencia" class="input-group-prepend">
		                            <span class="input-group-text"> <i class="fa fa-barcode"></i> </span>
		                         </div>
                                <%--<input name="" class="form-control" placeholder="Full name" type="text">--%>
                                <asp:TextBox ID="txtCve" runat="server" CssClass="form-control" TabIndex="1"></asp:TextBox>
                            </div>
                            <div class="form-group input-group">
    	                        <div id="divPassword" class="input-group-prepend">
		                            <span class="input-group-text"> <i class="fa fa-lock"></i> </span>
		                        </div>
                                        <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control" placeholder="Contraseña" TextMode="Password" TabIndex="2"></asp:TextBox>                    
                    
                            </div> <!-- form-group// -->
                            <div class="form-group text-center">
                                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                <ContentTemplate>
                                    <asp:Panel ID="pnlMsj" runat="server" Visible="False">
                                        <div class="alert alert-danger"> 
                                         <asp:Label ID="lblMensaje" runat="server" Font-Bold="True"></asp:Label>
                                        </div>
                                    </asp:Panel>
                                </ContentTemplate>
                                </asp:UpdatePanel>
                                <br />
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>
                                    <asp:Button ID="btnIngresar" runat="server" OnClick="btnIngresar_Click" Text="Iniciar Sesión" TabIndex="5" CssClass="btn"  style="background-color:#d2af47; color:#fff"/>                                                
                                </ContentTemplate>
                            </asp:UpdatePanel>
                            <asp:UpdateProgress ID="updPrMultiview" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
                                <progresstemplate>
                                    <asp:Image ID="imgMultiview" runat="server" AlternateText="Espere un momento, por favor.." Height="50px" ImageUrl="https://sysweb.unach.mx/resources/imagenes/ajax_loader_gray_512.gif" ToolTip="Espere un momento, por favor.." />
                                </progresstemplate>
                            </asp:UpdateProgress>                                                

                      
                            </div> <!-- form-group// -->      


                            <div id="divMsjGral" class="alert alert-info hide" role="alert" >
                               El acceso a esta página es para imprimir y consultar el comprobante oficial de alguno de los servicios que proporciona la universidad.             
</div>
<div id="divMsjUsuDep" class="alert alert-warning" role="alert">
                  <strong>El acceso al sistema es con la cta. y la contraseña del correo unach,</strong> si no actualizaste tu información dar click en el siguiente enlace.
    <button id="bttnModalActualizar" type="button" class="btn btn-link">Actualizar datos</button>
    <br /><a href="https://ldapauthmaster.unach.mx/pssform_resetaccount.php" target="_blank">¿Olvidó  la contraseña del correo institucional?</a>
    
              </div>                         
                        </div>     
                         <%-- <div class="card-footer">
            <img src="Imagenes/quedateencasaunach.png" />
        </div>--%>
                    </div>
                </article>
        </div>
        <!-- card.// -->

        <div class="piePagina" style="width: 100%">
            <footer class="page-footer font-small pt-4"  style="background-color: #585858; color: #fff">
                <div class="container-fluid text-center text-md-left">
                    <div class="row">
                        <hr class="clearfix w-100 d-md-none pb-3">
                        <div class="col-md-6 mb-md-0 mb-3">
                        <h6 class="text-uppercase mb-4 font-weight-bold">Contacto</h6>
                        <p>
                        <i class="fas fa-home mr-3"></i>2da. Poniente Sur No. 108, Edificio Maciel, 3er. Piso Tuxtla Gutiérrez, Chiapas.</p>
                        <p><i class="fas fa-envelope mr-3"></i>depfin@unach.mx, sysweb@unach.mx</p>
                        <p><i class="fas fa-phone mr-3"></i>(961) 61 7 80 00, extensiones: 5108 Y 5501</p>
                    </div>
              <div class="col-md-6 mb-md-0 mb-3">
                  <div class="text-xl-center">
                      
                      </div>

</div>
                    </div>
                </div>
                <div class="footer-copyright text-center py-3">Universidad Autónoma de Chiapas</div>
            </footer>
        </div>
        <!-- Modal Facebook y Telefonos-->
        <div class="modal fade" id="exampleModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
            <div class="modal-dialog" role="document">
                <div class="modal-content">
                    <div class="modal-header">
                        <h5 class="modal-title" id="exampleModalLabel">Teléfonos</h5>
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                            <span aria-hidden="true">&times;</span>
                        </button>
                    </div>
                    <div class="modal-body">
                        <div class="alert alert-info" role="alert">
                            Para cualquier duda ó aclaración te puedes comunicar con nosotros a los siguientes teléfonos:
                        </div>
                        (961) 61 7 80 00, extensiones: 5503, 5508, 5509 Y 5501
          <br />
                        <h4>FINANZAS: ext. 5108</h4>
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-mdb-color" data-dismiss="modal">Cerrar</button>
                    </div>
                </div>
            </div>
        </div>
        moradonegro&lt;3	
    </form>
</body>
</html>



<script language="javascript" type="text/javascript">
    $(document).ready(function () {
        $("#divPassword").hide();
        $("#txtPassword").hide();
        $("#listCve").hide();
        $("#listUser").hide();
        $("#txtCve").hide();
        $("#listReferencia").hide();
        $("#divMsjGral").show();
        $("#divMsjUsuDep").hide();

        $("#DDLTipoUsuario").change(function () {
            //Todo: write your javascript code here.
            //$("#listCve").show();
            $("#divPassword").hide();
            $("#txtPassword").hide();
            $("#listCve").hide();
            $("#listUser").hide();
            $("#txtCve").hide();
            $("#listReferencia").hide();

            $("#txtCve").show();
            $("#divMsjGral").show();
            $("#divMsjUsuDep").hide();

            if ($("#DDLTipoUsuario").val() == "1" || $("#DDLTipoUsuario").val() == "2" || $("#DDLTipoUsuario").val() == "4" || $("#DDLTipoUsuario").val() == "6") {
                $("#divPassword").hide();
                $("#txtPassword").hide();
                $("#txtCve").focus();

                if ($("#DDLTipoUsuario").val() == "1") {
                    $("#txtCve").attr("placeholder", "Número de Ficha ó Matricula");
                    $("#listUser").show();


                }
                else if ($("#DDLTipoUsuario").val() == "2") {
                    $("#txtCve").attr("placeholder", "RFC");
                    $("#listUser").show();
                }
                else if ($("#DDLTipoUsuario").val() == "4") {
                    $("#listReferencia").show();
                    $("#listCve").hide();
                    $("#txtCve").attr("placeholder", "Referencia");
                    $('.txtCve').css('cursor', 'pointer');
                }
                else {
                    $("#listReferencia").hide();
                    $("#listUser").show();

                    $("#txtCve").attr("placeholder", "Clave SYSWEB");
                }
            }
            else if ($("#DDLTipoUsuario").val() == "5") {
                $("#divPassword").hide();
                $("#txtPassword").hide();
                $("#listCve").hide();
                $("#txtCve").hide();
                $("#listReferencia").hide();
            }
            else {
                $("#divPassword").show();
                $("#txtPassword").show();
                $("#listReferencia").hide();
                $("#listCve").show();
                $("#txtCve").show();
                $("#txtCve").attr("placeholder", "Correo UNACH");
                $("#txtCve").focus();
                $("#divMsjGral").hide();
                $("#divMsjUsuDep").show();


            }
        });
        $("#imgFacebook").click(function () {
            $(location).attr('href', 'https://www.facebook.com/sysweb.dsia/posts/1382513418590378');
        });
        $("#modalTelefonos").click(function () {
            $("#exampleModal").modal("show");
        });
        $("#bttnModalActualizar").click(function () {
            window.location = "https://sysweb.unach.mx/actualiza_correo/frmactualiza_datos.aspx?sistema=14";
        });
        
    });
</script>
