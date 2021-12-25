<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FrmRecibos.aspx.cs" Inherits="Recibos_Electronicos.Form.FrmRecibos" %>

<%@ Register Assembly="CapaNegocio" Namespace="CapaNegocio" TagPrefix="customControl" %>

<%@ Register Src="../EnviarCorreo.ascx" TagName="uccorreo" TagPrefix="usr" %>

<%--<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>--%>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script type="text/javascript" src="../Js/jsGeneral.js"> </script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdatePanel ID="UpdMult" runat="server">
        <ContentTemplate>
            <asp:MultiView ID="MultiView1" runat="server">
                <asp:View ID="View1" runat="server">
                    <div class="container">
                        <div class="row">
                            <div class="col-md-1">
                                <asp:Label ID="lblBuscar" runat="server" Text="Buscar"></asp:Label>
                            </div>
                            <div class="col-md-9">
                                <asp:TextBox ID="txtFolioBuscar" runat="server" Placeholder="Recibo/Referencia/Nombre Completo" Width="100%"></asp:TextBox>
                            </div>
                            <div class="col-md-1">
                                <asp:UpdatePanel ID="UpdBuscar" runat="server">
                                    <ContentTemplate>
                                        <asp:ImageButton ID="imgbtnBuscar" runat="server" ImageUrl="https://sysweb.unach.mx/resources/imagenes/buscar.png" OnClick="imgbtnBuscar_Click" />
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                            <div class="col-md-1">
                                <asp:UpdateProgress ID="UpdateProgress2" runat="server"
                                    AssociatedUpdatePanelID="UpdBuscar">
                                    <ProgressTemplate>
                                        <asp:Image ID="imgBuscarFact" runat="server"
                                            AlternateText="Espere un momento, por favor.." Height="50px"
                                            ImageUrl="https://sysweb.unach.mx/resources/imagenes/ajax_loader_gray_512.gif"
                                            ToolTip="Espere un momento, por favor.." />
                                    </ProgressTemplate>
                                </asp:UpdateProgress>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <asp:UpdateProgress ID="updPgrFacturas" runat="server"
                                    AssociatedUpdatePanelID="updPnlFacturas">
                                    <ProgressTemplate>
                                        <asp:Image ID="Image86" runat="server"
                                            AlternateText="Espere un momento, por favor.." Height="50px"
                                            ImageUrl="https://sysweb.unach.mx/resources/imagenes/ajax_loader_gray_512.gif"
                                            ToolTip="Espere un momento, por favor.." />
                                    </ProgressTemplate>
                                </asp:UpdateProgress>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col text-center">
                                <asp:UpdatePanel ID="updPnlFacturas" runat="server">
                                    <ContentTemplate>
                                        <asp:GridView ID="grvFacturas" runat="server" AllowPaging="True"
                                            AutoGenerateColumns="False"
                                            OnSelectedIndexChanging="grvFacturas_SelectedIndexChanging"
                                            OnPageIndexChanging="grvFacturas_PageIndexChanging"
                                            OnSelectedIndexChanged="grvFacturas_SelectedIndexChanged"
                                            EmptyDataText="No se encontró el recibo." CssClass="mGrid" Width="100%" OnRowDeleting="grvFacturas_RowDeleting" OnRowEditing="grvFacturas_RowEditing" OnRowUpdating="grvFacturas_RowUpdating" OnRowCancelingEdit="grvFacturas_RowCancelingEdit">
                                            <Columns>
                                                <asp:BoundField DataField="ID_FACT" HeaderText="Id" ReadOnly="True" />
                                                <asp:BoundField DataField="FACT_MATRICULA" HeaderText="Matricula" ReadOnly="True">
                                                    <HeaderStyle HorizontalAlign="Left" />
                                                    <ItemStyle HorizontalAlign="Left" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="FACT_NOMBRE" HeaderText="Nombre" ReadOnly="True">
                                                    <HeaderStyle HorizontalAlign="Left" />
                                                    <ItemStyle HorizontalAlign="Left" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="FACT_CARRERA" HeaderText="Carrera" ReadOnly="True" />
                                                <asp:BoundField DataField="FACT_REFERENCIA" HeaderText="Referencia" ReadOnly="True">
                                                    <HeaderStyle HorizontalAlign="Left" />
                                                    <ItemStyle HorizontalAlign="Left" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="FACT_FOLIO" HeaderText="Recibo" ReadOnly="True">
                                                    <HeaderStyle HorizontalAlign="Left" />
                                                    <ItemStyle HorizontalAlign="Left" />
                                                </asp:BoundField>
                                                <asp:TemplateField HeaderText="Pagado">
                                                    <EditItemTemplate>
                                                        <asp:TextBox ID="txtFechaPagado" runat="server" Text='<%# Bind("FACT_FECHA_FACTURA") %>'></asp:TextBox>
                                                        <ajaxToolkit:CalendarExtender ID="calExtFechaPagado" runat="server" TargetControlID="txtFechaPagado" />
                                                    </EditItemTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("FACT_FECHA_FACTURA", "{0:d}") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Left" />
                                                    <ItemStyle HorizontalAlign="Left" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Dispersado">
                                                    <EditItemTemplate>
                                                        <asp:TextBox ID="txtFechaDispersado" runat="server" Text='<%# Bind("FACT_FECHA_DISPERSION") %>'></asp:TextBox>
                                                        <ajaxToolkit:CalendarExtender ID="calExtFechaDispersado" runat="server" TargetControlID="txtFechaDispersado" />
                                                    </EditItemTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="Label2" runat="server" Text='<%# Bind("FACT_FECHA_DISPERSION") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Editar Fecha" ShowHeader="False">
                                                    <EditItemTemplate>
                                                        <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="True" CommandName="Update" Text="Actualizar"></asp:LinkButton>
                                                        &nbsp;<asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancelar"></asp:LinkButton>
                                                    </EditItemTemplate>
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Edit"><i class="fa fa-calendar fa-2x" aria-hidden="true"></i></asp:LinkButton>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="Status_Carga" HeaderText="Status" ReadOnly="True">
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="FACT_BANCO" HeaderText="Banco" ReadOnly="True"></asp:BoundField>
                                                <asp:TemplateField HeaderText="Editar" ShowHeader="False">
                                                    <ItemTemplate>
                                                        <%--<asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="~/Imagenes/edit.png" CausesValidation="False" CommandName="Select" Text="Editar" />--%>
                                                        <asp:LinkButton ID="linBttnEditar" runat="server" CausesValidation="False" CommandName="Select"><i class="fa fa-pencil fa-2x" aria-hidden="true"></i></asp:LinkButton>
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Center" Font-Bold="True" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Ver">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="linkBttnRecibo" runat="server" OnClick="linkBttnRecibo_Click"><i class="fa fa-sticky-note fa-2x" aria-hidden="true"></i></asp:LinkButton>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Enviar">
                                                    <ItemTemplate>
                                                        <%--<asp:ImageButton ID="imgBttnRecibo" runat="server" ImageUrl="~/Imagenes/recibo2.png" OnClick="imgBttnRecibo_Click" />--%>
                                                        <asp:LinkButton ID="linkBttnCorreo" runat="server" OnClick="linkBttnCorreo_Click"><i class="fa fa-envelope fa-2x" aria-hidden="true"></i></asp:LinkButton>
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Hist">
                                                    <ItemTemplate>
                                                        <%--<asp:ImageButton ID="imgBttnHistorico" runat="server" ImageUrl="~/Imagenes/historico.png" OnClick="imgBttnHistorico_Click" />--%>
                                                        <asp:LinkButton ID="linkBttnHistorico" runat="server" OnClick="linkBttnHistorico_Click"><i class="fa fa-list fa-2x" aria-hidden="true"></i></asp:LinkButton>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Borrar" ShowHeader="False">
                                                    <ItemTemplate>
                                                        <%--<asp:ImageButton ID="ImageButton1" runat="server" CausesValidation="False" CommandName="Delete" ImageUrl="~/Imagenes/del.png" OnClientClick="return confirm('¿Eliminar registro?');" Text="Eliminar" />--%>
                                                        <asp:LinkButton ID="linkBttnBorrar" runat="server" CausesValidation="False" CommandName="Delete" OnClientClick="return confirm('¿Eliminar registro?');"><i class="fa fa-trash fa-2x" aria-hidden="true"></i></asp:LinkButton>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                            <FooterStyle CssClass="enc" />
                                            <PagerStyle CssClass="enc" HorizontalAlign="Center" />
                                            <SelectedRowStyle CssClass="sel" />
                                            <HeaderStyle CssClass="enc" BackColor="#595959" ForeColor="White" Font-Size="10px" BorderColor="White" />
                                            <AlternatingRowStyle CssClass="alt" />
                                        </asp:GridView>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <asp:UpdateProgress ID="UpdateProgress22" runat="server" AssociatedUpdatePanelID="UpdatePanel33">
                                    <ProgressTemplate>
                                        <asp:Image ID="Image87" runat="server" Height="50px" ImageUrl="https://sysweb.unach.mx/resources/imagenes/ajax_loader_gray_512.gif" AlternateText="Espere un momento, por favor.."
                                            ToolTip="Espere un momento, por favor.." />
                                    </ProgressTemplate>
                                </asp:UpdateProgress>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <asp:UpdatePanel ID="UpdatePanel33" runat="server">
                                    <ContentTemplate>
                                        <iframe id="miniContenedor" frameborder="0" marginheight="0" marginwidth="0" name="miniContenedor"
                                            style="height: 500px" width="100%"></iframe>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                    </div>
                </asp:View>
                <asp:View ID="View2" runat="server">
                    <div class="container-fluid">
                        <div class="row">
                            <div class="col-md-2">
                                <asp:Image ID="Image1" runat="server" ImageUrl="~/Imagenes/escudounach.png" Height="108px" Width="124px" />
                            </div>
                            <div class="col-md-5 text-center">
                                <asp:Label ID="Label14" runat="server" Font-Bold="True" Font-Size="Larger"
                                    Text="UNIVERSIDAD AUTÓNOMA DE CHIAPAS" Font-Names="Trajan Pro"></asp:Label>
                                <br />
                                BLVD. BELISARIO DOMINGUEZ KM. 1081
                                                <br />
                                TERÁN SIN NÚMERO, C.P. 29050"
                                                   <br />
                                TUXTLA GUTIÉRREZ, CHIAPAS, MÉXICO
                                                 <br />
                                RFC: UAC750417LE8
                            </div>
                            <div class="col-md-5 card bg-light mb-3">
                                <div class="row">
                                    <div class="col text-center font-weight-bold">
                                        Recibo UNACH
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-2">
                                        <asp:Label ID="lblFolio" runat="server" Font-Size="XX-Small"
                                            Text="Serie-Folio"></asp:Label>
                                    </div>
                                    <div class="col-md-10">
                                        <asp:TextBox ID="txtFolio" runat="server" Width="85%"
                                            Enabled="False"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-2">
                                        <asp:Label ID="Label20" runat="server" Font-Size="XX-Small" Text="Fecha"></asp:Label>
                                    </div>
                                    <div class="col-md-4">
                                        <asp:TextBox ID="txtFecha_Cfd1" runat="server" AutoPostBack="True" CssClass="box" onkeyup="javascript:this.value='';" Width="95px"></asp:TextBox>
                                        <ajaxToolkit:CalendarExtender ID="CalendarFecha_Cfd1" runat="server" TargetControlID="txtFecha_Cfd1" PopupButtonID="imgCalendarioCfd1" />
                                        <asp:ImageButton ID="imgCalendarioCfd1" runat="server" ImageUrl="https://sysweb.unach.mx/resources/imagenes/calendario.gif" />
                                    </div>
                                    <div class="col-md-2">
                                        <asp:Label ID="lblFecha_Dispersion" runat="server" Font-Size="XX-Small" Text="Fecha Dispersión"></asp:Label>
                                    </div>
                                    <div class="col-md-4">
                                        <asp:TextBox ID="txtFecha_Dispersion" runat="server" AutoPostBack="True" CssClass="box" onkeyup="javascript:this.value='';" Width="95px"></asp:TextBox>
                                        <ajaxToolkit:CalendarExtender ID="CalendarFecha_Dispersion" runat="server" TargetControlID="txtFecha_Dispersion" PopupButtonID="imgCalendarioDisp" />
                                        <asp:ImageButton ID="imgCalendarioDisp" runat="server" ImageUrl="https://sysweb.unach.mx/resources/imagenes/calendario.gif" />
                                    </div>
                                </div>
                                <%--<div class="row">
                                    <div class="col-md-3">
                                        <asp:Label ID="lblNo_Certificado" runat="server" Font-Size="XX-Small"
                                            Text="No. Certificado Digital"></asp:Label>
                                    </div>
                                    <div class="col-md-3">
                                        <asp:TextBox ID="txtNo_Certificado" runat="server"
                                            Width="100%" Enabled="False"></asp:TextBox>
                                    </div>                              
                                    <div class="col-md-4">
                                        <asp:Label ID="Label22" runat="server" Font-Size="XX-Small"
                                            Text="Año y Número de Aprobación"></asp:Label>
                                    </div>                                    
                                    <div class="col-md-2">
                                        <asp:TextBox ID="txtAnio_Aprobacion" runat="server" Enabled="False"
                                            Width="100%"></asp:TextBox>
                                    </div>
                                </div>--%>
                            </div>
                        </div>
                        <br />
                        <div class="row" style="font-size: 12px;">
                            <div class="col-md-6">
                                <div class="row">
                                    <div class="col-md-2">
                                        A FAVOR DE
                                    </div>
                                    <div class="col-md-10">
                                        <asp:TextBox ID="txtReceptor_Nombre" runat="server" Width="80%"
                                            Font-Size="Small"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server"
                                            ControlToValidate="txtReceptor_Nombre" CssClass="MsjError"
                                            ErrorMessage="*Requerido" ValidationGroup="guardar"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-2">
                                        <asp:Label ID="lblReceptor_Rfc" runat="server" Text="RFC"></asp:Label>
                                    </div>
                                    <div class="col-md-10">
                                        <asp:TextBox ID="txtReceptor_Rfc" runat="server" Width="50%"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-2">
                                        <asp:Label ID="lblReceptor_Domicilio" runat="server" Text="DIRECCIÓN"></asp:Label>
                                    </div>
                                    <div class="col-md-10">
                                        <asp:TextBox ID="txtReceptor_Domicilio" runat="server" Width="100%"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-2">
                                        <asp:Label ID="lblReceptor_Colonia" runat="server" Text="COLONIA"></asp:Label>
                                    </div>
                                    <div class="col-md-10">
                                        <asp:TextBox ID="txtReceptor_Colonia" runat="server" Width="100%"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-2">
                                        <asp:Label ID="lblReceptor_Pais" runat="server" Text="LUGAR"></asp:Label>
                                    </div>
                                    <div class="col-md-10">
                                        <asp:TextBox ID="txtReceptor_Pais" runat="server" Width="100%"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-2">
                                        <asp:Label ID="lblMatricula" runat="server" Text="MATRICULA"></asp:Label>
                                    </div>
                                    <div class="col-md-10">
                                        <asp:TextBox ID="txtMatricula" runat="server" Width="50%"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator17" runat="server"
                                            ControlToValidate="txtMatricula" CssClass="MsjError" ErrorMessage="*Requerido"
                                            ValidationGroup="guardar"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-2">
                                        <asp:Label ID="lblCarrera" runat="server" Text="CARRERA"></asp:Label>
                                    </div>
                                    <div class="col-md-10">
                                        <asp:TextBox ID="txtCarrera" runat="server" Width="100%"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator25" runat="server"
                                            ControlToValidate="txtCarrera" CssClass="MsjError" ErrorMessage="*Requerido"
                                            ValidationGroup="guardar"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="row">
                                    <div class="col-md-2">
                                        <asp:Label ID="lblDesc_Dependencia" runat="server" Text="DES"></asp:Label>
                                    </div>
                                    <div class="col-md-10">
                                        <asp:TextBox ID="txtDesc_Dependencia" runat="server" Width="100%"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-2">
                                        <asp:Label ID="lblExpedido_Domicilio" runat="server" Text="DIRECCIÓN"></asp:Label>
                                    </div>
                                    <div class="col-md-10">
                                        <asp:TextBox ID="txtExpedido_Domicilio" runat="server" Width="100%"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-2">
                                        <asp:Label ID="lblExpedido_Colonia" runat="server" Text="COLONIA"></asp:Label>
                                    </div>
                                    <div class="col-md-10">
                                        <asp:TextBox ID="txtExpedido_Colonia" runat="server" Width="100%"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-2">
                                        <asp:Label ID="lblExpedido_Pais" runat="server" Text="LUGAR"></asp:Label>
                                    </div>
                                    <div class="col-md-10">
                                        <asp:TextBox ID="txtExpedido_Pais" runat="server" Width="100%"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-2">
                                        <asp:Label ID="lblFecha_Cfd" runat="server" Text="FECHA"></asp:Label>
                                    </div>
                                    <div class="col-md-10">
                                        <asp:TextBox ID="txtFecha_Cfd2" runat="server"
                                            CssClass="box" Width="95px" Enabled="False"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-2">
                                <asp:Label ID="lblStatus" runat="server" Text="Status"></asp:Label>
                            </div>
                            <div class="col-md-10">
                                <asp:UpdatePanel ID="UpdatePanel34" runat="server">
                                    <ContentTemplate>
                                        <asp:RadioButtonList ID="rdoListStatus" runat="server" AutoPostBack="True" OnSelectedIndexChanged="rdoListStatus_SelectedIndexChanged" RepeatDirection="Horizontal">
                                            <asp:ListItem Value="A">Activo</asp:ListItem>
                                            <asp:ListItem Value="C">Cancelado</asp:ListItem>
                                            <asp:ListItem Value="R">Reembolsado</asp:ListItem>
                                        </asp:RadioButtonList>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-2">
                                <asp:Label ID="lblStatus_Notas" runat="server" Text="Observaciones"></asp:Label>
                            </div>
                            <div class="col-md-10">
                                <asp:TextBox ID="txtStatus_Notas" runat="server" Height="71px" TextMode="MultiLine" Width="100%"></asp:TextBox>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <asp:UpdatePanel ID="UpdatePanel13" runat="server">
                                    <ContentTemplate>
                                        <asp:Panel ID="pnlMsjReg" CssClass=" alert alert-danger" runat="server">
                                            <asp:Label ID="lblMsj2" runat="server" Width="100%"></asp:Label>
                                        </asp:Panel>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col text-right">
                                <asp:ImageButton ID="imgBttnAgregarConcepto0" runat="server" ImageUrl="https://sysweb.unach.mx/resources/imagenes/nuevo.png" OnClick="imgBttnAgregarConcepto0_Click" />
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <asp:GridView ID="grvFacturas_Detalle" runat="server" AutoGenerateColumns="False"
                                    Width="100%" OnRowDeleting="grvFacturas_Detalle_RowDeleting" CssClass="mGrid">
                                    <Columns>
                                        <asp:BoundField DataField="IdDetFact" HeaderText="ID">
                                            <ItemStyle Width="10%" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="ClaveConcepto" HeaderText="CLAVE">
                                            <HeaderStyle HorizontalAlign="Left" />
                                            <ItemStyle HorizontalAlign="Left" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="cantidad" HeaderText="CANTIDAD">
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Center" Width="15%" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="DescConcepto" HeaderText="CONCEPTO">
                                            <HeaderStyle HorizontalAlign="Left" />
                                            <ItemStyle HorizontalAlign="Left" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="ValorUnitario" HeaderText="P. UNITARIO">
                                            <HeaderStyle HorizontalAlign="Right" />
                                            <ItemStyle HorizontalAlign="Right" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="importe" HeaderText="IMPORTE">
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
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <asp:Label ID="lblTotal_Letras" runat="server"></asp:Label>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-9"></div>
                            <div class="col-md-3">
                                <div class="row">
                                    <div class="col-md-3">
                                        <asp:Label ID="lblSubtotal" runat="server" Text="SubTotal"></asp:Label>
                                    </div>
                                    <div class="col-md-9">
                                        <asp:TextBox ID="txtSubtotal" runat="server" Width="50px"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-3">
                                        <asp:Label ID="lblImpuesto_Tasa" runat="server" Text="IVA 0.00"></asp:Label>
                                    </div>
                                    <div class="col-md-9">
                                        <asp:TextBox ID="txtImpuesto_Tasa" runat="server" Width="50px"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-3">
                                        <asp:Label ID="lblTotal" runat="server" Text="Total"></asp:Label>
                                    </div>
                                    <div class="col-md-9">
                                        <asp:TextBox ID="txtTotal" runat="server" Width="50px"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <legend>OBSERVACIONES</legend>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <asp:TextBox ID="txtNotas" runat="server" Height="100px" Width="100%"
                                    TextMode="MultiLine"></asp:TextBox>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
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
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
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
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <asp:UpdateProgress ID="UpdateProgress25" runat="server" AssociatedUpdatePanelID="UpdatePanel5">
                                    <ProgressTemplate>
                                        <asp:Image ID="Image91" runat="server" AlternateText="Espere un momento, por favor.." Height="50px" ImageUrl="https://sysweb.unach.mx/resources/imagenes/ajax_loader_gray_512.gif" ToolTip="Espere un momento, por favor.." />
                                    </ProgressTemplate>
                                </asp:UpdateProgress>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col text-right">
                                <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                                    <ContentTemplate>
                                        &nbsp;<asp:Button ID="btnGuardar" runat="server" CssClass="btn btn-info"
                                            OnClick="btnGuardar_Click" Text="GUARDAR" />
                                        &nbsp;<asp:Button ID="btnCancelar" runat="server" CssClass="btn btn-blue-grey"
                                            OnClick="btnCancelar_Click" Text="CANCELAR" />
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                    </div>
                </asp:View>
            </asp:MultiView>
        </ContentTemplate>
    </asp:UpdatePanel>
    <usr:uccorreo ID="PnlCorreo" runat="server" />
    <div class="modal fade" id="modalConceptos" tabindex="-1" role="dialog" aria-labelledby="modalConceptos" aria-hidden="true">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="modConceptos">Conceptos</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    <div class="container">
                        <div class="row">
                            <div class="col">
                                <asp:UpdatePanel ID="UpdatePanel14" runat="server">
                                    <ContentTemplate>
                                        <asp:Label ID="lblMsjConc" runat="server" CssClass="MsjError"></asp:Label>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-3">
                                Nivel de Estudios
                            </div>
                            <div class="col-md-8">
                                <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                                    <ContentTemplate>
                                        <asp:DropDownList ID="ddlNivel" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlNivel_SelectedIndexChanged" TabIndex="1" Width="100%">
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="ddlNivel" CssClass="MsjError" ErrorMessage="*Requerido" InitialValue="Z" ValidationGroup="guardar_conceptos"></asp:RequiredFieldValidator>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                            <div class="col-md-1">
                                <asp:UpdateProgress ID="UpdateProgress23" runat="server" AssociatedUpdatePanelID="UpdatePanel6">
                                    <ProgressTemplate>
                                        <asp:Image ID="Image89" runat="server" AlternateText="Espere un momento, por favor.." Height="50px" ImageUrl="https://sysweb.unach.mx/resources/imagenes/ajax_loader_gray_512.gif" ToolTip="Espere un momento, por favor.." />
                                    </ProgressTemplate>
                                </asp:UpdateProgress>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-3">
                                Concepto
                            </div>
                            <div class="col-md-8">
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
                            </div>

                            <div class="col-md-1">
                                <asp:UpdateProgress ID="UpdateProgress24" runat="server" AssociatedUpdatePanelID="UpdatePanel7">
                                    <ProgressTemplate>
                                        <asp:Image ID="Image90" runat="server" AlternateText="Espere un momento, por favor.." Height="50px" ImageUrl="https://sysweb.unach.mx/resources/imagenes/ajax_loader_gray_512.gif" ToolTip="Espere un momento, por favor.." />
                                    </ProgressTemplate>
                                </asp:UpdateProgress>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-3">
                                <asp:Label ID="lblValor_unitario" runat="server" Text="P. Unitario"></asp:Label>
                            </div>
                            <div class="col-md-3">
                                <asp:UpdatePanel ID="UpdatePanel8" runat="server">
                                    <ContentTemplate>
                                        <asp:TextBox ID="txtValor_unitario" runat="server" Width="100%"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator19" runat="server" ControlToValidate="txtValor_unitario" CssClass="MsjError" ErrorMessage="*Requerido" ValidationGroup="guardar_conceptos"></asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator104" runat="server" ControlToValidate="txtValor_unitario" ValidationExpression="^-?([0-9]{1,3},([0-9]{3},)*[0-9]{3}|[0-9]+)(.[0-9]{0,2})?$" SetFocusOnError="True" ValidationGroup="Detalle">*Formato (999,999,999.99)</asp:RegularExpressionValidator>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                            <div class="col-md-3">
                                <asp:Label ID="lblCantidad" runat="server" Text="Cantidad"></asp:Label>
                            </div>
                            <div class="col-md-3">
                                <asp:UpdatePanel ID="UpdatePanel10" runat="server">
                                    <ContentTemplate>
                                        <asp:TextBox ID="txtCantidad" runat="server" ValidationGroup="conceptos" Width="100%">1</asp:TextBox>
                                        <br />
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator20" runat="server" ControlToValidate="txtCantidad" CssClass="MsjError" ErrorMessage="*Requerido" ValidationGroup="guardar_conceptos"></asp:RequiredFieldValidator>
                                        <br />
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txtCantidad" CssClass="MsjError" ErrorMessage="*Solo Números" ValidationExpression="\d+"></asp:RegularExpressionValidator>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col text-right">
                                <asp:UpdatePanel ID="UpdatePanel11" runat="server">
                                    <ContentTemplate>
                                        <asp:Button ID="btnGuardar_Concep_Continuar" runat="server" CssClass="btn btn-info" OnClick="btnGuardar_Concep_Continuar_Click" Text="GUARDAR" ValidationGroup="guardar_conceptos" />
                                        <%-- &nbsp;<asp:Button ID="btnGuardar_Concep" runat="server" CssClass="btn btn-primary" OnClick="btnGuardar_Concep_Click" Text="GUARDAR Y SALIR" ValidationGroup="guardar_conceptos" />
                                                            &nbsp;--%>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                    </div>

                </div>
            </div>
        </div>
    </div>
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
