<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FrmAdminFacturas.aspx.cs" Inherits="Recibos_Electronicos.Form.FrmAdminFacturas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="col">
            <div class="row">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <asp:GridView ID="grdArchivos" runat="server" AutoGenerateColumns="False" CssClass="mGrid" OnRowDeleting="grdArchivos_RowDeleting" Width="100%">
                                                                            <Columns>
                                                                                <asp:BoundField DataField="dependencia" HeaderText="Dependencia" />
                                                                                <asp:BoundField DataField="Fecha_Fact_Cja" HeaderText="Fecha" />
                                                                                <asp:BoundField DataField="Folio_Fact_Cja" HeaderText="Folio" />
                                                                                <asp:TemplateField>
                                                                                    <HeaderTemplate>
                                                                                        <i class="fa fa-file-code-o fa-2x" aria-hidden="true"></i>
                                                                                    </HeaderTemplate>
                                                                                    <ItemTemplate>
                                                                                        <asp:HyperLink ID="linkXml" runat="server" NavigateUrl='<%# DataBinder.Eval(Container.DataItem, "Ruta_Xml") %>' Target="_blank" Font-Bold="True">XML</asp:HyperLink>
                                                                                    </ItemTemplate>
                                                                                    <HeaderStyle HorizontalAlign="Center" Width="5%" />
                                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField>
                                                                                    <HeaderTemplate>
                                                                                        <i class="fa fa-file-pdf-o fa-2x" aria-hidden="true"></i>
                                                                                    </HeaderTemplate>
                                                                                    <ItemTemplate>
                                                                                        <asp:HyperLink ID="linkPdf" runat="server" NavigateUrl='<%# DataBinder.Eval(Container.DataItem, "Ruta_Pdf") %>' Target="_blank" Font-Bold="True">PDF</asp:HyperLink>
                                                                                    </ItemTemplate>
                                                                                    <HeaderStyle HorizontalAlign="Center" Width="5%" />
                                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                                </asp:TemplateField>
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
    </div>
</asp:Content>
