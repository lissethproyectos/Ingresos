<%@ Page Title="Página principal" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="Recibos_Electronicos._Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div class="container">
        <div class="row">
            <div class="col-md-3">
                <%--<div class="card text-white bg-info mb-3" style="max-width: 20rem;">
                    <div class="card-header">Administración</div>
                    <div class="card-body">
                        <h5 class="card-title">Info Panel title</h5>
                        <p class="card-text text-white">Some quick example text to build on the panel title and make up the bulk of the panel's content.</p>
                    </div>
                </div>--%>
            </div>
            <div class="col-md-9">
                <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                    <ContentTemplate>
                        <asp:TreeView ID="treeMenu" runat="server">
                            <ParentNodeStyle Font-Bold="True" ForeColor="#666666" />
                            <RootNodeStyle Font-Bold="True" Font-Size="Large" ImageUrl="~/Imagenes/mnu.png" />
                        </asp:TreeView>

                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
    </div>
</asp:Content>
