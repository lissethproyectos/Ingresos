<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmCuotasPosgrado.aspx.cs" Inherits="Recibos_Electronicos.Form.frmCuotasPosgrado" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-md-1">Escuela</div>
            <div class="col-md-5">
                <asp:DropDownList ID="DDLEscuelas" runat="server" CssClass="form-control" OnSelectedIndexChanged="DDLEscuelas_SelectedIndexChanged"></asp:DropDownList>
            </div>
            <div class="col-md-1">Carrera</div>
            <div class="col-md-5">
                <div class="input-group">
                    <asp:UpdatePanel ID="updPnlCarreras" runat="server">
                        <ContentTemplate>
                            <asp:DropDownList ID="DDLCarreras" runat="server" CssClass="form-control"></asp:DropDownList>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    <asp:LinkButton ID="linkBttnVerCuotas" runat="server" CssClass="btn btn-primary" OnClick="linkBttnVerCuotas_Click">Ver Cuotas</asp:LinkButton>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col">
            </div>
        </div>
        <div class="row">
            <div class="col">
                <asp:UpdatePanel ID="updPnlCuotas" runat="server">
                    <ContentTemplate>
                        <asp:GridView ID="grdCuotas" runat="server" AutoGenerateColumns="False" CssClass="mGrid" Width="100%">
                            <Columns>
                                <asp:BoundField />
                                <asp:TemplateField ShowHeader="False">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Select" CssClass="btn btn-info" Text="Agregar"></asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField ShowHeader="False">
                                    <EditItemTemplate>
                                        <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="True" CommandName="Update" Text="Actualizar"></asp:LinkButton>
                                        &nbsp;<asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancelar"></asp:LinkButton>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Edit" CssClass="btn btn-blue-grey" Text="Editar"></asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField ShowHeader="False">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="LinkButton3" runat="server" CausesValidation="False" CommandName="Delete" CssClass="btn btn-danger" Text="Eliminar"></asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
    </div>
</asp:Content>
