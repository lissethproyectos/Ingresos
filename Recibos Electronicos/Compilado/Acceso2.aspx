<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Acceso2.aspx.cs" Inherits="Recibos_Electronicos.Acceso2" %>

<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="ajaxToolkit" %>



<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<link type="image/x-icon" href="https://sysweb.unach.mx/resources/imagenes/favicon.ico" rel="icon" /> 
<link type="image/x-icon" href="https://sysweb.unach.mx/resources/imagenes/favicon.ico" rel="shortcut icon" /> 
<link rel="stylesheet" href="https://sysweb.unach.mx/resources/css/Style2018.css">
        <link rel="stylesheet" href="bootstrap-4.3.1/css/bootstrap.css" />
    <script type="text/javascript" src="bootstrap-4.3.1/js/bootstrap.js"> </script>    
<script type="text/javascript">
    function changeCursor() {
        var TipoUsuario = document.getElementById("DDLTipoUsuario").value;
        alert(TipoUsuario);
        document.getElementById("txtUsuario").style.display = "inline";
        document.getElementById("txtPassword").style.display = "inline";
        if (TipoUsuario == "5") {
            document.getElementById("txtUsuario").style.display = "inline";
            document.getElementById("txtPassword").style.display = "none";
        }
        else if (TipoUsuario == "1") {
            document.getElementById("txtUsuario").placeholder = "Matricula ó Ficha";
            document.getElementById("txtPassword").style.display = "none";
            //document.getElementById("txtPassword").placeholder = "Matricula ó Ficha";            
        }
        else if (TipoUsuario == "2") {
            document.getElementById("txtUsuario").placeholder = "RFC Fiscal";
        }
        else if (TipoUsuario == "3") {
            document.getElementById("txtUsuario").placeholder = "Usuario Dependencia";
            document.getElementById("txtPassword").placeholder = "Contraseña";
            document.getElementById("txtPassword").setAttribute('type', 'password');
        }
        else if (TipoUsuario == "4") {
            document.getElementById("txtUsuario").style.display = "none";
            document.getElementById("txtPassword").placeholder = "Referencia Bancaria";
        }       
    }
