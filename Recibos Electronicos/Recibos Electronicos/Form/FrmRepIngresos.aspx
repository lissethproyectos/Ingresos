<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FrmRepIngresos.aspx.cs" Inherits="Recibos_Electronicos.Form.FrmRepIngresos" %>

<%@ Register Assembly="CapaNegocio" Namespace="CapaNegocio" TagPrefix="customControl" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
     <script src="../Scripts/DataTables/jquery.dataTables.min.js"></script>
    <link href="../Content/DataTables/css/jquery.dataTables.min.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container-fluid">
        <div class="row">
            <div class="col-md-2">
                Dependencia
            </div>
            <div class="col-md-10">
                <asp:DropDownList ID="ddlDependencia" runat="server" Width="100%">
                </asp:DropDownList>
            </div>
        </div>
        <div class="row" id="rowCiclo" runat="server" visible="false">
            <div class="col-md-2">
                <asp:UpdatePanel ID="UpdatePanel48" runat="server">
                    <ContentTemplate>
                        <asp:Label ID="lblCiclo" runat="server" Text="Ciclo Escolar:" Visible="False"></asp:Label>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
            <div class="col-md-4">
                <asp:UpdatePanel ID="UpdatePanel47" runat="server">
                    <ContentTemplate>
                        <customControl:GroupDropDownList ID="ddlCiclo" runat="server" AutoPostBack="True" Visible="False" Width="100%">
                        </customControl:GroupDropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
        <div class="row">
            <div class="col-md-2">
                <asp:Label ID="lblFecha_Factura_Ini" runat="server" Text="Fecha Inicial"></asp:Label>
            </div>
            <div class="col-md-2">
                <asp:UpdatePanel ID="UpdatePanel44" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txtFecha_Factura_Ini" runat="server" AutoPostBack="True" CssClass="box" onkeyup="javascript:this.value='';" Width="95px"></asp:TextBox>
                        <ajaxToolkit:CalendarExtender ID="CalendarExtenderIni" runat="server" TargetControlID="txtFecha_Factura_Ini" PopupButtonID="imgCalendarioIni" />
                        <asp:ImageButton ID="imgCalendarioIni" runat="server" ImageUrl="https://sysweb.unach.mx/resources/imagenes/calendario.gif" />
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
            <div class="col-md-2">
                <asp:Label ID="lblFecha_Factura_Fin" runat="server" Text="Fecha Final"></asp:Label>
            </div>
            <div class="col-md-2">
                <asp:UpdatePanel ID="UpdatePanel45" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txtFecha_Factura_Fin" runat="server" AutoPostBack="True" CssClass="box" onkeyup="javascript:this.value='';" Style="margin-left: 0px" Width="95px"></asp:TextBox>
                        <ajaxToolkit:CalendarExtender ID="CalendarExtenderFin" runat="server" PopupButtonID="imgCalendarioFin" TargetControlID="txtFecha_Factura_Fin" />
                        <asp:ImageButton ID="imgCalendarioFin" runat="server" ImageUrl="https://sysweb.unach.mx/resources/imagenes/calendario.gif" />

                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        
            <div class="col-md-1">
                <asp:Label ID="lblNivel" runat="server" Text="Nivel"></asp:Label>
            </div>
            <div class="col-md-2">
                <asp:UpdatePanel ID="UpdatePanel41" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="DDLNivel" runat="server" Width="100%" OnSelectedIndexChanged="DDLNivel_SelectedIndexChanged">
                        </asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
            <div class="col-md-1">
                <asp:UpdatePanel ID="UpdatePanel49" runat="server">
                    <ContentTemplate>
                        <%--<asp:ImageButton ID="imgBttnBuscar" runat="server" ImageUrl="https://sysweb.unach.mx/resources/imagenes/buscar.png" OnClick="imgBttnBuscar_Click" />--%>
                        <asp:LinkButton ID="linBttnBuscar" CssClass="btn btn-primary" runat="server" OnClick="linBttnBuscar_Click"><i class="fa fa-search" aria-hidden="true"></i> Buscar</asp:LinkButton>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
          <%--  <div class="col-md-2">
                <asp:Label ID="lblOrdenar" runat="server" Text="Ordenar por"></asp:Label>
            </div>
            <div class="col-md-4">
                <asp:UpdatePanel ID="UpdatePanel46" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddlOrden" runat="server" OnSelectedIndexChanged="ddlOrden_SelectedIndexChanged">
                            <asp:ListItem Value="1">Clave</asp:ListItem>
                            <asp:ListItem Value="2">Descripción</asp:ListItem>
                        </asp:DropDownList>

                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>--%>
      
            <%--<div class="col-md-1">
                <asp:Label ID="lblBuscar" runat="server" Text="Buscar" Width="100%"></asp:Label>
            </div>
            <div class="col-md-4">
                <asp:UpdatePanel ID="UpdatePanel50" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txtBuscar" runat="server" Width="100%" PlaceHolder="Por Clave ó Descripción"></asp:TextBox>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>--%>
            
        </div>
        <div class="row">
            <div class="col text-center">
                <asp:UpdateProgress ID="UpdateProgress4" runat="server" AssociatedUpdatePanelID="UpdatePanel42">
                    <ProgressTemplate>
                        <asp:Image ID="img1" runat="server" Height="50px" ImageUrl="~/Imagenes/loader2.gif" Width="50px" />
                    </ProgressTemplate>
                </asp:UpdateProgress>
            </div>
        </div>
        <div class="row">
           <%-- <div class="col-md-2">
                <asp:Label ID="lblConceptos" runat="server" Text="Conceptos"></asp:Label>
            </div>--%>
            <div class="col">
                <asp:UpdatePanel ID="UpdatePanel42" runat="server">
                    <ContentTemplate>
