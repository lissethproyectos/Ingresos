<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmGenerarReciboAsp.aspx.cs" Inherits="Recibos_Electronicos.Form.frmGenerarReciboAsp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-md-3">
                Dependencia:
            </div>
            <div class="col-md-9">
                <div class="input-group mb-3">
                    <asp:UpdatePanel ID="updPnlDep" runat="server">
                        <ContentTemplate>
                            <asp:DropDownList ID="ddlDependencias" CssClass="form-control" runat="server" Width="100%" OnSelectedIndexChanged="ddlDependencias_SelectedIndexChanged">
                            </asp:DropDownList>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>

        </div>
    </div>
    <div class="container">
        <div class="row">
            <div class="col-md-3">
                Pagados:
            </div>
            <div class="col-md-3">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <asp:CheckBox ID="chkPagados" runat="server" OnCheckedChanged="chkPagados_CheckedChanged" Text="Si" />
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
            <div class="col-md-3">
                Busqueda:
            </div>
            <div class="col-md-3">
                <asp:TextBox ID="txtBuscar" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="col-md-1">
                <asp:LinkButton runat="server" ID="bttnBuscar" class="btn btn-mini" OnClick="bttnBuscar_Click">Buscar <i class="fa fa-search" aria-hidden="true"></i></asp:LinkButton>
            </div>
        </div>
    </div>
    <div class="container">
        <div class="row">

            <div class="col text-center">
                <asp:UpdatePanel ID="UpdatePanel2" runat="server"></asp:UpdatePanel>
                <asp:GridView ID="grdReferenciasAsp" runat="server" CssClass="mGrid" AutoGenerateColumns="False" AllowPaging="True" Width="100%" OnPageIndexChanging="grdReferenciasAsp_PageIndexChanging">
                    <Columns>
                        <asp:BoundField DataField="ID_FICHA_BANCARIA" HeaderText="ID" />
                        <asp:BoundField DataField="CICLO_ESCOLAR" HeaderText="CICLO" />
                        <asp:BoundField DataField="FACT_DEPENDENCIA" HeaderText="DEPENDENCIA" />
                        <asp:BoundField DataField="FACT_CARRERA" HeaderText="CARRERA" />
                        <asp:BoundField DataField="FACT_MATRICULA" HeaderText="# FICHA" />
                        <asp:BoundField DataField="FACT_REFERENCIA" HeaderText="REFERENCIA" />
                        <asp:BoundField DataField="FACT_FOLIOBANCARIO" HeaderText="FOLIO BANCO" />
                        <asp:BoundField DataField="FACT_BANCO" HeaderText="BANCO" />
                        <asp:BoundField DataField="FACT_CONFIRMADO" HeaderText="PAGADO" />
                        <asp:TemplateField ShowHeader="False">
                            <HeaderTemplate>
                                <asp:Button ID="bttnGenRecibos" runat="server" CssClass="btn btn-info" Text="GENERAR RECIBOS" />
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:Button ID="bttnGenRecibo" runat="server" CausesValidation="False" CommandName="Select" CssClass="btn btn-blue-grey" Text="GENERAR RECIBO" OnClick="bttnGenRecibo_Click" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <FooterStyle CssClass="enc" />
                    <PagerStyle CssClass="enc" HorizontalAlign="Center" />
                    <SelectedRowStyle CssClass="sel" />
                    <HeaderStyle CssClass="enc" />
                    <AlternatingRowStyle CssClass="alt" />
                </asp:GridView>
            </div>
        </div>
    </div>
</asp:Content>
