<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmModAlumnos.aspx.cs" Inherits="Recibos_Electronicos.Form.frmModAlumnos" %>
<%@ Register TagName="ucRecibos" TagPrefix="usrRecibos" Src="../ControlUsuario/Recibos.ascx"%>
<%@ Register TagName="ucExencion" TagPrefix="usrExencion" Src="../ControlUsuario/Exenciones.ascx"%>
<%@ Register Src="~/ControlUsuario/Exenciones.ascx" TagPrefix="usrExencion" TagName="Exenciones" %>

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
            width: 66%;
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
                                                                                    <asp:ImageButton ID="imgBttnBuscar" runat="server" ImageUrl="https://sysweb.unach.mx/resources/imagenes/buscar.png" onclick="imgBttnBuscar_Click" />
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
                                                                                    <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="~/Imagenes/opc2.png" ValidationGroup="Buscar" />
                                                                                </td>
                                                                                <td align="center" width="33%">
                                                                                    <asp:ImageButton ID="ImageButton3" runat="server" ImageUrl="~/Imagenes/opc3.png" ValidationGroup="Buscar" />
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
                                                        <td align="right">
                                                            &nbsp;</td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right">
                                                            <asp:ImageButton ID="imgBttnRegresar" runat="server" ImageUrl="~/Imagenes/Home.png" OnClick="imgBttnRegresar_Click" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <ajaxToolkit:Accordion ID="Accordion1" runat="server" ContentCssClass="accordionContenido" FadeTransitions="True" FramesPerSecond="50" HeaderCssClass="accordionCabecera" HeaderSelectedCssClass="" Height="961px" RequireOpenedPane="False" TransitionDuration="200" Width="950px">
                                                                <panes>
                                                                    <ajaxToolkit:AccordionPane ID="AccordionPane1" runat="server">
                                                                        <header>
                                                                            <li>Recibo Oficial</li>
                                                                        </header>
                                                                        <content>
                                                                        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                                                            <ContentTemplate>
                                                                                <usrRecibos:ucRecibos ID="Recibos" runat="server" OnAceptarClicked="Buscador1_AceptarClicked" />
                                                                            </ContentTemplate>
                                                                        </asp:UpdatePanel>
                                                                        </content>
                                                                    </ajaxToolkit:AccordionPane>
                                                                    <ajaxToolkit:AccordionPane ID="AccordionPane2" runat="server">
                                                                        <header>
                                                                            <li>Exención</li>
                                                                        </header>
                                                                        <content>
                                                                        Tienes registradas las siguientes exenciones:
                                                                        <br />
                                                                        <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                                                            <ContentTemplate>
                                                                                <usrExencion:Exenciones ID="Exenciones" runat="server" />
                                                                            </ContentTemplate>
                                                                        </asp:UpdatePanel>
                                                                        <br />
                                                                        </content>
                                                                    </ajaxToolkit:AccordionPane>
                                                                    <ajaxToolkit:AccordionPane ID="AccordionPane3" runat="server">
                                                                        <header>
                                                                            <li>Factura Electrónica</li>
                                                                        </header>
                                                                        <content>
                                                                        Tienes generadas las siguientes facturas:
                                                                        <br />
                                                                            <table style="width: 100%;">
                                                                                <tr>
                                                                                    <td>
