<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FrmRecibos.aspx.cs" Inherits="Recibos_Electronicos.Form.FrmRecibos" %>
<%@ Register assembly="CapaNegocio" namespace="CapaNegocio" tagprefix="customControl" %>

<%@ Register src="../EnviarCorreo.ascx" tagname="uccorreo" tagprefix="usr" %>

<%--<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>--%>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script type="text/javascript" src="../Js/jsGeneral.js"> </script>
    <style type="text/css">
      
        .style4
        {
            width: 5%;
        }
        .style5
        {
            width: 20%;
        }
        .style6
        {
            width: 70%;
        }
        .style7
        {
        }
        .style8
        {
            width: 24%;
        }
        .style9
        {
            width: 11%;
        }
        .style11
        {
        }
        .style12
        {
            height: 21px;
            width: 100%;
        }
        .style13
        {
            width: 78px;
        }
        .style14
        {
            width: 189px;
        }
        .style15
        {
            width: 202px;
        }
        .auto-style2 {
            width: 91%;
        }
        .auto-style3 {
            width: 57%;
        }
        .auto-style4 {
            width: 417px;
        }
        .auto-style5 {
            width: 93px;
        }
        .auto-style6 {
            width: 332px;
        }
        .auto-style7 {
            height: 216px;
        }
        .auto-style8 {
            width: 176px;
        }
        .auto-style9 {
            width: 51%;
        }
        .auto-style10 {
            border-radius: 21px 21px 21px 21px;
            -moz-border-radius: 21px 21px 21px 21px;
            -webkit-border-radius: 21px 21px 21px 21px;
            border: 2px solid #c9bfc9;
            font-size: 11px;
            padding: 10px 10px 10px 20px;
            height: 202px;
        }
        .auto-style26 {
            width: 765px;
        }
        .auto-style29 {
            margin-left: 40px;
        }
        .auto-style30 {
            width: 74%;
        }
        .auto-style32 {
            width: 286px;
        }
        .auto-style33 {
            width: 145px;
            text-align: left;
        }
        .auto-style34 {
            width: 773px;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">    
    <table class="tabla_contenido">
        <%--<tr>
            <td align="center">
                                       </td>
        </tr>--%>
        <tr>
            <td align="center">
                <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                    <ContentTemplate>
                         <asp:Panel ID="pnlBuscar" runat="server" DefaultButton="imgbtnBuscar">
                                        <table style="width:100%;">
                                           <%-- <tr>
                                                <td class="text-left" colspan="3">
                                                    <asp:UpdateProgress ID="UpdateProgress25" runat="server" AssociatedUpdatePanelID="UpdBuscar">
                                                        <ProgressTemplate>
                                                            <asp:Image ID="Image91" runat="server" AlternateText="Espere un momento, por favor.." Height="50px" ImageUrl="https://sysweb.unach.mx/resources/imagenes/ajax_loader_gray_512.gif" ToolTip="Espere un momento, por favor.." />
                                                        </ProgressTemplate>
                                                    </asp:UpdateProgress>
                                                </td>
                                            </tr>--%>
                                            <tr>
                                                <td class="auto-style33">
                                                    <asp:Label ID="lblBuscar" runat="server" Text="Buscar:"></asp:Label>
                                                </td>
                                                <td class="auto-style34">
                                                    <asp:TextBox ID="txtFolioBuscar" runat="server" Placeholder="Recibo/Referencia/Nombre Completo" Width="100%"></asp:TextBox>
                                                </td>
                                                <td>
                                                    <asp:UpdatePanel ID="UpdBuscar" runat="server">
                                                        <ContentTemplate>
                                                            <asp:ImageButton ID="imgbtnBuscar" runat="server" ImageUrl="https://sysweb.unach.mx/resources/imagenes/buscar.png" OnClick="imgbtnBuscar_Click" />
                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>
                                                </td>
                                            </tr>
                                        </table>
                                             </asp:Panel>

                        <asp:Panel ID="pnlRecibos" runat="server">
                            <table style="width: 100%;">
                                <tr>
                                    <td align="center">
                                         
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center">&nbsp;</td>
                                </tr>
                                <tr>
                                    <td align="center">
                                        <asp:GridView ID="grvFacturas" runat="server" AllowPaging="True" 
                                            AutoGenerateColumns="False" 
                                            onselectedindexchanging="grvFacturas_SelectedIndexChanging" 
                                            onpageindexchanging="grvFacturas_PageIndexChanging" 
                                            onselectedindexchanged="grvFacturas_SelectedIndexChanged" 
                                            EmptyDataText="No se encontró el recibo." CssClass="mGrid" Width="100%">                                            
                                            <Columns>
                                                <asp:BoundField DataField="ID_FACT" HeaderText="Id" />
                                                <asp:BoundField DataField="FACT_MATRICULA" HeaderText="Matricula" >
                                                    <HeaderStyle HorizontalAlign="Left" />
                                                    <ItemStyle HorizontalAlign="Left" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="FACT_NOMBRE" HeaderText="Nombre" >
                                                    <HeaderStyle HorizontalAlign="Left" />
                                                    <ItemStyle HorizontalAlign="Left" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="FACT_REFERENCIA" HeaderText="Referencia" >
                                                    <HeaderStyle HorizontalAlign="Left" />
                                                    <ItemStyle HorizontalAlign="Left" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="FACT_FOLIO" HeaderText="Recibo" >
                                                    <HeaderStyle HorizontalAlign="Left" />
                                                    <ItemStyle HorizontalAlign="Left" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="FACT_FECHA_FACTURA" HeaderText="Fecha" DataFormatString="{0:d}" >
                                                    <HeaderStyle HorizontalAlign="Left" />
                                                    <ItemStyle HorizontalAlign="Left" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="Status_Carga" HeaderText="Status" >
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:BoundField>
                                                <asp:CommandField SelectText="Editar" ShowSelectButton="True" ButtonType="Image" SelectImageUrl="~/Imagenes/edit.png" HeaderText="Editar Recibo" >
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:CommandField>
                                                <asp:TemplateField HeaderText="Ver Recibo">
                                                    <ItemTemplate>
                                                        <asp:ImageButton ID="imgBttnRecibo" runat="server" ImageUrl="~/Imagenes/recibo2.png" OnClick="imgBttnRecibo_Click" />
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Enviar Recibo">
                                                    <ItemTemplate>
                                                        <asp:ImageButton ID="imgBttnCorreo" runat="server" ImageUrl="~/Imagenes/correo2.png" OnClick="imgBttnCorreo_Click" />
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Historico">
                                                    <ItemTemplate>
                                                        <asp:ImageButton ID="imgBttnHistorico" runat="server" ImageUrl="~/Imagenes/historico.png" OnClick="imgBttnHistorico_Click" />
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:TemplateField>
                                            </Columns>
                                           <FooterStyle CssClass="enc" />
                                            <PagerStyle CssClass="enc" HorizontalAlign="Center" />
                                            <SelectedRowStyle CssClass="sel" />
                                            <HeaderStyle CssClass="enc" />
                                            <AlternatingRowStyle CssClass="alt" />
                                        </asp:GridView>
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
                    </ContentTemplate>
                </asp:UpdatePanel>
<asp:UpdateProgress ID="UpdateProgress2" AssociatedUpdatePanelID="UpdatePanel4" runat="server">
                    <ProgressTemplate>
                        <asp:Image ID="Image88" runat="server" Height="50px" ImageUrl="https://sysweb.unach.mx/resources/imagenes/ajax_loader_gray_512.gif" ToolTip="Espere un momento, por favor.." AlternateText="Espere un momento, por favor.." />
                    </ProgressTemplate>
                </asp:UpdateProgress>
            </td>
        </tr>
        <tr>
            <td>
                <usr:uccorreo ID="PnlCorreo" runat="server" />
                
            </td>
        </tr>
        <tr>
            <td>
                <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                    <ContentTemplate>
                        <asp:Panel ID="pnlModificacion_Recibo" runat="server" Visible="False">
                            <table style="width: 100%;">
                                <tr>
                                    <td colspan="2" style="width: 100%" width="50%">
                                        <table style="width: 100%;">
                                            <tr>
                                                <td align="right" valign="top" width="15%">
                                                    <asp:Image ID="Image1" runat="server" ImageUrl="~/Imagenes/escudounach.png" Height="108px" Width="124px" />
                                                </td>
                                                <td valign="top" class="auto-style9">
                                                    <table class="auto-style2">
                                                        <tr>
                                                            <td align="center" class="auto-style4">
                                                                <asp:Label ID="Label14" runat="server" Font-Bold="True" Font-Size="Larger" 
                                                                    Text="UNIVERSIDAD AUTÓNOMA DE CHIAPAS" Font-Names="Trajan Pro"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="center" class="auto-style4">
                                                                <asp:Label ID="Label15" runat="server" 
                                                                    Text="BLVD. BELISARIO DOMINGUEZ KM. 1081" Font-Names="Trajan Pro"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="center" class="auto-style4">
                                                                <asp:Label ID="Label16" runat="server" Text="TERÁN SIN NÚMERO, C.P. 29050" Font-Names="Trajan Pro"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="center" class="auto-style4">
                                                                <asp:Label ID="Label17" runat="server" Text="TUXTLA GUTIÉRREZ, CHIAPAS, MÉXICO" Font-Names="Trajan Pro"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="center" class="auto-style4">
                                                                <asp:Label ID="Label18" runat="server" Text="RFC: UAC750417LE8" Font-Names="Trajan Pro"></asp:Label>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td width="30%">
                                                    <div class="auto-style10">
                                                    <table border="0px" cellpadding="0px" cellspacing="0px" style="width: 100%;">
                                                        <tr>
                                                            <td align="center" class="style1" 
                                                                
                                                                style="background-position: right;" 
                                                                colspan="2">
                                                                <asp:Label ID="Label41" runat="server" Font-Underline="True" 
                                                                    Text="Recibo UNACH"></asp:Label>
                                                            </td>
                                                            <td 
                                                                width="10%">
                                                                &nbsp;</td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" class="auto-style5">
                                                                <asp:Label ID="lblFolio" runat="server" Font-Size="XX-Small" 
                                                                    Text="Serie-Folio:"></asp:Label>
                                                            </td>
                                                            <td class="auto-style3">
                                                                <asp:TextBox ID="txtFolio" runat="server" Width="85%" 
                                                                    Enabled="False"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" class="auto-style5">
                                                                <asp:Label ID="Label20" runat="server" Font-Size="XX-Small" Text="Fecha:"></asp:Label>
                                                            </td>
                                                            <td class="auto-style3">
                                                                <asp:TextBox ID="txtFecha_Cfd1" runat="server" AutoPostBack="True" CssClass="box" onkeyup="javascript:this.value='';" Width="95px"></asp:TextBox>
                                                                <ajaxToolkit:CalendarExtender ID="CalendarFecha_Cfd1" runat="server" TargetControlID="txtFecha_Cfd1" PopupButtonID="imgCalendarioCfd1" />
                                                                <asp:ImageButton ID="imgCalendarioCfd1" runat="server" ImageUrl="https://sysweb.unach.mx/resources/imagenes/calendario.gif" />                                                        

                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" class="auto-style5">
                                                                <asp:Label ID="lblFecha_Dispersion" runat="server" Font-Size="XX-Small" Text="Fecha de Dispersión:"></asp:Label>
                                                            </td>
                                                            <td class="auto-style3">
                                                                <asp:TextBox ID="txtFecha_Dispersion" runat="server" AutoPostBack="True" CssClass="box" onkeyup="javascript:this.value='';" Width="95px"></asp:TextBox>
                                                                <ajaxToolkit:CalendarExtender ID="CalendarFecha_Dispersion" runat="server" TargetControlID="txtFecha_Dispersion" PopupButtonID="imgCalendarioDisp" />
                                                                <asp:ImageButton ID="imgCalendarioDisp" runat="server" ImageUrl="https://sysweb.unach.mx/resources/imagenes/calendario.gif" />                                                        

                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" class="auto-style5">
                                                                <asp:Label ID="lblNo_Certificado" runat="server" Font-Size="XX-Small" 
                                                                    Text="No. Certificado Diggital"></asp:Label>
                                                            </td>
                                                            <td class="auto-style3">
                                                                <asp:TextBox ID="txtNo_Certificado" runat="server" 
                                                                    Width="85%" Enabled="False"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" class="auto-style5">
                                                                <asp:Label ID="Label22" runat="server" Font-Size="XX-Small" 
                                                                    Text="Año y Número de Aprobación"></asp:Label>
                                                            </td>
                                                            <td class="auto-style3">
                                                                <asp:TextBox ID="txtAnio_Aprobacion" runat="server" Enabled="False" 
                                                                    Width="85%"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                        </div>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center" valign="top" width="50%">
                                        <div  class="borde_gris">
                                        <table border="0px" cellpadding="0px" cellspacing="0px" style="width: 100%;">
                                            <tr>
                                                <td align="left">
                                                    <asp:Label ID="lblReceptor_Nombre" runat="server" Text="A FAVOR DE:"></asp:Label>
                                                </td>
                                                <td align="left">
                                                    <asp:TextBox ID="txtReceptor_Nombre" runat="server" Width="70%" 
                                                        Font-Size="Small"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" 
                                                        ControlToValidate="txtReceptor_Nombre" CssClass="MsjError" 
                                                        ErrorMessage="*Requerido" ValidationGroup="guardar"></asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">
                                                    <asp:Label ID="lblReceptor_Rfc" runat="server" Text="RFC:"></asp:Label>
                                                </td>
                                                <td align="left">
                                                    <asp:TextBox ID="txtReceptor_Rfc" runat="server" Width="50%"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">
                                                    <asp:Label ID="lblReceptor_Domicilio" runat="server" Text="DIRECCIÓN:"></asp:Label>
                                                </td>
                                                <td align="left">
                                                    <asp:TextBox ID="txtReceptor_Domicilio" runat="server" Width="70%"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">
                                                    <asp:Label ID="lblReceptor_Colonia" runat="server" Text="COLONIA:"></asp:Label>
                                                </td>
                                                <td align="left">
                                                    <asp:TextBox ID="txtReceptor_Colonia" runat="server" Width="70%"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">
                                                    <asp:Label ID="lblReceptor_Pais" runat="server" Text="LUGAR:"></asp:Label>
                                                </td>
                                                <td align="left">
                                                    <asp:TextBox ID="txtReceptor_Pais" runat="server" Width="70%"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">
                                                    <asp:Label ID="lblMatricula" runat="server" Text="MATRICULA:"></asp:Label>
                                                </td>
                                                <td align="left">
                                                    <asp:TextBox ID="txtMatricula" runat="server" Width="50%"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator17" runat="server" 
                                                        ControlToValidate="txtMatricula" CssClass="MsjError" ErrorMessage="*Requerido" 
                                                        ValidationGroup="guardar"></asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left" class="style5">
                                                    <asp:Label ID="lblCarrera" runat="server" Text="CARRERA:"></asp:Label>
                                                </td>
                                                <td align="left" class="style6">
                                                    <asp:TextBox ID="txtCarrera" runat="server" Width="70%"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator25" runat="server" 
                                                        ControlToValidate="txtCarrera" CssClass="MsjError" ErrorMessage="*Requerido" 
                                                        ValidationGroup="guardar"></asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                        </table>
                                            </div>
                                    </td>
                                    <td align="center" valign="top" width="50%" class="auto-style7">
                                        <div  class="borde_gris">
                                        <table border="0px" cellpadding="0px" cellspacing="0px" style="width: 100%;">
                                            <tr>
                                                <td align="left" class="style5">
                                                    <asp:Label ID="lblDesc_Dependencia" runat="server" Text="DES:"></asp:Label>
                                                </td>
                                                <td class="style6" width="68%" align="left">
                                                    <asp:TextBox ID="txtDesc_Dependencia" runat="server" Width="80%"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left" class="style5">
                                                    <asp:Label ID="lblExpedido_Domicilio" runat="server" Text="DIRECCIÓN:"></asp:Label>
                                                </td>
                                                <td class="style6" width="68%" align="left">
                                                    <asp:TextBox ID="txtExpedido_Domicilio" runat="server" Width="80%"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left" class="style5">
                                                    <asp:Label ID="lblExpedido_Colonia" runat="server" Text="COLONIA:"></asp:Label>
                                                </td>
                                                <td class="style6" width="68%" align="left">
                                                    <asp:TextBox ID="txtExpedido_Colonia" runat="server" Width="80%"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left" class="style5">
                                                    <asp:Label ID="lblExpedido_Pais" runat="server" Text="LUGAR:"></asp:Label>
                                                </td>
                                                <td class="style6" width="68%" align="left">
                                                    <asp:TextBox ID="txtExpedido_Pais" runat="server" Width="80%"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left" class="style5">
                                                    <asp:Label ID="lblFecha_Cfd" runat="server" Text="FECHA:"></asp:Label>
                                                </td>
                                                <td align="left" class="style6" width="68%">
                                                    <asp:TextBox ID="txtFecha_Cfd2" runat="server" 
                                                        CssClass="box" Width="95px" Enabled="False"></asp:TextBox>
                                                    &nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td align="left" class="style5">
                                                    &nbsp;</td>
                                                <td class="style6" width="68%">
                                                    &nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td align="left" class="style5">
                                                    &nbsp;</td>
                                                <td class="style6" width="68%">
                                                    &nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td align="left" class="style5">
                                                    &nbsp;</td>
                                                <td class="style6" 
                                                    width="68%">
                                                    &nbsp;</td>
                                            </tr>
                                        </table>
                                            </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="style12" colspan="2" align="center">
                                     <table width="100%">
                                            <tr>
                                                <td align="left" class="auto-style8" valign="top">
                                                    &nbsp;</td>
                                                <td align="left" class="auto-style6" valign="top">
                                                    &nbsp;</td>
                                                <td align="right" class="style15" valign="top">
                                                    &nbsp;</td>
                                                <td align="left" valign="top">
                                                    &nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td align="left" class="auto-style8" valign="top">
                                                    <asp:Label ID="lblStatus" runat="server" Text="Status:"></asp:Label>
                                                </td>
                                                <td align="left" class="auto-style6" valign="top">
                                                    <asp:UpdatePanel ID="UpdatePanel34" runat="server">
                                                        <ContentTemplate>
                                                            <asp:RadioButtonList ID="rdoListStatus" runat="server" AutoPostBack="True" OnSelectedIndexChanged="rdoListStatus_SelectedIndexChanged" RepeatDirection="Horizontal">
                                                                <asp:ListItem Value="A">Activo</asp:ListItem>
                                                                <asp:ListItem Value="C">Cancelado</asp:ListItem>
                                                                <asp:ListItem Value="R">Reembolsado</asp:ListItem>
                                                            </asp:RadioButtonList>
                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>
                                                </td>
                                                <td align="right" class="style15" valign="top">&nbsp;</td>
                                                <td align="left" valign="top">&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td align="left" class="auto-style8" valign="top">
                                                    <asp:Label ID="lblStatus_Notas" runat="server" Text="Observaciones:"></asp:Label>
                                                </td>
                                                <td align="left" colspan="3" valign="top">
                                                    <asp:TextBox ID="txtStatus_Notas" runat="server" Height="71px" TextMode="MultiLine" Width="100%"></asp:TextBox>
                                                </td>
                                            </tr>
                                        </table>
                                        </td>
                                </tr>
                                <tr>
                                    <td align="center" colspan="2" style="width: 100%" width="50%">
                                        
                                                    <table style="width: 100%;">
                                                        <tr>
                                                            <td align="right" colspan="5">
                                                                <asp:UpdatePanel ID="UpdatePanel13" runat="server">
                                                                    <ContentTemplate>
                                                                        <asp:HiddenField ID="hddnModal" runat="server" />
                                                                        <table style="width: 100%;">
                                                                            <tr>
                                                                                <td class="auto-style26">
                                                                                    <asp:Panel ID="pnlMsjReg" CssClass="mensaje_rojo"  runat="server">
                                                                                        <asp:Label ID="lblMsj2" runat="server" Width="100%"></asp:Label>
                                                                                    </asp:Panel>
                                                                                </td>
                                                                                <td>
                                                                                    &nbsp;<asp:ImageButton ID="imgBttnAgregarConcepto0" runat="server" ImageUrl="https://sysweb.unach.mx/resources/imagenes/nuevo.png" onclick="imgBttnAgregarConcepto0_Click" />
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                        <ajaxToolkit:ModalPopupExtender ID="modal" runat="server"                                                                             
                                                                            PopupControlID="pnlAgregaConceptos" 
                                                                            TargetControlID="hddnModal" BackgroundCssClass="modalBackground_Proy" CancelControlID="btnCancelar_Concp">
                                                                        </ajaxToolkit:ModalPopupExtender>
                                                                    </ContentTemplate>
                                                                </asp:UpdatePanel>
                                                                        
                                                                        
                                                                        
                                                                        
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" colspan="5">
                                                                <asp:GridView ID="grvFacturas_Detalle" runat="server" AutoGenerateColumns="False" 
                                                                    Width="100%" onrowdeleting="grvFacturas_Detalle_RowDeleting" CssClass="mGrid">                                                                    
                                                                    <Columns>
                                                                        <asp:BoundField DataField="IdDetFact" HeaderText="ID">
                                                                        <ItemStyle Width="10%" />
                                                                        </asp:BoundField>
                                                                        <asp:BoundField DataField="ClaveConcepto" HeaderText="CLAVE" >
                                                                        <HeaderStyle HorizontalAlign="Left" />
                                                                        <ItemStyle HorizontalAlign="Left" />
                                                                        </asp:BoundField>
                                                                        <asp:BoundField DataField="cantidad" HeaderText="CANTIDAD" >
                                                                        <HeaderStyle HorizontalAlign="Center" />
                                                                        <ItemStyle HorizontalAlign="Center" Width="15%" />
                                                                        </asp:BoundField>
                                                                        <asp:BoundField DataField="DescConcepto" HeaderText="CONCEPTO" >
                                                                        <HeaderStyle HorizontalAlign="Left" />
                                                                        <ItemStyle HorizontalAlign="Left" />
                                                                        </asp:BoundField>
                                                                        <asp:BoundField DataField="ValorUnitario" HeaderText="P. UNITARIO" >
                                                                        <HeaderStyle HorizontalAlign="Right" />
                                                                        <ItemStyle HorizontalAlign="Right" />
                                                                        </asp:BoundField>
                                                                        <asp:BoundField DataField="importe" HeaderText="IMPORTE" >
                                                                        <HeaderStyle HorizontalAlign="Right" />
                                                                        <ItemStyle HorizontalAlign="Right" />
                                                                        </asp:BoundField>
                                                                        <asp:CommandField ShowDeleteButton="True">
                                                                        <ItemStyle HorizontalAlign="Center" />
                                                                        </asp:CommandField>
                                                                    </Columns>              
                                                                    <FooterStyle CssClass="enc" />
                                                                    <PagerStyle CssClass="enc" HorizontalAlign="Center" />
                                                                    <SelectedRowStyle CssClass="sel" />
                                                                    <HeaderStyle CssClass="enc" />
                                                                    <AlternatingRowStyle CssClass="alt" />                                                      
                                                                </asp:GridView>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" width="20%">
                                                                &nbsp;</td>
                                                            <td width="20%">
                                                                &nbsp;</td>
                                                            <td width="20%">
                                                                <br />
                                                            </td>
                                                            <td width="20%">
                                                                &nbsp;</td>
                                                            <td width="20%">
                                                                &nbsp;</td>
                                                        </tr>
                                                    </table>
                                                
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center" colspan="2" style="width: 100%" width="50%">
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td align="center" colspan="2" style="width: 100%" width="50%">
                                        
                                                    <table style="width: 100%;">
                                                        <tr>
                                                            <td align="left" width="75%">
                                                                <table style="border-width: thin; border-style: solid; width: 95%;" 
                                                                    width="100%" class="mensaje_naranja">
                                                                    <tr>
                                                                        <td>
                                                                            <asp:Label ID="lblTotal_Letras" runat="server"></asp:Label>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                            <td align="left" rowspan="3" valign="top" width="25%">
                                                                <table border="0px" cellpadding="0px" cellspacing="0px" style="width: 100%;">
                                                                    <tr>
                                                                        <td align="right" class="style1" 
                                                                            style="background-position: right; background-image: url('../Imagenes/esq-sup-izq.png'); background-repeat: no-repeat;" 
                                                                            width="15%">
                                                                            &nbsp;</td>
                                                                        <td align="left" class="style1" 
                                                                            style="background-position: right; background-image: url('../Imagenes/linea-sup.png'); background-repeat: repeat-x;" 
                                                                            width="30%">
                                                                            &nbsp;</td>
                                                                        <td style="background-position: right; background-image: url('../Imagenes/linea-sup.png'); background-repeat: repeat-x;" 
                                                                            width="40%">
                                                                            &nbsp;</td>
                                                                        <td style="background-position: left; background-image: url('../Imagenes/esq-sup-der.png'); background-repeat: no-repeat;" 
                                                                            width="15%">
                                                                            &nbsp;</td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="left" class="style2" rowspan="3" 
                                                                            style="background-position: right; background-image: url('../Imagenes/linea-izq.png'); background-repeat: repeat-y;" 
                                                                            width="15%">
                                                                        </td>
                                                                        <td align="left" class="style1" width="30%">
                                                                            <asp:Label ID="lblSubtotal" runat="server" Text="SubTotal"></asp:Label>
                                                                        </td>
                                                                        <td width="40%">
                                                                            <asp:TextBox ID="txtSubtotal" runat="server" Width="50px"></asp:TextBox>
                                                                        </td>
                                                                        <td class="style3" rowspan="3" 
                                                                            style="background-position: left; background-image: url('../Imagenes/linea-der.png'); background-repeat: repeat-y;" 
                                                                            width="15%">
                                                                            <br />
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="left" class="style1" width="30%">
                                                                            <asp:Label ID="lblImpuesto_Tasa" runat="server" Text="IVA 0.00"></asp:Label>
                                                                        </td>
                                                                        <td width="40%">
                                                                            <asp:TextBox ID="txtImpuesto_Tasa" runat="server" Width="50px"></asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="left" class="style1" width="30%">
                                                                            <asp:Label ID="lblTotal" runat="server" Text="Total"></asp:Label>
                                                                        </td>
                                                                        <td width="40%">
                                                                            <asp:TextBox ID="txtTotal" runat="server" Width="50px"></asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="left" class="style1" 
                                                                            style="background-position: right; background-image: url('../Imagenes/esq-inf-izq.png'); background-repeat: no-repeat;" 
                                                                            width="15%">
                                                                            &nbsp;</td>
                                                                        <td align="left" class="style1" 
                                                                            style="background-position: right; background-image: url('../Imagenes/linea-inf.png'); background-repeat: repeat-x;" 
                                                                            width="30%">
                                                                            &nbsp;</td>
                                                                        <td style="background-position: right; background-image: url('../Imagenes/linea-inf.png'); background-repeat: repeat-x;" 
                                                                            width="40%">
                                                                            &nbsp;</td>
                                                                        <td style="background-position: left; background-image: url('../Imagenes/esq-inf-der.png'); background-repeat: no-repeat;" 
                                                                            width="15%">
                                                                            &nbsp;</td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" width="75%">
                                                                &nbsp;</td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                               
                                                                   
                                                                             <fieldset>
                                                                <legend>OBSERVACIONES</legend>
                                                                            <table style="width: 100%;">                                                                                
                                                                                <tr>
                                                                                    <td align="left">
                                                                                        <asp:TextBox ID="txtNotas" runat="server" Height="100px" Width="100%" 
                                                                                            TextMode="MultiLine"></asp:TextBox>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                                 </fieldset>
                                                                      
                                                                
                                                            </td>
                                                        </tr>
                                                    </table>
                                                
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center" colspan="2" style="width: 100%" width="50%">
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td colspan="2" style="width: 100%" width="50%">
                                        
                                                    <fieldset>
                                                                                                                <legend>CADENA ORIGINAL</legend>
                                                    <table style="width: 100%;">                                                       
                                                        <tr>
                                                            <td align="left">
                                                                <asp:TextBox ID="txtCertificado" runat="server" Height="100px" 
                                                                    TextMode="MultiLine" Width="100%"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                        </fieldset>
                                                
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center" colspan="2" style="width: 100%" width="50%">
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td colspan="2" style="width: 100%" width="50%">
                                        
                                                    <fieldset>
                                                                                                                <legend>SELLO DIGITAL</legend>
                                                    <table style="width: 100%;">                                                        
                                                        <tr>
                                                            <td align="left">
                                                                <asp:TextBox ID="txtSello_Digital" runat="server" Height="100px" 
                                                                    TextMode="MultiLine" Width="100%"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                        </fieldset>
                                               
                                    </td>
                                </tr>
                                <tr>
                                    <td width="50%">
                                        &nbsp;</td>
                                    <td width="50%">
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td colspan="2" align="center">
                                        <asp:Panel ID="pnlAgregaConceptos" runat="server" BackColor="White" 
                                            CssClass="TituloModalPopupMsg" Width="70%">
                                            <table width="90%">
                                                <tr>
                                                    <td class="style11" align="center" colspan="5">
                                                        <asp:UpdatePanel ID="UpdatePanel14" runat="server">
                                                            <ContentTemplate>
                                                                <asp:Label ID="lblMsjConc" runat="server" CssClass="MsjError"></asp:Label>
                                                            </ContentTemplate>
                                                        </asp:UpdatePanel>
                                                    </td>
                                                </tr>
                                                <caption>
                                                    <br />
                                                    <tr>
                                                        <td align="left" class="auto-style32" valign="top">
                                                            <asp:Label ID="lblNivel" runat="server" Text="Nivel de Estudios:"></asp:Label>
                                                        </td>
                                                        <td align="left" colspan="2" valign="top">
                                                            <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                                                                <ContentTemplate>
                                                                    <asp:DropDownList ID="ddlNivel" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlNivel_SelectedIndexChanged" TabIndex="1" Width="100%">
                                                                    </asp:DropDownList>
                                                                    <br />
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="ddlNivel" CssClass="MsjError" ErrorMessage="*Requerido" InitialValue="Z" ValidationGroup="guardar_conceptos"></asp:RequiredFieldValidator>
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </td>
                                                        <td align="left" colspan="2" valign="top">
                                                            &nbsp;</td>
                                                    </tr>
                                                </caption>
                                                <tr>
                                                    <td align="left" class="auto-style32" valign="top">&nbsp;</td>
                                                    <td align="center" colspan="2" valign="top">
                                                        <asp:UpdateProgress ID="UpdateProgress23" runat="server" AssociatedUpdatePanelID="UpdatePanel6">
                                                            <progresstemplate>
                                                                <asp:Image ID="Image89" runat="server" AlternateText="Espere un momento, por favor.." Height="50px" ImageUrl="https://sysweb.unach.mx/resources/imagenes/ajax_loader_gray_512.gif" ToolTip="Espere un momento, por favor.." />
                                                            </progresstemplate>
                                                        </asp:UpdateProgress>
                                                    </td>
                                                    <td align="left" colspan="2" valign="top">&nbsp;</td>
                                                </tr>
                                                <tr>
                                                    <td align="left" class="auto-style32" valign="top">
                                                        <asp:Label ID="lblConceptos" runat="server" Text="Concepto:"></asp:Label>
                                                    </td>
                                                    <td align="left" colspan="2" valign="top">
                                                        <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                                                            <ContentTemplate>
                                                                <%--<asp:DropDownList ID="ddlConcepto" runat="server" AutoPostBack="True" 
                                                                    onselectedindexchanged="ddlConcepto_SelectedIndexChanged">
                                                                </asp:DropDownList>--%>
                                                                <customControl:GroupDropDownList ID="ddlConcepto" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlConcepto_SelectedIndexChanged" Width="100%">
                                                                </customControl:GroupDropDownList>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator26" runat="server" ControlToValidate="ddlConcepto" CssClass="MsjError" ErrorMessage="*Requerido" InitialValue="00000" ValidationGroup="guardar_conceptos"></asp:RequiredFieldValidator>
                                                            </ContentTemplate>
                                                        </asp:UpdatePanel>
                                                    </td>
                                                    <td align="left" colspan="2" valign="top">
                                                        &nbsp;</td>
                                                </tr>
                                                <tr>
                                                    <td align="left" class="auto-style32" valign="top">&nbsp;</td>
                                                    <td align="center" colspan="2" valign="top">
                                                        <asp:UpdateProgress ID="UpdateProgress24" runat="server" AssociatedUpdatePanelID="UpdatePanel7">
                                                            <progresstemplate>
                                                                <asp:Image ID="Image90" runat="server" AlternateText="Espere un momento, por favor.." Height="50px" ImageUrl="https://sysweb.unach.mx/resources/imagenes/ajax_loader_gray_512.gif" ToolTip="Espere un momento, por favor.." />
                                                            </progresstemplate>
                                                        </asp:UpdateProgress>
                                                    </td>
                                                    <td align="left" colspan="2" valign="top">&nbsp;</td>
                                                </tr>
                                                <tr>
                                                    <td align="left" class="auto-style32" valign="top">
                                                        <asp:Label ID="lblValor_unitario" runat="server" Text="P. Unitario:"></asp:Label>
                                                    </td>
                                                    <td align="left" colspan="2" valign="top">
                                                        <table style="width:100%;">
                                                            <tr>
                                                                <td class="auto-style29" valign="top">
                                                                    <asp:UpdatePanel ID="UpdatePanel8" runat="server">
                                                                        <ContentTemplate>
                                                                            <asp:TextBox ID="txtValor_unitario" runat="server"></asp:TextBox>
                                                                            <br />
                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator19" runat="server" ControlToValidate="txtValor_unitario" CssClass="MsjError" ErrorMessage="*Requerido" ValidationGroup="guardar_conceptos"></asp:RequiredFieldValidator>
                                                                            <br />
                                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator104" runat="server" ControlToValidate="txtValor_unitario" ValidationExpression="^-?([0-9]{1,3},([0-9]{3},)*[0-9]{3}|[0-9]+)(.[0-9]{0,2})?$" SetFocusOnError="True" ValidationGroup="Detalle">*Formato (999,999,999.99)</asp:RegularExpressionValidator>
                                                                        </ContentTemplate>
                                                                    </asp:UpdatePanel>
                                                                </td>
                                                                <td valign="top">
                                                                    <asp:Label ID="lblCantidad" runat="server" Text="Cantidad:"></asp:Label>
                                                                </td>
                                                                <td valign="top">
                                                                    <asp:UpdatePanel ID="UpdatePanel10" runat="server">
                                                                        <ContentTemplate>
                                                                            <asp:TextBox ID="txtCantidad" runat="server" ValidationGroup="conceptos" Width="25%">1</asp:TextBox>
                                                                            <br />
                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator20" runat="server" ControlToValidate="txtCantidad" CssClass="MsjError" ErrorMessage="*Requerido" ValidationGroup="guardar_conceptos"></asp:RequiredFieldValidator>
                                                                            <br />
                                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txtCantidad" CssClass="MsjError" ErrorMessage="*Solo Números" ValidationExpression="\d+"></asp:RegularExpressionValidator>
                                                                        </ContentTemplate>
                                                                    </asp:UpdatePanel>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                    <td align="left" colspan="2" valign="top">&nbsp;</td>
                                                </tr>
                                                <tr>
                                                    <td align="center" colspan="5" width="35%">
                                                        &nbsp;</td>
                                                </tr>
                                                <tr>
                                                    <td align="center" colspan="5" width="35%">
                                                        <asp:UpdatePanel ID="UpdatePanel11" runat="server">
                                                            <ContentTemplate>
                                                                <asp:Button ID="btnGuardar_Concep_Continuar" runat="server" Cssclass="btn btn-info" onclick="btnGuardar_Concep_Continuar_Click" Text="GUARDAR Y CONTINUAR" ValidationGroup="guardar_conceptos" />
                                                                &nbsp;<asp:Button ID="btnGuardar_Concep" runat="server" CssClass="btn btn-primary" onclick="btnGuardar_Concep_Click" Text="GUARDAR Y SALIR" ValidationGroup="guardar_conceptos" />
                                                                &nbsp;<asp:Button ID="btnCancelar_Concp" runat="server" CssClass="btn btn-blue-grey" Text="CANCELAR" onclick="btnCancelar_Concp_Click" />
                                                                &nbsp;
                                                            </ContentTemplate>
                                                        </asp:UpdatePanel>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" class="auto-style32">
                                                        &nbsp;</td>
                                                    <td class="style8">
                                                        &nbsp;</td>
                                                    <td class="auto-style30">
                                                        &nbsp;</td>
                                                    <td class="style7" width="35%">
                                                        &nbsp;</td>
                                                    <td>
                                                        &nbsp;</td>
                                                </tr>
                                            </table>
                                        </asp:Panel>
                                    </td>
                                </tr>
                                <tr>
                                    <td width="50%">
                                        &nbsp;</td>
                                    <td width="50%">
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td align="center" colspan="2" style="width: 100%" width="50%">
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td width="50%">
                                        &nbsp;</td>
                                    <td width="50%">
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td align="center" colspan="2" style="width: 100%" width="50%">
                                        <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                                            <ContentTemplate>
                                                &nbsp;<asp:Button ID="btnGuardar" runat="server" Cssclass="btn btn-info" 
                                                    onclick="btnGuardar_Click" Text="GUARDAR" />
                                                &nbsp;<asp:Button ID="btnCancelar" runat="server" CssClass="btn btn-blue-grey" 
                                                    onclick="btnCancelar_Click" Text="CANCELAR" />
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </td>
                                </tr>
                                <tr>
                                    <td width="50%">
                                        &nbsp;</td>
                                    <td width="50%">
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td width="50%">
                                        &nbsp;</td>
                                    <td width="50%">
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td width="50%">
                                        &nbsp;</td>
                                    <td width="50%">
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td width="50%">
                                        &nbsp;</td>
                                    <td width="50%">
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td width="50%">
                                        &nbsp;</td>
                                    <td width="50%">
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td width="50%">
                                        &nbsp;</td>
                                    <td width="50%">
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td width="50%">
                                        &nbsp;</td>
                                    <td width="50%">
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td width="50%" colspan="2" style="width: 100%">
                                        &nbsp;</td>
                                </tr>
                            </table>
                        </asp:Panel>
                    </ContentTemplate>
                </asp:UpdatePanel>
                <table width="100%"><tr><td align="center">
<asp:UpdateProgress ID="UpdateProgress22" runat="server" AssociatedUpdatePanelID="UpdatePanel33">
                    <ProgressTemplate>
                        <asp:Image ID="Image87" runat="server" Height="50px" ImageUrl="https://sysweb.unach.mx/resources/imagenes/ajax_loader_gray_512.gif" AlternateText="Espere un momento, por favor.." 
                            ToolTip="Espere un momento, por favor.." />
                    </ProgressTemplate>
                </asp:UpdateProgress>
                <asp:UpdatePanel ID="UpdatePanel33" runat="server">
                    <ContentTemplate>
                        <iframe id="miniContenedor" frameborder="0" marginheight="0" marginwidth="0" name="miniContenedor"
                            style="height: 500px" width="100%"></iframe>
                    </ContentTemplate>
                </asp:UpdatePanel></td></tr></table>
            </td>
        </tr>
    </table>
<script language="javascript" type="text/javascript">   
    <%--$(function () {        
        $("#<%=txtFolioBuscar.ClientID %>").keypress(function () {
            //alert("pasa");
                $("#<%=imgbtnBuscar.ClientID %>").focus(); //alert("Wow; Its Work!.")
            });
        });--%>
    function button_click(objTextBox, objBtnID) {
        if (window.event.keyCode == 13) {
            document.getElementById(objBtnID).focus();
        }
    }
</script>
</asp:Content>