<%--                        <div id="divGrid" runat="server" style="border-style: none none solid none; overflow: auto; height: 230px; border-bottom-color: #D9D9D9; border-bottom-width: 1px;">--%>
                            <asp:GridView ID="grvConceptos" runat="server" AutoGenerateColumns="False" CssClass="sem table table-striped table-bordered table-hover" EmptyDataText="No se encontro ningún registro" OnPageIndexChanging="grvConceptos_PageIndexChanging" Width="100%" DataKeyNames="ClaveConcepto">
                                <Columns>
                                    <asp:BoundField DataField="ClaveConcepto" HeaderText="Cve">
                                        <HeaderStyle HorizontalAlign="Left" />
                                        <ItemStyle HorizontalAlign="Left" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Descripcion" HeaderText="Descripción">
                                        <HeaderStyle HorizontalAlign="Left" />
                                        <ItemStyle HorizontalAlign="Left" Width="70%" />
                                    </asp:BoundField>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            <asp:CheckBox ID="chkTodosConc" runat="server" OnCheckedChanged="chkTodosConc_CheckedChanged" AutoPostBack="True" />
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:CheckBox ID="chkConcepto" runat="server" Checked='<%# Bind("Habilita") %>' />
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                </Columns>
                                <FooterStyle CssClass="enc" />
                                <HeaderStyle CssClass="enc" />
                                <PagerStyle CssClass="enc" HorizontalAlign="Center" />
                                <SelectedRowStyle CssClass="sel" />
                            </asp:GridView>
<%--                        </div>--%>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
        <div class="row">
            <div class="col text-right">
                <asp:UpdatePanel ID="UpdatePanel43" runat="server">
                    <ContentTemplate>
                        <asp:ImageButton ID="imgBttnExportar" runat="server" ImageUrl="https://sysweb.unach.mx/resources/imagenes/excel.png" OnClick="imgBttnExportar_Click" />
                        &nbsp;<asp:ImageButton ID="imgBttnReporte" runat="server" ImageUrl="https://sysweb.unach.mx/resources/imagenes/pdf.png" OnClick="imgBttnReporte_Click" />
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
    </div>


    <script type="text/javascript">         
        function Conceptos() {
            $('#<%= grvConceptos.ClientID %>').prepend($("<thead></thead>").append($('#<%= grvConceptos.ClientID %>').find("tr:first"))).DataTable({
                "destroy": true,
                "stateSave": true
            });
        }
    </script>
</asp:Content>
