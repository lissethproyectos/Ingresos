<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmInicio.aspx.cs" Inherits="Recibos_Electronicos.frmInicio" %>

<%@ Register TagName="uCCorreo" TagPrefix="usr" Src="EnviarCorreo.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .scroll_monitor {
            height: 320px;
            overflow: auto;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container-fluid">
        <div class="row">
            <div class="col-sm-3">
                <div class="card">
                    <div class="scroll_monitor">
                        <div class="card-body" style="height: 320px">
                            <h5 style="color: #3c4044;"><i class="fa fa-sticky-note" aria-hidden="true"></i>Solicitudes de exenciones ó descuentos</h5>
                            <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                                <ContentTemplate>
                                    <asp:Label ID="lblMsg_Observaciones" runat="server" Visible="False"></asp:Label>
                                    <asp:GridView ID="grvStatus" runat="server" AllowPaging="True" AutoGenerateColumns="False" PageSize="5" Width="100%" CssClass="mGrid" EmptyDataText="Sin solicitudes"
                                        ShowHeaderWhenEmpty="True">
                                        <Columns>
                                            <asp:BoundField DataField="Dependencia" HeaderText="Revisar">
                                                <HeaderStyle Font-Bold="True" Font-Size="14px" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="TotalMatricula" HeaderText="Tot">
                                                <HeaderStyle Font-Bold="True" Font-Size="14px" />
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:BoundField>
                                        </Columns>
                                        <FooterStyle CssClass="enc" />
                                        <PagerStyle CssClass="enc" HorizontalAlign="Center" />
                                        <RowStyle Font-Bold="False" />
                                        <SelectedRowStyle CssClass="sel" />
                                        <HeaderStyle CssClass="enc" />
                                        <AlternatingRowStyle CssClass="alt" />
                                    </asp:GridView>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                    </div>
                    <div class="card-footer text-muted">
                        <a href="Form/frmExentos.aspx" class="btn btn-warning btn-rounded">Continuar</a>
                    </div>
                </div>
            </div>
            <div class="col-sm-6">
                <div class="card">
                    <div class="scroll_monitor">
                        <div class="card-body" style="height: 320px">
                            <h5 style="color: #3c4044;"><i class="fa fa-television" aria-hidden="true"></i>Monitor</h5>
                            <asp:UpdatePanel ID="UpdatePanelGridMonitor" runat="server">
                                <ContentTemplate>
                                    <asp:GridView ID="grdMonitor" runat="server" AllowPaging="True"
                                        AutoGenerateColumns="False" OnPageIndexChanging="grdMonitor_PageIndexChanging"
                                        Width="100%" PageSize="20" CssClass="mGrid" CellSpacing="1">
                                        <Columns>
                                            <asp:BoundField DataField="Descripcion" HeaderText="REVISAR">
                                                <HeaderStyle Font-Bold="True" Font-Size="14px" />
                                            </asp:BoundField>
                                        </Columns>
                                        <FooterStyle CssClass="enc" />
                                        <PagerStyle CssClass="enc" HorizontalAlign="Center" />
                                        <RowStyle Font-Bold="False" />
                                        <SelectedRowStyle CssClass="sel" />

                                        <HeaderStyle CssClass="enc" />
                                        <AlternatingRowStyle CssClass="alt" />
                                    </asp:GridView>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                            <div class="text-center">
                                <asp:UpdateProgress ID="updPnlCC" runat="server" AssociatedUpdatePanelID="UpdatePanelGridMonitor">
                                    <ProgressTemplate>
                                        <asp:Image ID="img5" runat="server" AlternateText="Espere un momento, por favor.." Height="50px" ImageUrl="https://sysweb.unach.mx/resources/imagenes/ajax_loader_gray_512.gif" ToolTip="Espere un momento, por favor.." />
                                    </ProgressTemplate>
                                </asp:UpdateProgress>
                            </div>
                        </div>

                    </div>
                    <div class="card-footer text-muted">
                        <a href="Principal.aspx" class="btn btn-warning btn-rounded">Continuar</a>
                    </div>
                </div>
            </div>
            <div class="col-sm-3">
                <div class="card">
                    <div class="scroll_monitor">
                        <div class="card-body" style="height: 320px">
                            <h5 style="color: #3c4044;"><i class="fa fa fa-money" aria-hidden="true"></i>Bancos cargados</h5>
                            <asp:UpdatePanel ID="UpdatePanel34" runat="server">
                                <ContentTemplate>
                                    <asp:GridView ID="grdStatus_Carga_Bancos" runat="server" AutoGenerateColumns="False" CssClass="mGrid" Width="100%">
                                        <Columns>
                                            <asp:BoundField DataField="Etiqueta" HeaderText="BANCO" />
                                            <asp:BoundField DataField="EtiquetaDos" />
                                            <asp:BoundField DataField="EtiquetaCuatro" HeaderText="Tot Recibos" />
                                        </Columns>
                                        <FooterStyle CssClass="enc" />
                                        <PagerStyle CssClass="enc" HorizontalAlign="Center" />
                                        <RowStyle BackColor="White" />
                                        <SelectedRowStyle CssClass="sel" />
                                        <HeaderStyle CssClass="enc" />
                                        <AlternatingRowStyle CssClass="alt" BackColor="#CCCCCC" />
                                    </asp:GridView>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                    </div>
                    <div class="card-footer text-muted">
                        <br />
                    </div>
                </div>
            </div>
        </div>

        <%--<div class="row"><div class="col text-right">
            <a href="Inicio.aspx" class="btn btn-primary btn-rounded" style="font-size:14px;">Comprobante Oficial</a>
                         </div></div>--%>
    </div>




    <script type="text/javascript" src="Scripts/jsQR.js"></script>
    <script type="text/javascript" src="Scripts/QRModel.js"></script>
</asp:Content>
