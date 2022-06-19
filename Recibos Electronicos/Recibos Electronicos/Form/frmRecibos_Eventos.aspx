<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmRecibos_Eventos.aspx.cs" Inherits="Recibos_Electronicos.Form.frmRecibos_Eventos" %>

<%@ Register Src="../EnviarCorreo.ascx" TagName="uCCorreo" TagPrefix="usr" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script src="../Scripts/DataTables/jquery.dataTables.min.js"></script>
    <link href="../Content/DataTables/css/jquery.dataTables.min.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container-fluid">
        <div class="row">
            <div class="col-md-1">
                Dependencia
            </div>
            <div class="col-md-11">
                <asp:UpdatePanel ID="updPnlDep" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddlDependencia" runat="server" Width="100%" AutoPostBack="True" OnSelectedIndexChanged="ddlDependencia_SelectedIndexChanged">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddlDependencia" ErrorMessage="RequiredFieldValidator" InitialValue="0" ValidationGroup="Buscar">*Elegir una Dependencia</asp:RequiredFieldValidator>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>

        </div>

        <div class="row">
            <div class="col font-weight-bold text-warning">
                Fecha de Pago
            </div>
        </div>
        <hr />
        <div class="row">
            <div class="col-md-2">
                Tipo Evento
            </div>
            <div class="col-md-2">
                <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddlDirigido" runat="server" Width="100%" AutoPostBack="True" OnSelectedIndexChanged="ddlDirigido_SelectedIndexChanged">
                            <asp:ListItem Value="P">Eventos Especiales</asp:ListItem>
                            <asp:ListItem Value="A">Servicios Extraordinarios</asp:ListItem>
                            <asp:ListItem Value="Z">Eventos Privados</asp:ListItem>
                            <asp:ListItem Value="C">Complemento Cursos de Verano</asp:ListItem>
                        </asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
            <div class="col-md-1">
                Fecha Ini
            </div>
            <div class="col-md-3">
                <asp:UpdatePanel ID="UpdatePanel42" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txtFecha_Factura_Ini" runat="server" AutoPostBack="True" CssClass="box" onkeyup="javascript:this.value='';" Width="95px"></asp:TextBox>
                        <ajaxToolkit:CalendarExtender ID="CalendarExtenderIni" runat="server" TargetControlID="txtFecha_Factura_Ini" PopupButtonID="imgCalendarioIni" />
                        <asp:ImageButton ID="imgCalendarioIni" runat="server" ImageUrl="https://sysweb.unach.mx/resources/imagenes/calendario.gif" />
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
            <div class="col-md-1">
                Fecha Fin
            </div>
            <div class="col-md-2">
                <asp:UpdatePanel ID="UpdatePanel43" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txtFecha_Factura_Fin" runat="server" AutoPostBack="True" CssClass="box" onkeyup="javascript:this.value='';" Style="margin-left: 0px" Width="95px"></asp:TextBox>
                        <ajaxToolkit:CalendarExtender ID="CalendarExtenderFin" runat="server" PopupButtonID="imgCalendarioFin" TargetControlID="txtFecha_Factura_Fin" />
                        <asp:ImageButton ID="imgCalendarioFin" runat="server" ImageUrl="https://sysweb.unach.mx/resources/imagenes/calendario.gif" />
                    </ContentTemplate>
                </asp:UpdatePanel>

            </div>
            <div class="col-md-1">
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>
                        <asp:LinkButton ID="linkBttnBuscar" runat="server" Width="100%" CssClass="btn btn-info" OnClick="linkBttnBuscar_Click1"><i class="fa fa-search" aria-hidden="true"></i> Buscar</asp:LinkButton>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>

        <div class="row">
            <div class="col text-center">
                <asp:UpdateProgress ID="updprgDep" runat="server" AssociatedUpdatePanelID="UpdatePanel3">
                    <ProgressTemplate>
                        <div class="overlay">
                            <div class="overlayContent">
                                <asp:Image ID="img1" runat="server" Height="100px" ImageUrl="~/Imagenes/loader2.gif" Width="100px" />
                            </div>
                        </div>

                        <%--<asp:Image ID="imgDep" runat="server" Height="50px" ImageUrl="https://sysweb.unach.mx/resources/imagenes/ajax_loader_gray_512.gif" AlternateText="Espere un momento, por favor.."
                            ToolTip="Espere un momento, por favor.." />--%>
                    </ProgressTemplate>
                </asp:UpdateProgress>
            </div>
        </div>

        <div class="row">
            <div class="col text-center">
                <asp:UpdateProgress ID="updPrgBuscarDatos" runat="server" AssociatedUpdatePanelID="UpdatePanel2">
                    <ProgressTemplate>
                        <asp:Image ID="imgBuscarDatos" runat="server" Height="50px" ImageUrl="https://sysweb.unach.mx/resources/imagenes/ajax_loader_gray_512.gif" AlternateText="Espere un momento, por favor.."
                            ToolTip="Espere un momento, por favor.." />
                    </ProgressTemplate>
                </asp:UpdateProgress>
            </div>
        </div>

        <div class="row">
            <div class="col">
                <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                    <ContentTemplate>
                        <asp:GridView ID="grdEventos" runat="server" AutoGenerateColumns="False" CssClass="sem table table-striped table-bordered table-hover" EmptyDataText="No existen eventos para esta dependencia." Width="100%" OnSelectedIndexChanged="grdEventos_SelectedIndexChanged">
                            <Columns>
                                <asp:BoundField DataField="ID" HeaderText="ID" />
                                <asp:BoundField DataField="Eventos" HeaderText="CVE" />
                                <asp:BoundField DataField="Dependencia" HeaderText="DEP">
                                    <HeaderStyle HorizontalAlign="Left" />
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Descripcion" HeaderText="DESCRIPCIÓN">
                                    <HeaderStyle HorizontalAlign="Left" />
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Fecha_inicial" DataFormatString="{0:dd/MM/yyyy}" HeaderText="INICIA">
                                    <HeaderStyle HorizontalAlign="Left" />
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Fecha_final" DataFormatString="{0:dd/MM/yyyy}" HeaderText="TERMINA">
                                    <HeaderStyle HorizontalAlign="Left" />
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:BoundField>
                                <asp:BoundField DataField="TotPagados" HeaderText="TOT PAGADOS">
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:CommandField HeaderText="Recibos" SelectImageUrl="~/Imagenes/search_icon.PNG" ShowSelectButton="True" SelectText="VER" ButtonType="Image">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:CommandField>
                            </Columns>
                            <FooterStyle CssClass="enc" />
                            <PagerStyle CssClass="enc" HorizontalAlign="Center" />
                            <SelectedRowStyle CssClass="sel" />
                            <HeaderStyle CssClass="enc" />
                            <AlternatingRowStyle CssClass="alt" />
                        </asp:GridView>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
        <%--<div class="row">
            <div class="col">

                <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                    <ContentTemplate>
                        <asp:ImageButton ID="imgBttnBuscar" runat="server" ImageUrl="https://sysweb.unach.mx/resources/imagenes/buscar.png" OnClick="imgBttnBuscar_Click" />
                    </ContentTemplate>
                </asp:UpdatePanel>

            </div>
        </div>--%>
        <br />
        <%--<div class="row">
            <div class="col">
                <div class="input-group mb-3">
                    <asp:TextBox ID="txtReferencia" runat="server" CssClass="form-control" PlaceHolder="Nombre/Matricula/Folio" TabIndex="4" Visible="true"></asp:TextBox>
                    <div class="input-group-append">
                        <span class="input-group-text_buscar" id="basic-addon2">
                            <asp:UpdatePanel ID="updPnlBuscarRFC" runat="server">
                                <ContentTemplate>
                                    <asp:LinkButton ID="linkBttnBuscar" runat="server" class="btn-buscar btn-primary" Width="30px" OnClick="linkBttnBuscar_Click"><i class="fa fa-search" aria-hidden="true"></i></asp:LinkButton>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </span>
                    </div>
                </div>
            </div>

        </div>--%>
        <div class="row">
            <div class="col text-center">
                <asp:UpdateProgress ID="updPgrPagos" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
                    <ProgressTemplate>
                        <div class="overlay">
                            <div class="overlayContent">
                                <asp:Image ID="imgLoaderPagos" runat="server" Height="100px" ImageUrl="~/Imagenes/loader2.gif" Width="100px" />
                            </div>
                        </div>
                    </ProgressTemplate>
                </asp:UpdateProgress>
            </div>
        </div>

        <div class="row">
            <div class="col">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <asp:GridView ID="grdDatosFactura" runat="server" OnSelectedIndexChanged="grdDatosFactura_SelectedIndexChanged"
                            EmptyDataText="No existen pagos para este evento."
                            DataKeyNames="ID_FACT"
                            AutoGenerateColumns="False"
                            OnPageIndexChanging="grdDatosFactura_OnPageIndexChanging" CssClass="sem table table-striped table-bordered table-hover" Width="100%" ShowHeaderWhenEmpty="True">
                            <Columns>
                                <asp:BoundField DataField="ID_FACT" HeaderText="ID" SortExpression="ID"></asp:BoundField>
                                <asp:BoundField DataField="FACT_FOLIO" HeaderText="Folio" SortExpression="FOLIO">
                                    <HeaderStyle HorizontalAlign="Left" />
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:BoundField>
                                <asp:BoundField DataField="FACT_MATRICULA" HeaderText="Cve" />
                                <asp:BoundField DataField="FACT_REFERENCIA" HeaderText="Referencia" SortExpression="REFERENCIA">
                                    <HeaderStyle HorizontalAlign="Left" />
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:BoundField>
                                <asp:BoundField DataField="FACT_FECHA_FACTURA" DataFormatString="{0:dd/MM/yyyy}" HeaderText="Fecha"
                                    SortExpression="FECHA_FACTURA">
                                    <HeaderStyle HorizontalAlign="Left" />
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="Importe" SortExpression="Importe">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("FACT_TOTAL") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="Label2" runat="server" Text='<%# Bind("FACT_TOTAL", "{0:c}") %>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Right" />
                                    <ItemStyle HorizontalAlign="Right" />
                                </asp:TemplateField>
                                <asp:BoundField DataField="FACT_NOMBRE" HeaderText="Nombre" SortExpression="NOMBRE">
                                    <HeaderStyle HorizontalAlign="Left" />
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:BoundField>
                                <asp:BoundField DataField="FACT_DEPENDENCIA" HeaderText="Depcia" SortExpression="DEPENDENCIA"></asp:BoundField>
                                <asp:TemplateField HeaderText="Correo">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("FACT_RECEPTOR_CORREO") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                    <HeaderTemplate>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("FACT_RECEPTOR_CORREO") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Enviar Recibo">
                                    <ItemTemplate>
                                        <asp:ImageButton ID="imgBttnCorreo" runat="server" ImageUrl="~/Imagenes/correo2.png" OnClick="imgBttnCorreo_Click" />
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:CommandField SelectText="Ver" ShowSelectButton="True"
                                    HeaderText="Ver Recibo" ButtonType="Image" SelectImageUrl="~/Imagenes/recibo2.png">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:CommandField>
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
            <div class="col-md-3">
            </div>
            <div class="col-md-1">
                <asp:Label ID="lblLeyTotPagos" runat="server" Font-Bold="True" Font-Size="14px" ForeColor="Black" Text="T O T A L"></asp:Label>
            </div>
            <div class="col-md-1 text-right">
                <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                    <ContentTemplate>
                        <asp:Label ID="lblTotPagos" runat="server" Font-Bold="True" Font-Size="14px" ForeColor="Black" Text="0"></asp:Label>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
            <div class="col-md-7 text-right">
                <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                    <ContentTemplate>
                        <asp:ImageButton ID="imgBttnReporte" runat="server" ImageUrl="https://sysweb.unach.mx/resources/imagenes/pdf.png" OnClick="imgBttnReporte_Click" />
                        <asp:ImageButton ID="imgBttnReporteLote" runat="server" ImageUrl="http://sysweb.unach.mx/resources/imagenes/pdf2.png" OnClick="imgBttnReporteLote_Click" />
                        &nbsp;<asp:ImageButton ID="imgBttnExportar" runat="server" ImageUrl="https://sysweb.unach.mx/resources/imagenes/excel.png" OnClick="imgBttnExportar_Click" />
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>

        <div class="row">
            <div class="col">
                <usr:uCCorreo ID="PnlCorreo" runat="server" />
            </div>
        </div>
    </div>


    <script type="text/javascript">
        function Eventos() {

            $('#<%= grdEventos.ClientID %>').prepend($("<thead></thead>").append($('#<%= grdEventos.ClientID %>').find("tr:first"))).DataTable({
                "stateSave": true,
                "ordering": false
            });

        }
        function Pagos() {
            $('#<%= grdDatosFactura.ClientID %>').prepend($("<thead></thead>").append($('#<%= grdDatosFactura.ClientID %>').find("tr:first"))).DataTable({
                "stateSave": true
            });

        }
    </script>
</asp:Content>