<asp:GridView ID="grdDatosFactura" runat="server" AllowPaging="True" AutoGenerateColumns="False" CellPadding="3" CssClass="mGrid" DataKeyNames="Id_Fact" EmptyDataText="No existen facturas, para el rango de fecha especificado..." PageSize="15" Width="100%" >
                                                                                            <Columns>
                                                                                                <asp:BoundField DataField="Id_Fact" HeaderText="Id_Fact" SortExpression="ID" />
                                                                                                <asp:BoundField DataField="FACT_FOLIO" HeaderText="Folio" SortExpression="FOLIO">
                                                                                                    <HeaderStyle HorizontalAlign="Left" />
                                                                                                    <ItemStyle HorizontalAlign="Left" />
                                                                                                </asp:BoundField>
                                                                                                <asp:BoundField DataField="FACT_REFERENCIA" HeaderText="Referencia" SortExpression="REFERENCIA">
                                                                                                    <HeaderStyle HorizontalAlign="Left" />
                                                                                                    <ItemStyle HorizontalAlign="Left" />
                                                                                                </asp:BoundField>
                                                                                                <asp:BoundField DataField="FACT_FECHA_FACTURA" DataFormatString="{0:dd/MM/yyyy}" HeaderText="Fecha" SortExpression="FECHA_FACTURA">
                                                                                                    <HeaderStyle HorizontalAlign="Left" />
                                                                                                    <ItemStyle HorizontalAlign="Left" />
                                                                                                </asp:BoundField>
                                                                                                <asp:BoundField DataField="FACT_TOTAL" DataFormatString="{0:c}" HeaderText="Importe" ItemStyle-HorizontalAlign="Right" SortExpression="Importe">
                                                                                                    <HeaderStyle HorizontalAlign="Right" />
                                                                                                    <ItemStyle HorizontalAlign="Right" />
                                                                                                </asp:BoundField>
                                                                                                <asp:BoundField DataField="FACT_CLIENTE" HeaderText="Nombre">
                                                                                                    <HeaderStyle HorizontalAlign="Left" />
                                                                                                    <ItemStyle HorizontalAlign="Left" />
                                                                                                </asp:BoundField>
                                                                                                <asp:BoundField DataField="FACT_NOMBRE" HeaderText="Beneficiario Factura" SortExpression="NOMBRE">
                                                                                                    <HeaderStyle HorizontalAlign="Left" />
                                                                                                    <ItemStyle HorizontalAlign="Left" />
                                                                                                </asp:BoundField>
                                                                                                <asp:BoundField DataField="FACT_DEPENDENCIA" HeaderText="Escuela" SortExpression="DEPENDENCIA">
                                                                                                    <HeaderStyle HorizontalAlign="Left" />
                                                                                                    <ItemStyle HorizontalAlign="Left" />
                                                                                                </asp:BoundField>
                                                                                                <asp:BoundField DataField="FACT_BANCO" HeaderText="Banco" />
                                                                                                <asp:TemplateField>
                                                                                                    <ItemTemplate>                                                                                                        
                                                                                                        <asp:LinkButton ID="LinkButton1" runat="server" PostBackUrl="~/Facturas/5947.PDF" Text="PDF">PDF</asp:LinkButton>
                                                                                                    </ItemTemplate>
                                                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                                                </asp:TemplateField>
                                                                                                <asp:TemplateField>
                                                                                                    <ItemTemplate>
                                                                                                        <span>                                                                                                        
                                                                                                            <asp:LinkButton ID="linkXML" runat="server" PostBackUrl="~/Facturas/5947.XML" Text="XML">XML</asp:LinkButton>
                                                                                                        </span>
                                                                                                    </ItemTemplate>
                                                                                                </asp:TemplateField>
                                                                                            </Columns>
                                                                                            <FooterStyle CssClass="enc" />
                                                                                            <PagerStyle CssClass="enc" HorizontalAlign="Center" />
                                                                                            <SelectedRowStyle CssClass="sel" />
                                                                                            <HeaderStyle CssClass="enc" />
                                                                                            <AlternatingRowStyle CssClass="alt" />
                                                                                        </asp:GridView>                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>&nbsp;</td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>&nbsp;</td>
                                                                                </tr>
                                                                            </table>
                                                                        <%--<asp:Image ID="Image3" runat="server" ImageUrl="~/Imagenes/facturas_alumno.png" />--%>
                                                                        </content>
                                                                    </ajaxToolkit:AccordionPane>
                                                                </panes>
                                                            </ajaxToolkit:Accordion>
                                                        </td>
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
