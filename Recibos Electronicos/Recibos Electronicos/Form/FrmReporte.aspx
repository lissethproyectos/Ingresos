<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FrmReporte.aspx.cs" Inherits="Recibos_Electronicos.Form.FrmReporte" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 141px;
        }
        .auto-style2 {
            width: 1000px;
        }
        .auto-style3 {
            width: 738px;
        }
        .auto-style4 {
            width: 262px;
        }
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">    
    <table class="tabla_contenido">
        <tr>
            <td>
                <table style="width:100%;">
                    <tr>
                        <td class="auto-style1">&nbsp;</td>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="auto-style1">
                            <asp:UpdatePanel ID="UpdatePanel11" runat="server">
                                <ContentTemplate>
                                    <asp:Label ID="lblTipo" runat="server" Text="Tipo de Reporte:"></asp:Label>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </td>
                        <td colspan="2">
                            <asp:UpdatePanel ID="UpdatePanel10" runat="server">
                                <ContentTemplate>
                                    <asp:DropDownList ID="ddlTipo" runat="server">
                                        <asp:ListItem Value="1">Detalle</asp:ListItem>
                                        <asp:ListItem Value="2">General</asp:ListItem>
                                    </asp:DropDownList>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style1">
                                                        <asp:Label ID="lblDependenciaIni" runat="server" Text="Dependencia Inicial:"></asp:Label>
                                                    </td>
                        <td colspan="2">
                                                        <asp:DropDownList ID="ddlDependenciaIni" runat="server" Width="100%">
                                                        </asp:DropDownList>
                                                    </td>
                    </tr>
                    <tr>
                        <td class="auto-style1" valign="top">
                                                        <asp:Label ID="lblDependenciaFin" runat="server" Text="Dependencia Final:"></asp:Label>
                        </td>
                        <td colspan="2">
                            <asp:UpdatePanel ID="updPnlDepFin" runat="server">
                                <ContentTemplate>
                                    <asp:DropDownList ID="ddlDependenciaFin" runat="server" Width="100%" AutoPostBack="True" OnSelectedIndexChanged="ddlDependenciaFin_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                            <asp:UpdateProgress ID="updPrgDepFin" runat="server" AssociatedUpdatePanelID="updPnlDepFin">
                            <ProgressTemplate>
                                <asp:Image ID="imgDepFin" runat="server" Height="50px" ImageUrl="https://sysweb.unach.mx/resources/imagenes/ajax_loader_gray_512.gif" AlternateText="Espere un momento, por favor.." 
                                    ToolTip="Espere un momento, por favor.." />
                            </ProgressTemplate>
                            </asp:UpdateProgress>                
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style1" valign="top">
                            <asp:UpdatePanel ID="UpdatePanel12" runat="server">
                                <ContentTemplate>
                                    <asp:Label ID="lblEventos" runat="server" Text="Eventos:"></asp:Label>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </td>
                        <td colspan="2">
                            <asp:UpdatePanel ID="UpdatePanel13" runat="server">
                                <ContentTemplate>
                                    <asp:DropDownList ID="ddlEventos" runat="server" Width="100%">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="ddlEventos" CssClass="MsjError" ErrorMessage="*Requerido" InitialValue="0" ValidationGroup="reporte"></asp:RequiredFieldValidator>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style1" valign="top">
                            &nbsp;</td>
                        <td colspan="2" valign="top">
                            <asp:UpdatePanel ID="UpdatePanel114" runat="server">
                                <ContentTemplate>
                                    <asp:GridView ID="grvEventos" runat="server">
                                    </asp:GridView>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                            
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style1" valign="top">
                            <asp:UpdatePanel ID="UpdatePanel112" runat="server">
                                <ContentTemplate>
                                    <asp:Label ID="lblFecha_Factura_Ini" runat="server" Text="Fecha Inicial:"></asp:Label>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </td>
                        <td colspan="2" valign="top">
                            <asp:UpdatePanel ID="UpdatePanel113" runat="server">
                                <ContentTemplate>
                                    <asp:Panel ID="pnlFechas" runat="server">
                                        <table style="width: 100%; height: auto;">
                                            <tr>
                                                <td class="auto-style4" valign="top">
                                                    <asp:TextBox ID="txtFecha_Factura_Ini" runat="server" AutoPostBack="True" CssClass="box" onkeyup="javascript:this.value='';" Width="95px"></asp:TextBox>
                                                    <ajaxToolkit:CalendarExtender ID="CalendarExtenderIni" runat="server" PopupButtonID="imgCalendarioIni" TargetControlID="txtFecha_Factura_Ini" />
                                                    <asp:ImageButton ID="imgCalendarioIni" runat="server" ImageUrl="https://sysweb.unach.mx/resources/imagenes/calendario.gif" />
                                                </td>
                                                <td align="right" class="style2" valign="top">
                                                    <asp:Label ID="lblFecha_Factura_Fin" runat="server" Text="Fecha Final:" Width="145px"></asp:Label>
                                                </td>
                                                <td class="auto-style3" valign="top">
                                                    <asp:TextBox ID="txtFecha_Factura_Fin" runat="server" AutoPostBack="True" CssClass="box" onkeyup="javascript:this.value='';" style="margin-left: 0px" Width="95px"></asp:TextBox>
                                                    <ajaxToolkit:CalendarExtender ID="CalendarExtenderFin" runat="server" PopupButtonID="imgCalendarioFin" TargetControlID="txtFecha_Factura_Fin" />
                                                    <asp:ImageButton ID="imgCalendarioFin" runat="server" ImageUrl="https://sysweb.unach.mx/resources/imagenes/calendario.gif" />
                                                </td>
                                                <td align="right">
                                                    <asp:UpdatePanel ID="UpdatePanel33" runat="server">
                                                        <ContentTemplate>
                                                            &nbsp;
                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>
                                                </td>
                                            </tr>
                                        </table>
                                    </asp:Panel>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                            
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style1">
                            <asp:UpdatePanel ID="UpdatePanel16" runat="server">
                                <ContentTemplate>
                                    <asp:Label ID="lblEjercicio" runat="server" Text="Ejercicio:" Visible="False"></asp:Label>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </td>
                        <td colspan="2">
                            <table style="width:70%;">
                                <tr>
                                    <td width="20%">
                                        <asp:UpdatePanel ID="UpdatePanel17" runat="server">
                                            <ContentTemplate>
                                                <asp:DropDownList ID="ddlEjercicio" runat="server" Visible="False">
                                                    <asp:ListItem>2017</asp:ListItem>
                                                    <asp:ListItem>2016</asp:ListItem>
                                                </asp:DropDownList>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </td>
                                    <td width="20%" align="right">
                                        <asp:UpdatePanel ID="UpdatePanel19" runat="server">
                                            <ContentTemplate>
                                                <asp:Label ID="lblMesIni" runat="server" Text="Mes:" Visible="False"></asp:Label>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </td>
                                    <td width="20%">
                                        <asp:UpdatePanel ID="UpdatePanel18" runat="server">
                                            <ContentTemplate>
                                                <asp:DropDownList ID="DDLMesIni" runat="server" OnSelectedIndexChanged="DDLMesIni_SelectedIndexChanged" Visible="False">
                                                    <asp:ListItem Value="01">Enero</asp:ListItem>
                                                    <asp:ListItem Value="02">Febrero</asp:ListItem>
                                                    <asp:ListItem Value="03">Marzo</asp:ListItem>
                                                    <asp:ListItem Value="04">Abril</asp:ListItem>
                                                    <asp:ListItem Value="05">Mayo</asp:ListItem>
                                                    <asp:ListItem Value="06">Junio</asp:ListItem>
                                                    <asp:ListItem Value="07">Julio</asp:ListItem>
                                                    <asp:ListItem Value="08">Agosto</asp:ListItem>
                                                    <asp:ListItem Value="09">Septiembre</asp:ListItem>
                                                    <asp:ListItem Value="10">Octubre</asp:ListItem>
                                                    <asp:ListItem Value="11">Noviembre</asp:ListItem>
                                                    <asp:ListItem Value="12">Diciembre</asp:ListItem>
                                                </asp:DropDownList>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </td>
                                    <td width="20%" align="right">
                                        &nbsp;</td>
                                    <td width="20%">
                                        &nbsp;</td>
                                </tr>
                            </table>
                            
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style1">
                            &nbsp;</td>
                        <td colspan="2">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td class="auto-style1">
                            &nbsp;</td>
                        <td colspan="2">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td class="auto-style1">
                            &nbsp;</td>
                        <td colspan="2">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td colspan="3">
                                        <div class="cuadro_botones" __designer:mapid="80">
                                            
                                                    <table style="width:100%;">
                                                        <tr>
                                                            <td class="auto-style2">
                                                                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                                <ContentTemplate>
                                                                <asp:ImageButton ID="imgBttnReporte" runat="server" ImageUrl="https://sysweb.unach.mx/resources/imagenes/pdf.png" OnClick="imgBttnReporte_Click" />
                                                                &nbsp;&nbsp;
                                                     </ContentTemplate>
                                            </asp:UpdatePanel>
                                                            </td>
                                                            <td>
                                                                 <asp:UpdatePanel ID="UpdatePanel111" runat="server">
                                                <ContentTemplate>
                                                                <asp:ImageButton ID="imgBttnExportar" runat="server" ImageUrl="https://sysweb.unach.mx/resources/imagenes/excel.png" OnClick="imgBttnExportar_Click" ValidationGroup="reporte" />
                                                                 </ContentTemplate>
                                            </asp:UpdatePanel>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                    &nbsp;&nbsp;&nbsp;
                                               
                                            </div>
                                    </td>
                    </tr>
                   
                </table>
            </td>
        </tr>

    </table>

</asp:Content>
