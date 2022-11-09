<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmInicio.aspx.cs" Inherits="Recibos_Electronicos.frmInicio" %>

<%@ Register TagName="uCCorreo" TagPrefix="usr" Src="EnviarCorreo.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
   <script src="https://cdn.amcharts.com/lib/5/index.js"></script>
<script src="https://cdn.amcharts.com/lib/5/xy.js"></script>
<script src="https://cdn.amcharts.com/lib/5/themes/Animated.js"></script>
    <script src="Scripts/Graficas/ControllerPagos.js"></script>
    <script src="Scripts/Graficas/ModelPagos.js"></script>
    <%--<script src="Scripts/Graficas/kpi.js"></script>--%>
    
    <style type="text/css">
       /* .scroll_monitor {
            height: 450px;
            overflow: auto;
        }*/

        #chartdiv {
            width: 100%;
            height: 450px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container-fluid">
        <div class="row">
            <%--<div class="col-sm-2">
                <div class="card">
                    <div class="scroll_monitor">
                        <div class="card-body">
                            <h5 style="color: #3c4044;"><i class="fa fa-sticky-note" aria-hidden="true"></i>Solicitudes de exenciones ó descuentos</h5>
                            
                        </div>
                    </div>
                    <div class="card-footer text-muted">
                        <a href="Form/frmExentos.aspx" class="btn btn-warning btn-rounded">Continuar</a>
                    </div>
                </div>
            </div>--%>
            <div class="col-sm-6">
                <div class="card">
                    <%--<div class="card-footer text-muted">
                        <a href="Principal.aspx" class="btn btn-warning btn-rounded">Continuar</a>
                    </div>--%>
                    <div class="scroll_monitor">
                        <div class="card-body" style="height: 320px">
                            <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                                <ContentTemplate>
                                    <asp:Label ID="lblMsg_Observaciones" runat="server" Visible="False"></asp:Label>
                                    <asp:GridView ID="grvStatus" runat="server" AllowPaging="True" AutoGenerateColumns="False" PageSize="5" Width="100%" CssClass="mGrid" EmptyDataText="Sin solicitudes"
                                        ShowHeaderWhenEmpty="True">
                                        <Columns>
                                            <asp:BoundField DataField="Dependencia" HeaderText="Revisar Solicitudes">
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

                            <asp:UpdatePanel ID="UpdatePanelGridMonitor" runat="server">
                                <ContentTemplate>
                                    <asp:GridView ID="grdMonitor" runat="server" AllowPaging="True"
                                        AutoGenerateColumns="False" OnPageIndexChanging="grdMonitor_PageIndexChanging"
                                        Width="100%" PageSize="20" CssClass="mGrid" CellSpacing="1">
                                        <Columns>
                                            <asp:BoundField DataField="Descripcion" HeaderText="Revisar Incidencias">
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

                </div>
            </div>
            <div class="col-sm-6">
                <div class="card">
                    <div class="scroll_monitor">
                        <div class="card-body">
                            <div class="row">
                                <div class="col">
                                    <ul class="nav nav-tabs" id="myTab" role="tablist">
                                        <li class="nav-item">
                                            <a class="nav-link active" id="grafica-tab" data-toggle="tab" href="#grafica" role="tab" aria-controls="grafica" aria-selected="true">Resumen de Pagos</a>
                                        </li>
                                        <li class="nav-item">
                                            <a class="nav-link" id="pagos-tab" data-toggle="tab" href="#pagos-siae" role="tab" aria-controls="pagos-siae" aria-selected="false">Pagos Escolares (Licenciatura)</a>
                                        </li>
                                    </ul>
                                    <div class="tab-content" id="myTabContent">
                                        <div class="tab-pane fade show active" id="grafica" role="tabpanel" aria-labelledby="grafica-tab">
                                            <div class="row">
                                                <div class="col-md-4">
                                                    <asp:Label ID="lblNivel" runat="server" Text="" CssClass="font-weight-bold" Font-Size="16px"></asp:Label>                                                    
                                                </div>
                                                 <div class="col-md-4">
                                                    <asp:Label ID="lblNive2" runat="server" Text="" CssClass="font-weight-bold" Font-Size="16px"></asp:Label>
                                                </div>
                                                <div class="col-md-4 text-right">
                                                    <asp:LinkButton ID="linkBttnVerRecibos" runat="server" CssClass="btn btn-warning" OnClick="linkBttnVerRecibos_Click"><i class="fa fa-file"></i> Ver Recibos</asp:LinkButton>
                                                </div>
                                            </div>
                                             <div class="row">
                                                <div class="col text-center">
                                            <div id="precarga"><input type="image" class="center" src="https://sysweb.unach.mx/resources/imagenes/ajax_loader_gray_512.gif" style="width: 50px; height: 50px" /></div>
                                                    </div>
                                            </div>
                                            <div class="row">
                                                <div class="col">
                                                    <div id="chartdiv"></div>
                                                </div>
                                            </div>

                                        </div>
                                        <div class="tab-pane fade" id="pagos-siae" role="tabpanel" aria-labelledby="pagos-siae">
                                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                                <ContentTemplate>
                                                    <asp:GridView ID="grdPagosSIAE" runat="server" CssClass="mGrid" AutoGenerateColumns="False" Width="100%">
                                                        <Columns>
                                                            <asp:BoundField DataField="CICLO_ESCOLAR" HeaderText="CICLO" />
                                                            <asp:BoundField DataField="FACT_CONCEPTOS" HeaderText="CONCEPTO" />
                                                            <asp:BoundField DataField="FACT_TOTAL" DataFormatString="{0:n}" HeaderText="TOT PAGOS">
                                                                <HeaderStyle Font-Bold="True"/>
                                                                <ItemStyle HorizontalAlign="Right" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="FACT_IMPORTE" HeaderText="IMPORTE">
                                                                <HeaderStyle Font-Bold="True"/>
                                                                <ItemStyle HorizontalAlign="Right" Font-Size="16px"   Font-Bold="True" />
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
                                    <%--<asp:Image ID="Image1" runat="server" ImageUrl='~/Imagenes/recibo3.png' Text="No"  Visible='<%# Bind("VISIBLE2") %>'/>--%>
                                </div>
                            </div>

                            <%--<asp:UpdatePanel ID="UpdatePanel34" runat="server">
                                <ContentTemplate>
                                    <asp:GridView ID="grdStatus_Carga_Bancos" runat="server" AutoGenerateColumns="False" CssClass="mGrid" Width="100%" Visible="false">
                                        <Columns>
                                            <asp:BoundField DataField="Etiqueta" HeaderText="Banco">
                                                <ItemStyle Font-Bold="True" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="EtiquetaDos" HeaderText="Fecha Pago" />
                                            <asp:BoundField DataField="EtiquetaCuatro" HeaderText="Total">
                                                <HeaderStyle HorizontalAlign="Right" />
                                                <ItemStyle HorizontalAlign="Right" />
                                            </asp:BoundField>
                                        </Columns>
                                        <FooterStyle CssClass="enc" />
                                        <PagerStyle CssClass="enc" HorizontalAlign="Center" />
                                        <RowStyle BackColor="White" />
                                        <SelectedRowStyle CssClass="sel" />
                                        <HeaderStyle CssClass="enc" />
                                        <AlternatingRowStyle CssClass="alt" BackColor="#CCCCCC" />
                                    </asp:GridView>
                                </ContentTemplate>
                            </asp:UpdatePanel>--%>
                        </div>
                    </div>
                </div>
            </div>
        </div>


        <%--<div class="row"><div class="col text-right">
            <a href="Inicio.aspx" class="btn btn-primary btn-rounded" style="font-size:14px;">Comprobante Oficial</a>
                         </div></div>--%>
    </div>




    <script type="text/javascript" src="Scripts/jsQR2.js"></script>
    <script type="text/javascript" src="Scripts/QRModel.js"></script>
</asp:Content>
