<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmPagosSIAE.aspx.cs" Inherits="Recibos_Electronicos.Form.frmPagosSIAE" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .auto-style4 {
            width: 195px;
        }
        .auto-style7 {
            width: 770px;
        }
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
   

            <table class="tabla_contenido">                
                <tr>
                    <td>
                        <table style="width:100%;">
                            <tr>
                                <td class="auto-style4">
                                              &nbsp;</td>
                                <td>
                        </td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr valign="top">
                                <td valign="top" class="auto-style4">
                                              &nbsp;</td>
                                <td rowspan="2">
                                           <asp:UpdatePanel ID="updPnlBusca" runat="server">
                                                <ContentTemplate>
                                                    <asp:Panel ID="pnlBuscar" runat="server"  DefaultButton="imgBttnBuscar">
                                                        <table style="width:100%;">
                                                        <tr valign="top">
                                                            <td class="auto-style7">
                                                                <div class="alert alert-warning">
                            Busqueda de referencias generadas en el SIAE.</div></td>
                                                            <td>
                                                                &nbsp;</td>
                                                        </tr>
                                                        <tr valign="top">
                                                            <td class="auto-style7">
                                                                        <asp:TextBox ID="txtReferencia" runat="server" CssClass="box" PlaceHolder="Referencia/Nombre" Visible="true" Width="100%"></asp:TextBox>                                                                  
                                                            </td>
                                                            <td>
                                                                <asp:UpdatePanel ID="UpdatePanel229" runat="server">
                                                                    <ContentTemplate>
                                                                        <asp:ImageButton ID="imgBttnBuscar" runat="server" ImageUrl="https://sysweb.unach.mx/resources/imagenes/buscar.png" OnClick="imgBttnBuscar_Click" />
                                                                    </ContentTemplate>
                                                                </asp:UpdatePanel>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                    </asp:Panel>
                                                    
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                          </td>
                                <td rowspan="2">&nbsp;</td>
                            </tr>
                            <tr valign="top">
                                <td valign="top" class="auto-style4">
                                              <asp:Label ID="lblNivel1" runat="server" Text="Ficha/Nombre/Referencia:"></asp:Label>
                                            </td>
                            </tr>
                        </table>

                    </td>
                </tr>
                <tr>
                    <td class="text-center">
                    <asp:UpdateProgress ID="updPrBusca" runat="server" AssociatedUpdatePanelID="updPnlBusca">
                        <progresstemplate>
                            <asp:Image ID="imgMultiview1" runat="server" AlternateText="Espere un momento, por favor.." Height="50px" ImageUrl="https://sysweb.unach.mx/resources/imagenes/ajax_loader_gray_512.gif" ToolTip="Espere un momento, por favor.." />
                        </progresstemplate>
                    </asp:UpdateProgress>

                    </td>
                </tr>
                <tr>
                    <td class="text-center">
                    <asp:UpdateProgress ID="updPrReferencias" runat="server" AssociatedUpdatePanelID="UpdatePanel228">
                        <progresstemplate>
                            <asp:Image ID="imgMultiview" runat="server" AlternateText="Espere un momento, por favor.." Height="50px" ImageUrl="https://sysweb.unach.mx/resources/imagenes/ajax_loader_gray_512.gif" ToolTip="Espere un momento, por favor.." />
                        </progresstemplate>
                    </asp:UpdateProgress>

                    </td>
                </tr>
                <tr>
                    <td align="center">
                        <asp:UpdatePanel ID="UpdatePanel228" runat="server">
                            <ContentTemplate>
                                <asp:GridView ID="grvReferenciasSIAE" runat="server" AllowPaging="True" AutoGenerateColumns="False" CssClass="mGrid" EmptyDataText="No se encontró el recibo." OnPageIndexChanging="grvReferenciasSIAE_PageIndexChanging" Width="100%">
                            <Columns>
                                                                                    <asp:BoundField DataField="ID_FACT" HeaderText="Id" />
                                                                                    <asp:BoundField DataField="CICLO_ESCOLAR" HeaderText="Ciclo Escolar" />
                                                                                    <asp:BoundField DataField="FACT_DEPENDENCIA" HeaderText="Dependencia" />
                                                                                    <asp:BoundField DataField="FACT_MATRICULA" HeaderText="No. de Ficha/Matricula">
                                                                                        <HeaderStyle HorizontalAlign="Left" />
                                                                                        <ItemStyle HorizontalAlign="Left" />
                                                                                    </asp:BoundField>
                                                                                    <asp:BoundField DataField="FACT_NOMBRE" HeaderText="Nombre">
                                                                                        <HeaderStyle HorizontalAlign="Left" />
                                                                                        <ItemStyle HorizontalAlign="Left" />
                                                                                    </asp:BoundField>
                                                                                    <asp:BoundField DataField="FACT_REFERENCIA" HeaderText="Referencia">
                                                                                        <HeaderStyle HorizontalAlign="Left" />
                                                                                        <ItemStyle HorizontalAlign="Left" />
                                                                                    </asp:BoundField>
                                                                                    <asp:BoundField DataField="FACT_TOTAL" DataFormatString="{0:c}" HeaderText="Importe">
                                                                                        <HeaderStyle HorizontalAlign="Left" />
                                                                                        <ItemStyle HorizontalAlign="Right" />
                                                                                    </asp:BoundField>
                                                                                    <asp:BoundField DataField="FACT_FECHA_FACTURA" HeaderText="Fecha de Pago">
                                                                                        <ItemStyle HorizontalAlign="Center" />
                                                                                    </asp:BoundField>
                                                                                    <asp:TemplateField HeaderText="Pago Aplicado">
                                                                                        <ItemTemplate>
                                                                                            <asp:ImageButton ID="imgStatus" runat="server" ImageUrl='<%# Bind("FACT_RECEPTOR_STATUS") %>' OnClick="imgStatus_Click" />
                                                                                        </ItemTemplate>
                                                                                        <HeaderStyle HorizontalAlign="Center" />
                                                                                        <ItemStyle HorizontalAlign="Center" />
                                                                                    </asp:TemplateField>
                                                                                    <asp:BoundField DataField="FACT_STATUS_NOTAS" />
                                                                                    <asp:BoundField DataField="FACT_STATUS" />
                                                                                    <asp:BoundField DataField="FACT_TIPO" HeaderText="Tipo" />
                                                                                    <asp:BoundField DataField="ID_FICHA_BANCARIA" />
                                                                                </Columns>
                            <FooterStyle CssClass="enc" />
                            <PagerStyle CssClass="enc" HorizontalAlign="Center" />
                            <SelectedRowStyle CssClass="sel" />
                            <HeaderStyle CssClass="enc" />
                            <AlternatingRowStyle CssClass="alt" />
                        </asp:GridView>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                </tr>
                <tr>
                    <td> 
                        <asp:HiddenField ID="hddnAlert" runat="server" />
                        <ajaxToolkit:ModalPopupExtender ID="modalAlert" runat="server" PopupControlID="pnlDatosBanco" TargetControlID="hddnAlert" BackgroundCssClass="modalBackground_Proy">
                        </ajaxToolkit:ModalPopupExtender>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Panel ID="pnl_Alert" runat="server" CssClass="TituloModalPopupMsg" Width="40%">
                                            <asp:Panel ID="pnlMsj" runat="server" Visible="False">
                                                                                    <table width="100%">
                                                                                    <tr>
                                                                                        <td align="left">&nbsp;</td>
                                                                                        <td>
                                                                                            <div class="titulo_pop">
                                                                                                AVISO
                                                                                            </div>
                                                                                            <center>
                                                                                            </center>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td align="left">&nbsp;</td>
                                                                                        <td align="center">¿Esta seguro que desea modificar el pago? </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td align="left">&nbsp;</td>
                                                                                        <td align="center">
                                                                                            <img src="https://sysweb.unach.mx/resources/imagenes/informacion.png"/>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td align="left">&nbsp;</td>
                                                                                        <td>&nbsp;</td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td align="center" colspan="2">
                                                                                            <asp:UpdatePanel ID="UpdatePanel227" runat="server">
                                                                                                <ContentTemplate>
                                                                                                    <asp:Button ID="CancelAlert" runat="server" CssClass="btn btn-blue-grey" OnClick="CancelAlert_Click" Text="NO" />
                                                                                                    &nbsp;<asp:Button ID="btnNueva" runat="server" Cssclass="btn btn-blue-grey" OnClick="btnNueva_Click" Text="SI" />
                                                                                                </ContentTemplate>
                                                                                            </asp:UpdatePanel>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td align="center" colspan="2">&nbsp;</td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td align="center" colspan="2">&nbsp;</td>
                                                                                    </tr>
                                                                                </table>
                                                                                </asp:Panel>                                                                                                                
                                        </asp:Panel>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Panel ID="pnlDatosBanco" runat="server" CssClass="TituloModalPopupMsg">
                            <table>
                                <tr>
                                    <td>
                                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                            <ContentTemplate>
                                                <table style="width:100%;">
                                                    <tr>
                                                        <td class="titulo_pop" colspan="2">DATOS DEL PAGO</td>
                                                        <td>&nbsp;</td>                                     
                                                    </tr>
                                                    <tr>
                                                                                    <td>
                                                                                        <asp:Label ID="lblBanco" runat="server" Text="Banco:"></asp:Label>
                                                                                    </td>                                        
                                                                                    <td>
                                                                                        <asp:DropDownList ID="ddlBanco" runat="server">
                                                                                        </asp:DropDownList>
                                                                                    </td>
                                                                                    <td>&nbsp;</td>
                                                                                </tr>                                    
                                                    <tr>
                                                                                                                            <td>
                                                                                                                                <asp:Label ID="lblFolioBanco" runat="server" Text="Folio Empresa:"></asp:Label>
                                                                                                                            </td>
                                                                                                                            <td>
                                                                                                                                <asp:TextBox ID="txtFolioBanco" runat="server"></asp:TextBox>
                                                                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtFolioBanco" ErrorMessage="*Folio de Banco" ValidationGroup="Multipagos">*Requerido</asp:RequiredFieldValidator>
                                                                                                                            </td>
                                                                                                                            <td>&nbsp;</td>
                                                                                                                        </tr>
                                                    <tr>
                                                                                                                        <td>
                                                                                                                            <asp:Label ID="lblFechaPago" runat="server" Text="Fecha de Pago:"></asp:Label>
                                                                                                                        </td>
                                                                                                                        <td>
                                                                                                                            <asp:TextBox ID="txtFechaPago" runat="server"></asp:TextBox>
                                                                                                                            <ajaxToolkit:CalendarExtender ID="CalendarExtender" runat="server" TargetControlID="txtFechaPago" PopupButtonID="imgCalendario" />
                                                                                                                            <asp:ImageButton ID="imgCalendario" runat="server" ImageUrl="https://sysweb.unach.mx/resources/imagenes/calendario.gif" />
                                                                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtFechaPago" ErrorMessage="*Fecha de Pago" ValidationGroup="Multipagos">*Requerido</asp:RequiredFieldValidator>
                                                                                                                        </td>
                                                                                                                        <td>&nbsp;</td>
                                                                                                                    </tr>
                                                    <tr>
                                                                                                                        <td>
                                                                                                                            <asp:Label ID="lblReferenciaOrig" runat="server" Text="Referencia Generada:"></asp:Label>
                                                                                                                        </td>
                                                                                                                        <td>
                                                                                                                            <asp:TextBox ID="txtReferenciaOrig" runat="server" Enabled="False" Width="200px"></asp:TextBox>
                                                                                                                        </td>
                                                                                                                        <td>&nbsp;</td>
                                                                                                                    </tr>
                                                    <tr>
                                                                                                                        <td>
                                                                                                                            <asp:Label ID="lblPagoAplicado" runat="server" Text="Pago Aplicado:"></asp:Label>
                                                                                                                        </td>
                                                                                                                        <td>
                                                                                                                            <asp:CheckBox ID="chkPagoAplicado" runat="server" Text="Si" />
                                                                                                                            &nbsp;</td>
                                                                                                                        <td>&nbsp;</td>
                                                                                                                    </tr>
                                                    <tr>
                                                                                                                        <td align="center" colspan="2">
                                                                                                                            &nbsp;</td>
                                                                                                                        <td>&nbsp;</td>
                                                                                                                    </tr>
                                                    
                                                    <tr>
                                                                                                                        <td align="center" colspan="2">
                                                                                                                          
                                                                                                                                    <asp:Button ID="bttnSalir" runat="server" CssClass="btn btn-blue-grey" OnClick="bttnSalir_Click" Text="SALIR" />
                                                                                                                                    &nbsp;<asp:Button ID="bttnConfirmaPago" runat="server" Cssclass="btn btn-info" OnClick="bttnConfirmaPago_Click" Text="GUARDAR" ValidationGroup="Guardar" />
                                                                                                                                    &nbsp;<asp:Button ID="bttnGenerarRecibo" runat="server" CssClass="btn btn-primary" OnClick="bttnGenerarRecibo_Click" Text="GUARDAR Y GENERAR RECIBO" ValidationGroup="Multipagos" Visible="False" />
                                                                                                                                
                                                                                                                            &nbsp;&nbsp;</td>
                                                                                                                        <td>&nbsp;</td>
                                                                                                                    </tr>
                                                    <tr>
                                                                                                                        <td>
                                                                                                                            <asp:Label ID="lblReferenciaPagada" runat="server" Text="Referencia Pagada:" Visible="False"></asp:Label>
                                                                                                                        </td>
                                                                                                                        <td>
                                                                                                                            <asp:TextBox ID="txtReferenciaPagada" runat="server" Visible="False" Width="200px"></asp:TextBox>
                                                                                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtReferenciaPagada" ErrorMessage="* La referencia debe ser de 26 digitos" ValidationExpression="[\S\s]{26,26}" ValidationGroup="Guardar"></asp:RegularExpressionValidator>
                                                                                                                        </td>
                                                                                                                        <td>&nbsp;</td>
                                                                                                                    </tr>
                                                </table>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
<asp:UpdateProgress ID="updPrReferencias0" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
                                                                                                                                <progresstemplate>
                                                                                                                                    <asp:Image ID="imgMultiview0" runat="server" AlternateText="Espere un momento, por favor.." Height="50px" ImageUrl="https://sysweb.unach.mx/resources/imagenes/ajax_loader_gray_512.gif" ToolTip="Espere un momento, por favor.." />
                                                                                                                                </progresstemplate>
                                                                                                                            </asp:UpdateProgress>
                                    </td>
                                </tr>
                            </table>
                            
                            
                        </asp:Panel>

                    </td>
                </tr>
            </table>

<script language="javascript" type="text/javascript">      
    function button_click(objTextBox, objBtnID) {
        if (window.event.keyCode == 13) {
            document.getElementById(objBtnID).focus();
        }
    }
</script>
</asp:Content>
