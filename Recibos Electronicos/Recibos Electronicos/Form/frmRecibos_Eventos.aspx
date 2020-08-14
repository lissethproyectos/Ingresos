<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmRecibos_Eventos.aspx.cs" Inherits="Recibos_Electronicos.Form.frmRecibos_Eventos" %>

<%@ Register Src="../EnviarCorreo.ascx" TagName="uCCorreo" TagPrefix="usr" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 111px;
        }

        .auto-style2 {
            width: 149px;
        }

        .auto-style3 {
            font-size: medium;
        }

        .auto-style6 {
            width: 880px;
        }

        .auto-style8 {
            text-align: left;
            width: 133px;
        }

        .auto-style9 {
            width: 86%;
            text-align: right;
        }

        .auto-style10 {
            width: 133px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-md-2">
                Dependencia
            </div>
            <div class="col-md-5">
                <asp:UpdatePanel ID="updPnlDep" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddlDependencia" runat="server" Width="100%" AutoPostBack="True" OnSelectedIndexChanged="ddlDependencia_SelectedIndexChanged">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddlDependencia" ErrorMessage="RequiredFieldValidator" InitialValue="0" ValidationGroup="Buscar">*Elegir una Dependencia</asp:RequiredFieldValidator>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>

            <div class="col-md-2">
                Tipo de Evento
            </div>
            <div class="col-md-3">
                <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddlDirigido" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlDirigido_SelectedIndexChanged">
                            <asp:ListItem Value="P">Eventos Especiales</asp:ListItem>
                            <asp:ListItem Value="A">Servicios Extraordinarios</asp:ListItem>
                            <asp:ListItem Value="C">Complemento Cursos de Verano</asp:ListItem>
                        </asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
        <div class="row">
            <div class="col text-center">
                <asp:UpdateProgress ID="updprgDep" runat="server" AssociatedUpdatePanelID="UpdatePanel3">
                    <ProgressTemplate>
                        <asp:Image ID="imgDep" runat="server" Height="50px" ImageUrl="https://sysweb.unach.mx/resources/imagenes/ajax_loader_gray_512.gif" AlternateText="Espere un momento, por favor.."
                            ToolTip="Espere un momento, por favor.." />
                    </ProgressTemplate>
                </asp:UpdateProgress>
            </div>
        </div>
        <div class="row">
            <div class="col-md-10">
                <asp:TextBox ID="txtBuscarEvento" runat="server" CssClass="box" PlaceHolder="Cve/Descripción" TabIndex="4" Visible="true" Width="98%"></asp:TextBox>
            </div>
            <div class="col-md-2">
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>
                        <asp:ImageButton ID="imgBttnBuscarEvento" runat="server" ImageUrl="https://sysweb.unach.mx/resources/imagenes/buscar.png" OnClick="imgBttnBuscarEvento_Click" />
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
        <div class="row">
            <div class="col">
                <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                    <ContentTemplate>
                        <asp:GridView ID="grdEventos" runat="server" AutoGenerateColumns="False" CssClass="mGrid" EmptyDataText="No existen eventos para esta dependencia." Width="100%" AllowPaging="True" OnPageIndexChanging="grdEventos_PageIndexChanging" PageSize="7" OnSelectedIndexChanged="grdEventos_SelectedIndexChanged">
                            <Columns>
                                <asp:BoundField DataField="Eventos" HeaderText="CVE." />
                                <asp:BoundField DataField="Dependencia" HeaderText="Dep.">
                                    <HeaderStyle HorizontalAlign="Left" />
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Descripcion" HeaderText="Descripcion">
                                    <HeaderStyle HorizontalAlign="Left" />
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Fecha_inicial" DataFormatString="{0:dd/MM/yyyy}" HeaderText="Fecha Inicial">
                                    <HeaderStyle HorizontalAlign="Left" />
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Fecha_final" DataFormatString="{0:dd/MM/yyyy}" HeaderText="Fecha Final">
                                    <HeaderStyle HorizontalAlign="Left" />
                                    <ItemStyle HorizontalAlign="Left" />
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
        <div class="row">
            <div class="col">
                <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                    <ContentTemplate>
                        <asp:Panel ID="pnlBuscaRef" runat="server" Visible="False">
                            <div class="container">
                                <div class="row">
                                    <div class="col-md-10">
                                        <asp:TextBox ID="txtReferencia" runat="server" CssClass="box" PlaceHolder="Nombre/Matricula/Folio" TabIndex="4" Visible="true" Width="98%"></asp:TextBox>
                                    </div>
                                    <div class="col-md-2">
                                        <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                                            <ContentTemplate>
                                                <asp:ImageButton ID="imgBttnBuscar" runat="server" ImageUrl="https://sysweb.unach.mx/resources/imagenes/buscar.png" OnClick="imgBttnBuscar_Click" />
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </div>
                                </div>
                            </div>
                        </asp:Panel>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
        <div class="row">
            <div class="col">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <asp:GridView ID="grdDatosFactura" runat="server" OnSelectedIndexChanged="grdDatosFactura_SelectedIndexChanged"
                            EmptyDataText="No existen pagos para este evento."
                            DataKeyNames="ID_FACT"
                            AutoGenerateColumns="False" AllowPaging="True"
                            OnPageIndexChanging="grdDatosFactura_OnPageIndexChanging" CssClass="mGrid" Width="100%" PageSize="20" ShowFooter="True">
                            <Columns>
                                <asp:BoundField DataField="ID_FACT" HeaderText="ID" SortExpression="ID"></asp:BoundField>
                                <asp:BoundField DataField="FACT_FOLIO" HeaderText="Folio" SortExpression="FOLIO">
                                    <HeaderStyle HorizontalAlign="Left" />
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:BoundField>
                                <asp:BoundField DataField="FACT_REFERENCIA" HeaderText="Referencia" SortExpression="REFERENCIA">
                                    <HeaderStyle HorizontalAlign="Left" />
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:BoundField>
                                <asp:BoundField DataField="FACT_FECHA_FACTURA" DataFormatString="{0:dd/MM/yyyy}" HeaderText="Fecha"
                                    SortExpression="FECHA_FACTURA">
                                    <HeaderStyle HorizontalAlign="Left" />
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:BoundField>
                                <asp:BoundField DataField="FACT_TOTAL" DataFormatString="{0:c}" ItemStyle-HorizontalAlign="Right" HeaderText="Importe" SortExpression="Importe">
                                    <HeaderStyle HorizontalAlign="Right" />
                                    <ItemStyle HorizontalAlign="Right" />
                                </asp:BoundField>
                                <asp:BoundField DataField="FACT_NOMBRE" HeaderText="Nombre" SortExpression="NOMBRE">
                                    <HeaderStyle HorizontalAlign="Left" />
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:BoundField>
                                <asp:BoundField DataField="FACT_DEPENDENCIA" HeaderText="Dep." SortExpression="DEPENDENCIA"></asp:BoundField>
                                <asp:TemplateField HeaderText="Enviar Recibo">
                                    <FooterTemplate>
                                        <table width="100%">
                                            <tr>
                                                <td class="auto-style9">
                                                    <asp:Label ID="lblLeyTotPagos" runat="server" CssClass="auto-style3" Font-Bold="True" Font-Size="Small" ForeColor="Black" Text="Importe Total: "></asp:Label>
                                                </td>
                                                <td class="izquierda" width="80%">
                                                    <asp:Label ID="lblTotPagos" runat="server" CssClass="auto-style3" Font-Bold="True" ForeColor="Black" Text="0"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="derecha" colspan="2">
                                                    <asp:ImageButton ID="imgBttnReporte" runat="server" ImageUrl="https://sysweb.unach.mx/resources/imagenes/pdf.png" OnClick="imgBttnReporte_Click" />
                                                    <asp:ImageButton ID="imgBttnReporteLote" runat="server" ImageUrl="http://sysweb.unach.mx/resources/imagenes/pdf2.png" OnClick="imgBttnReporteLote_Click" />
                                                    &nbsp;<asp:ImageButton ID="imgBttnExportar" runat="server" ImageUrl="https://sysweb.unach.mx/resources/imagenes/excel.png" OnClick="imgBttnExportar_Click" />
                                                </td>
                                            </tr>
                                        </table>
                                    </FooterTemplate>
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
                                <asp:BoundField DataField="FACT_MATRICULA" />
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
        <div class="row">
            <div class="col">
                <usr:uCCorreo ID="PnlCorreo" runat="server" />
            </div>
        </div>
    </div>
</asp:Content>
