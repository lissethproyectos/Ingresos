<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmActEmailTel.aspx.cs" Inherits="Recibos_Electronicos.Form.frmActEmailTel" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />

    <link type="image/x-icon" href="https://sysweb.unach.mx/resources/imagenes/favicon.ico" rel="icon" />
    <link type="image/x-icon" href="https://sysweb.unach.mx/resources/imagenes/favicon.ico" rel="shortcut icon" />

    <link rel="stylesheet" href="https://sysweb.unach.mx/resources/css/Style.css">

    <title>Sistema de Ingresos | Sysweb</title>


    <script language='javascript' type='text/javascript'>
        var arriba;
        function subir() {
            if (document.body.scrollTop != 0 || document.documentElement.scrollTop != 0) {
                window.scrollBy(0, -5);
                arriba = setTimeout('subir()', 10);
            }
            else clearTimeout(arriba);
        }
    </script>

</head>
<body>

    <form id="form1" runat="server">

        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>

        <header>

            <div class="encabezado">
                <table style="width: 100%">
                    <tr>
                        <td style="width: 33%">
                            <div class="logo_sysweb">
                                <a href="https://sysweb.unach.mx/">
                                    <asp:Image ID="Image4" ImageUrl="https://sysweb.unach.mx/resources/imagenes/logo_sysweb_b.png" runat="server" /></a>
                            </div>
                        </td>
                        <td style="width: 33%" class="centro">
                            <asp:Label ID="Label2" runat="server" Text="Recaudación de Pagos" CssClass="titulo_sistema"></asp:Label><br />
                            <asp:Label ID="Label3" runat="server" Text="Ingresos" CssClass="subtitulo_sistema"></asp:Label>
                        </td>
                        <td style="width: 33%">
                            <div class="cuadro_sistemas">
                            </div>
                            <div class="cuadro_usuario">
                            </div>
                            <div class="cuadro_verde">&nbsp;</div>
                            <div class="cuadro_fiusha">&nbsp;</div>
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


            <div class="lbltitulo_form">Actualizando mis datos: -</div>
            <table class="tabla_contenido">
                <tr>
                    <td>

                        <div class="mensaje_celeste">
                            Hola
                    <asp:Label ID="lblNombre" runat="server" Style="color: #0098CB; font-size: 15px;"></asp:Label>,
&nbsp;<asp:Label ID="lblMensajeAzul" runat="server" Text="Sysweb quiere mantenerlo informado acerca de las actualizaciones que realizamos en nuestros sistemas, para ello debe proporcionar correo electrónico y un teléfono en el cual podamos contactarlo. <br/><br/> Esta información se le solicitará por única vez."></asp:Label>
                            <br />
                        </div>
                        <br />
                        <br />
                        <div class="gris_13px">
                            Para mayor información, comuniquese al teléfono <a>(961) 617 80 00 ext.: 5503, 5501, 5508 y 5509. </a>
                            <br />
                            <br />
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>
                                    <table style="width: 100%;">
                                        <tr>
                                            <td style="width: 20%;">
                                                <asp:Label ID="lblCorreo" runat="server" Text="Correo Electrónico: "></asp:Label></td>
                                            <td>
                                                <asp:TextBox ID="txtCorreo" runat="server" Style="width: 250px;"></asp:TextBox></td>
                                        </tr>
                                        <tr>
                                            <td style="width: 20%;">
                                                <asp:Label ID="lblTeléfono" runat="server" Text="Teléfono: "></asp:Label></td>
                                            <td>
                                                <asp:TextBox ID="txtTeléfono" runat="server" Style="width: 250px;"></asp:TextBox></td>
                                        </tr>
                                    </table>
                                    <br />
                                    <br />


                                    <div class="cuadro_botones">
                                        <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                            <ContentTemplate>
                                                <asp:Button ID="btnAceptar" runat="server" Text="Actualizar datos" Cssclass="btn btn-blue-grey" OnClick="btnAceptar_Click" ValidationGroup="guardo" />
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </div>

                                    <br />
                                    <div style="text-align: center">
                                        <asp:UpdateProgress ID="UpdateProgress1" AssociatedUpdatePanelID="UpdatePanel3" runat="server">
                                            <ProgressTemplate>
                                                <asp:Image ID="Image10" runat="server" Height="50px" ImageUrl="https://sysweb.unach.mx/resources/imagenes/ajax_loader_gray_512.gif" AlternateText="Espere un momento, por favor.." ToolTip="Espere un momento, por favor.." />
                                            </ProgressTemplate>
                                        </asp:UpdateProgress>
                                    </div>
                                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                        <ContentTemplate>
                                            <div class="mensaje">
                                                <asp:Label ID="lblMensaje" runat="server" Text=""></asp:Label>
                                            </div>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>

                                </ContentTemplate>
                            </asp:UpdatePanel>

                        </div>



                    </td>
                </tr>
            </table>


        </div>

        <footer>
            <img src="https://sysweb.unach.mx/resources/imagenes/imgfooter.png" />
        </footer>

    </form>
</body>
</html>
