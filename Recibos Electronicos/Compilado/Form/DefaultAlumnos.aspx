<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DefaultAlumnos.aspx.cs" Inherits="Recibos_Electronicos.Form.DefaultAlumnos" %>
<%@ Register TagName="ucRecibos" TagPrefix="usrRecibos" Src="../ControlUsuario/Recibos.ascx"%>
<%@ Register TagName="ucExencion" TagPrefix="usrExencion" Src="../ControlUsuario/Exenciones.ascx"%>
<%@ Register Src="~/ControlUsuario/Exenciones.ascx" TagPrefix="usrExencion" TagName="Exenciones" %>
<%@ Register Src="~/ControlUsuario/Facturas.ascx" TagPrefix="usrFactura" TagName="Facturas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
.accordionCabecera 
{ 
border: 1px solid black; 
background-color: #f5f5f5; 
border-color: #ddd;
font-family: Calibri; 
font-size: 18px; 
font-weight: bold; 
padding: 10px; 
margin-top: 4px; 
cursor: pointer; 
list-style-image: url("../Imagenes/vineta.png");
} 

.accordionContenido 
{ 
font-family: Sans-Serif; 
background-color: #f5f5f5; 
border: 1px solid #ddd; 
font-size: 12px; 
padding: 7px; 
} 
        .auto-style5 {
            width: 119px;
        }
        .auto-style8 {
            width: 99px;
        }
        .auto-style9 {
            width: 532px;
        }
        .auto-style10 {
            text-align: justify;
        }
        .auto-style11 {
            height: 94px;
        }
        </style> 
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <p>
        <table style="width:100%;">
            <tr>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td align="center">
                    <table class="tabla_contenido">
                        <tr>
                            <td align="left">
                                <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                                    <ContentTemplate>
                                        <asp:MultiView ID="MultiView1" runat="server">
                                            <asp:View ID="View1" runat="server">
                                                <table style="width: 100%;">
                                                    <tr>
                                                        <td align="center" colspan="3" style="font-family: 'Trajan Pro'; font-size: x-large">UNIVERSIDAD AUTÓNOMA DE CHIAPAS</td>
                                                    </tr>
                                                    <tr>
                                                        <td align="center" colspan="3" style="font-family: 'Trajan Pro'; font-size: x-large">&nbsp;</td>
                                                    </tr>
                                                    <tr>
                                                        <td class="auto-style5"><span>
                                                            <asp:Image ID="Image12" runat="server" ImageUrl="~/Imagenes/alumnos_unach.png" Height="206px" Width="295px" />
                                                            </span></td>
                                                        <td valign="top">
                                                            <table style="width:100%;">
                                                                <tr>
                                                                    <td class="auto-style10">La Universidad Autónoma de Chiapas se esfuerza por que los servicios a sus estudiantes, trabajadores y público sean cada vez mas eficientes, cómodos y rápidos. Esperamos que esta nueva imagen sea de tu agrado y la encuentres más interactiva.&nbsp;<span style="color: rgb(0, 0, 0); font-family: &quot;PT Sans Narrow&quot;, sans-serif; font-size: 15px; font-style: normal; font-variant-ligatures: normal; font-variant-caps: normal; font-weight: normal; letter-spacing: normal; orphans: 2; text-align: -webkit-left; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-stroke-width: 0px; background-color: rgb(255, 255, 255); text-decoration-style: initial; text-decoration-color: initial; display: inline !important; float: none;">Ahora podrás:</span> </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="auto-style10">
                                                                        <asp:Image ID="Image13" runat="server" ImageUrl="~/Imagenes/vineta.png" />
                                                                        &nbsp;Enviar una copia de la ficha referenciada a tu correo electrónico.</td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="auto-style10">
                                                                        <asp:Image ID="Image14" runat="server" ImageUrl="~/Imagenes/vineta.png" />
                                                                        &nbsp;Los participantes que solicitaron factura podran recibirla en su correo, o descargarla en este portal.</td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="auto-style10">
                                                                        <asp:Image ID="Image15" runat="server" ImageUrl="~/Imagenes/vineta.png" />
                                                                        &nbsp;Ver el status de los que solicitarion Exenciones o Descuentos.</td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <table style="width:100%;">
                                                                            <tr>
                                                                                <td class="auto-style8" valign="top">
                                                                                    <asp:Label ID="lblDependencia" runat="server" Text="Dependencia:"></asp:Label>
                                                                                </td>
                                                                                <td class="auto-style9">
                                                                                    <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                                                                                        <ContentTemplate>
                                                                                            <asp:DropDownList ID="ddlDependencia" runat="server" Width="100%">
                                                                                            </asp:DropDownList>
                                                                                        </ContentTemplate>
                                                                                    </asp:UpdatePanel>
                                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddlDependencia" ErrorMessage="RequiredFieldValidator" InitialValue="00000" ValidationGroup="Buscar">*Elegir una Dependencia</asp:RequiredFieldValidator>
                                                                                </td>
                                                                                <td>
                                                                                    &nbsp;</td>
                                                                            </tr>
                                                                        </table>
                                                                    </td>
                                                                </tr>
                                                            </table>                                                                                                                      
                                                        </td>
                                                        <td>&nbsp;</td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" colspan="2" valign="top">
                                                            <table style="width: 100%;">
                                                                <tr>
                                                                    <td>
                                                                        <table style="width:100%;">
                                                                            <tr>
                                                                                <td align="center" width="33%">
                                                                                    <asp:ImageButton ID="imgBttnRecibos" runat="server" ImageUrl="~/Imagenes/opc1.png" ValidationGroup="Buscar" OnClick="imgBttnRecibos_Click" />
                                                                                </td>
                                                                                <td align="center" width="33%">
                                                                                    <asp:ImageButton ID="imgBttnFacturas" runat="server" ImageUrl="~/Imagenes/opc2.png" ValidationGroup="Buscar" OnClick="imgBttnFacturas_Click" />
                                                                                </td>
                                                                                <td align="center" width="33%">
                                                                                    <asp:ImageButton ID="imgBttnDescuentos" runat="server" ImageUrl="~/Imagenes/opc3.png" ValidationGroup="Buscar" OnClick="imgBttnDescuentos_Click" />
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                        <td>&nbsp;</td>
                                                    </tr>
                                                    <tr>
                                                        <td class="auto-style5">&nbsp;</td>
                                                        <td>&nbsp;</td>
                                                        <td>&nbsp;</td>
                                                    </tr>
                                                </table>
                                            </asp:View>
                                            <asp:View ID="View2" runat="server">
                                                <table style="width:100%;">
                                                    <tr>
                                                        <td valign="top" width="25%">
                                                            <table style="width: 100%;">
                                                                <tr>
                                                                    <td valign="top">
                                                                        <asp:ImageButton ID="imgBttnRecibos0" runat="server" ImageUrl="~/Imagenes/opc1-1.png" OnClick="imgBttnRecibos0_Click" ValidationGroup="Buscar" />
                                                                    </td>
                                                                    <td rowspan="15" valign="top">&nbsp;</td>
                                                                    <td rowspan="15" valign="top">
                                                                        <asp:Image ID="Image16" runat="server" ImageUrl="~/Imagenes/linea.png" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <asp:ImageButton ID="imgBttnFacturas0" runat="server" ImageUrl="~/Imagenes/opc2-1.png" ValidationGroup="Buscar" OnClick="imgBttnFacturas0_Click" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <asp:ImageButton ID="imgBttnDescuentos0" runat="server" ImageUrl="~/Imagenes/opc3-1.png" ValidationGroup="Buscar"/>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <asp:ImageButton ID="imgBttnDescuentos1" runat="server" ImageUrl="~/Imagenes/regresar1.png" OnClick="imgBttnDescuentos1_Click" ValidationGroup="Buscar" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="center">
                                                                        &nbsp;</td>
                                                                </tr>
                                                                <tr>
                                                                    <td>&nbsp;</td>
                                                                </tr>
                                                                <tr>
                                                                    <td>&nbsp;</td>
                                                                </tr>
                                                                <tr>
                                                                    <td>&nbsp;</td>
                                                                </tr>
                                                                <tr>
                                                                    <td>&nbsp;</td>
                                                                </tr>
                                                                <tr>
                                                                    <td>&nbsp;</td>
                                                                </tr>
                                                                <tr>
                                                                    <td>&nbsp;</td>
                                                                </tr>
                                                                <tr>
                                                                    <td>&nbsp;</td>
                                                                </tr>
                                                                <tr>
                                                                    <td>&nbsp;</td>
                                                                </tr>
                                                                <tr>
                                                                    <td>&nbsp;</td>
                                                                </tr>
                                                                <tr>
                                                                    <td>&nbsp;</td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                        <td valign="top" width="75%">
                                                            <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                                                                <ContentTemplate>
                                                                    <asp:MultiView ID="MultiView2" runat="server">
                                                                        <asp:View ID="View5" runat="server">
                                                                            <table style="width: 100%;">
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label ID="lblLeyRecibos" runat="server" Text="Recibos Oficiales &gt;" Font-Bold="True" Font-Size="Medium"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>&nbsp;</td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td class="auto-style11"><span>
                                                                                        <usrRecibos:ucRecibos ID="Recibos" runat="server" OnAceptarClicked="Buscador1_AceptarClicked" />
                                                                                        </span></td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>&nbsp;</td>
                                                                                </tr>
                                                                            </table>
                                                                        </asp:View>
                                                                        <asp:View ID="View4" runat="server">
                                                                            <table style="width: 100%;">
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label ID="lblLeyExenciones" runat="server" Font-Bold="True" Font-Size="Medium" Text="Exenciones/Descuentos &gt;"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td><span>
                                                                                        <usrExencion:Exenciones ID="Exenciones" runat="server"/>
                                                                                        </span></td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>&nbsp;</td>
                                                                                </tr>
                                                                            </table>
                                                                        </asp:View>
                                                                        <asp:View ID="View3" runat="server">
                                                                            <table style="width: 100%;">
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label ID="lblLeyFacturas" runat="server" Font-Bold="True" Font-Size="Medium" Text="Facturas Electrónicas &gt;"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td><span>
                                                                                        <usrFactura:Facturas ID="Facturas" runat="server" OnAceptarClicked="BuscadorFacturas_AceptarClicked" />
                                                                                        </span></td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>&nbsp;</td>
                                                                                </tr>
                                                                            </table>
                                                                        </asp:View>
                                                                    </asp:MultiView>
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            &nbsp;</td>
                                                        <td>&nbsp;</td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            &nbsp;</td>
                                                        <td>&nbsp;</td>
                                                    </tr>
                                                </table>
                                            </asp:View>
                                        </asp:MultiView>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                        </tr>
                        <tr>
                            <td>&nbsp;</td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td>&nbsp;</td>
            </tr>
        </table>
        <br />
    </p>

    <br />
    

</asp:Content>
