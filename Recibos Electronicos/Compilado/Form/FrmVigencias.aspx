<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FrmVigencias.aspx.cs" Inherits="Recibos_Electronicos.Form.FrmVigencias" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 34px;
        }

        .auto-style2 {
            width: 167px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-md-2">
                <asp:Label ID="lblNivel" runat="server" Text="Nivel:"></asp:Label>
            </div>
            <div class="col-md-10">
                <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="DDLNivel" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DDLNivel_SelectedIndexChanged" CssClass="form-control">
                            <asp:ListItem Value="L">LICENCIATURA (CARRERAS PRESENCIALES)</asp:ListItem>
                            <asp:ListItem Value="V">LICENCIATURA (CARRERAS VIRTUALES)</asp:ListItem>
                            <asp:ListItem Value="N">LENGUAS</asp:ListItem>
                        </asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
    </div>
    <div class="container">
        <div class="row">
            <div class="col">
                <div style="overflow-x: auto;">
                    <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                        <ContentTemplate>
                            <asp:GridView ID="grdVigencias" runat="server" AutoGenerateColumns="False" CssClass="mGrid" Width="100%" OnRowCancelingEdit="grdVigencias_RowCancelingEdit" OnRowEditing="grdVigencias_RowEditing" OnRowUpdating="grdVigencias_RowUpdating">
                                <Columns>
                                    <asp:BoundField DataField="Descripcion" HeaderText="CONCEPTO" ReadOnly="True" />
                                    <asp:TemplateField HeaderText="FECHA INICIAL">
                                        <EditItemTemplate>

                                            <asp:TextBox ID="txtFechaIni" runat="server" Text='<%# Bind("FechaInicial") %>'></asp:TextBox>
                                            <ajaxToolkit:CalendarExtender ID="calExtFechaIni" runat="server" TargetControlID="txtFechaIni" />
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblFechaInicial" runat="server" Text='<%# Bind("FechaInicial") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="FECHA FINAL">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtFechaFin" runat="server" Text='<%# Bind("FechaFinal") %>'></asp:TextBox>
                                            <ajaxToolkit:CalendarExtender ID="calExtFechaFin" runat="server" TargetControlID="txtFechaFin" />

                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblFechaFinal" runat="server" Text='<%# Bind("FechaFinal") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="Periodo" HeaderText="EXTEMPORANEO" ReadOnly="True">
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Nivel" HeaderText="TIPO" ReadOnly="True" />
                                    <asp:BoundField DataField="ClaveConcepto" HeaderText="CONCEPTO" ReadOnly="True" />
                                    <asp:CommandField ShowEditButton="True" CancelText="CANCELAR" DeleteText="ELIMINAR" EditText="EDITAR" UpdateText="ACTUALIZAR" />
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
    </div>
</asp:Content>