</script>
    <title></title>
    </head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

        <header>            
            <div class="encabezado">
                <table style="width:100%">
                    <tr>
                        <td style="width: 25%">
                                <a href="https://sysweb.unach.mx/">
                                <asp:Image ID="Image1" runat="server" ImageUrl="https://sysweb.unach.mx/resources/imagenes/sysweb2018230.png" />
                                </a>
                        </td>
                        <td class="centro" style="width: 50%">
                            <asp:Label ID="Label2" runat="server" CssClass="titulo_sistema" Text="Recaudación de Pagos"></asp:Label>
                            <br />
                            <asp:Label ID="Label3" runat="server" CssClass="subtitulo_sistema" Text="Ingresos"></asp:Label>
                        &nbsp;
                        </td>
                        <td style="width: 25%">
                         <a href="http://unach.mx/">
                                <asp:Image ID="Image2" ImageUrl="https://sysweb.unach.mx/resources/imagenes/unach.jpg" runat="server" Height="80px" /></a>
                      
                        </td>
                    </tr>
                </table>
            </div>
            <div class="p_menu">
                <div class="c_menu">
                </div>
            </div>
        </header>
        <div class="contenido">
            <div class="cuadro_login centro">
                <asp:Label ID="Label1" runat="server" CssClass="gris_20px" Text="Iniciar Sesión"> </asp:Label>
                <br />
                <br />
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="DDLTipoUsuario" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DDLTipoUsuario_SelectedIndexChanged" Width="270px">
                            <asp:ListItem Value="5">Seleccionar</asp:ListItem>
                            <asp:ListItem Value="1">Alumno ó Aspirante</asp:ListItem>   
                            <asp:ListItem Value="2">Persona Fisica/Moral</asp:ListItem>                 
                            <asp:ListItem Value="3">Usuario Dependencia</asp:ListItem>                    
                            <asp:ListItem Value="4">Referencia Bancaria</asp:ListItem>
                            <asp:ListItem Value="6">Cliente UNACH</asp:ListItem>
                </asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
                
                <br />
                <br />         
                 <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txtMatricula" runat="server" CssClass="textbox2" placeholder="Matricula ó Ficha" Width="95%" Visible="False" TabIndex="1" required></asp:TextBox>
                   </ContentTemplate>
                </asp:UpdatePanel>   
                <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                    <ContentTemplate>    
                        <asp:TextBox ID="txtUsuario" runat="server" CssClass="textbox2" placeholder="Usuario" Width="95%" Visible="False" OnTextChanged="txtUsuario_TextChanged" TabIndex="2" required></asp:TextBox>                                
                    </ContentTemplate>
                </asp:UpdatePanel> 
                <br />
                <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                    <ContentTemplate>     
                        <asp:TextBox ID="txtPassword" runat="server" CssClass="textbox2" placeholder="Contraseña" TextMode="Password" Width="95%" Visible="False" OnTextChanged="txtPassword_TextChanged" TabIndex="3" required></asp:TextBox>              
                    </ContentTemplate>
                </asp:UpdatePanel>   
                <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                    <ContentTemplate>   
                        <asp:TextBox ID="txtReferencia" runat="server" CssClass="textbox2" placeholder="Referencia Bancaria" Width="95%" Visible="False" TabIndex="4" required></asp:TextBox>              
                    </ContentTemplate>
                </asp:UpdatePanel>  
                
                <br />
                <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                    <ContentTemplate>
                        <asp:Panel ID="pnlMsj" runat="server" Visible="False">
                            <div class="mensaje_rojo"> 
                                <asp:UpdatePanel runat="server"><ContentTemplate><asp:Label ID="lblMensaje" runat="server" Font-Bold="True"></asp:Label></ContentTemplate></asp:UpdatePanel>                                          
                            </div>
                        </asp:Panel>
                    </ContentTemplate>
                </asp:UpdatePanel>
                                      

                <br />
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>
                        <asp:Button ID="btnIngresar" runat="server" Cssclass="btn btn-blue-grey" OnClick="btnIngresar_Click" Text="Iniciar Sesión" Width="100%" TabIndex="5" />
                    </ContentTemplate>
                </asp:UpdatePanel>
                <asp:UpdateProgress ID="UpdateProgress1"  AssociatedUpdatePanelID="UpdatePanel2" runat="server">
                        <ProgressTemplate>
                            <asp:Image ID="Image4" runat="server" Height="50px" ImageUrl="https://sysweb.unach.mx/resources/imagenes/ajax_loader_gray_512.gif" AlternateText="Espere un momento, por favor.."  ToolTip="Espere un momento, por favor.." />
                        </ProgressTemplate>
                </asp:UpdateProgress>

                <br />         
                
                <br />   
              <div class="gris_12px">
                                    ¿No tiene una cuenta? <a href="frmNewusu.aspx?1133187993=8">Cree una.</a> <br /><br />

                                  <a href="https://sysweb.unach.mx/administrator/frmresetpassword.aspx">He olvidado mi contraseña</a><br /><br />
                                  <a href="https://sysweb.unach.mx/resources/help.aspx">¿Necesitas ayuda?</a>
                                    <br /><br />

                                </div>
            </div>
        
        </div>


         <asp:HiddenField ID="HiddenField1" runat="server" />
 
                <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtender1" runat="server" 
                    TargetControlID="HiddenField1" PopupControlID="Panel3" BackgroundCssClass="modalBackground_Proy">
       </ajaxToolkit:ModalPopupExtender>

    <%-- Inicia PopUP --%>


     <%-- Inicia PopUP --%>


      <asp:Panel ID="Panel3" runat="server" CssClass="TituloModalPopupMsg"  Width="300px">

                 <asp:ImageButton ID="imgCerrar" ImageUrl="https://sysweb.unach.mx/resources/imagenes/cerrar.png" runat="server" Width="10px" CssClass="cerrar_pop" />
      
             <div class="titulo_pop">
                 AVISO
             </div>
            <center>
                <br />
         <img src="https://sysweb.unach.mx/resources/imagenes/informacion.png"/>
             </center>
           <div class="importante" align="center">*ESTE MENSAJE NO APLICA PARA ALUMNOS/ASPIRANTES</div><br />
         <div class="info_pop gris_12px">
             
            Estimado usuario de Sysweb:<br /><br /> Por seguridad, todos los usuarios deberán de completar cierta información de su cuenta Sysweb, ya que en determinado momento solo los usuarios actualizados podrán acceder a nuestros sistemas. Para modificar los datos de su cuenta, de click en el botón <a>'Actualizar mis datos'</a>.
             <br />
Si ya actualizó los datos de su usuario solo de click en el boton <a>'Continuar'</a>  <br /><br />
             Esta medida es meramente preventiva. Lamentamos el inconveniente.
             <br /><br />

             <label class="f11px">
             Para obtener más información acerca de por qué adoptamos esta medida de precaución, no dudes en comunicarte con nosotros:<br /><br /> Teléfono:<a>(961) 617 80 00 ext.: 1302, 5519, 5520 y 5087</a>
           </label>  <br /><br />
Gracias.<br />
El equipo de Sysweb
              <br /><br />
         </div>

             <div class="esp_botones">
                          <asp:Button ID="btnAceptar" runat="server" Text="Actualizar mis datos" Cssclass="btn btn-blue-grey"  PostBackUrl="http://www.sysweb.unach.mx/administrator/"/> &nbsp;  
                 <asp:Button ID="btnCancelar" runat="server" Text="Continuar" CssClass="btn btn-blue-grey" /> 
             </div>

                  
     </asp:Panel>

        <footer>
            <img src="https://sysweb.unach.mx/resources/imagenes/imgfooter2018.png" />
        </footer>
    </form>
</body>
</html>
