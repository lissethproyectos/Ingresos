<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="prueba.aspx.cs" Inherits="Recibos_Electronicos.prueba" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <title>Bootstrap 101 Template</title>
    <!-- Bootstrap -->
    <link href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.2/css/bootstrap.min.css" rel="stylesheet">
    <!-- HTML5 shim and Respond.js for IE8 support of HTML5 elements and media queries -->
    <!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
    <!--[if lt IE 9]>
      <script src="https://oss.maxcdn.com/html5shiv/3.7.2/html5shiv.min.js"></script>
      <script src="https://oss.maxcdn.com/respond/1.4.2/respond.min.js"></script>
    <![endif]-->
</head>
<body>
<ContentTemplate>
<asp:GridView ID="grdCatalogos" runat="server" AutoGenerateColumns="False" CssClass="mGrid" Width="100%" OnRowCancelingEdit="grdCatalogos_RowCancelingEdit1" OnRowEditing="grdCatalogos_RowEditing1" OnRowUpdating="grdCatalogos_RowUpdating1" OnRowDeleting="grdCatalogos_RowDeleting" OnSelectedIndexChanged="grdCatalogos_SelectedIndexChanged">
                                                            <Columns>
                                                                <asp:BoundField HeaderText="CVE" DataField="Etiqueta" />
                                                                <asp:BoundField HeaderText="DESCRIPCIÓN" DataField="EtiquetaDos">
                                                                    <ItemStyle Width="75%" />
                                                                </asp:BoundField>
                                                                <asp:TemplateField HeaderText="STATUS">
                                                                    <EditItemTemplate>
                                                                        <asp:TextBox ID="txtStatus" runat="server" Width="50px" Text='<%# Bind("EtiquetaTres") %>'></asp:TextBox>
                                                                    </EditItemTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("EtiquetaTres") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField>
                                                                    <ItemTemplate>
                                                                        <asp:LinkButton ID="linkBttnEliminarCat" runat="server" CommandName="Delete" Width="100%" OnClientClick="return confirm('¿Desea eliminar el registro?');">Eliminar</asp:LinkButton>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField ShowHeader="False">
                                                                    <HeaderTemplate>
                                                                        <button class="btn btn-primary" data-target="#modalCat" data-toggle="modal" type="button">
                                                                            Agregar
                                                                        </button>
                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Select" Text="Editar"></asp:LinkButton>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                            </Columns>
                                                            <FooterStyle CssClass="enc" />
                                                            <PagerStyle CssClass="enc" HorizontalAlign="Center" />
                                                            <SelectedRowStyle CssClass="sel" />
                                                            <HeaderStyle CssClass="enc" />
                                                            <AlternatingRowStyle CssClass="alt" />
                                                        </asp:GridView></body>
</html>
