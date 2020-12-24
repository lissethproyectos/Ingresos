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
            <div class="col text-center">
                <asp:UpdateProgress ID="UpdateProgress4" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
                    <ProgressTemplate>
                        <asp:Image ID="Image85" runat="server" AlternateText="Espere un momento, por favor.." Height="50px" ImageUrl="https://sysweb.unach.mx/resources/imagenes/ajax_loader_gray_512.gif" ToolTip="Espere un momento, por favor.." />
                    </ProgressTemplate>
                </asp:UpdateProgress>
            </div>
        </div>
        <div class="row">
            <div class="col-md-1">
                <asp:Label ID="lblNivel" runat="server" Text="Tipo"></asp:Label>
            </div>
            <div class="col-md-4">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="DDLTipo" runat="server" AutoPostBack="True" CssClass="form-control" OnSelectedIndexChanged="DDLTipo_SelectedIndexChanged">
                            <asp:ListItem Value="SIAE_ACT">VIGENCIA DEL CICLO ACTUAL (SIAE)</asp:ListItem>
                            <asp:ListItem Value="SIAE_ANT">VIGENCIA DEL CICLO ANTERIOR (SIAE)</asp:ListItem>
                            <asp:ListItem Value="SYSWEB">VIGENCIA EN SYSWEB</asp:ListItem>
                        </asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
            <div class="col-md-1">
                SubTipo
            </div>
            <div class="col-md-6">
                <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="DDLSubtipo" runat="server" AutoPostBack="True" CssClass="form-control" OnSelectedIndexChanged="DDLSubtipo_SelectedIndexChanged"></asp:DropDownList>
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
                            <asp:GridView ID="grdVigencias" runat="server" AutoGenerateColumns="False" CssClass="mGrid" Width="100%" OnRowCancelingEdit="grdVigencias_RowCancelingEdit" OnRowEditing="grdVigencias_RowEditing" OnRowUpdating="grdVigencias_RowUpdating" EmptyDataText="No existen vigencias...">
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
                                    <asp:TemplateField HeaderText="CICLO ESCOLAR">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtCicloEscolar" runat="server" Font-Size="Large" Text='<%# Bind("CicloEscolar") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblCicloEscolar" runat="server" Text='<%# Bind("CicloEscolar") %>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="DIAS VIGENCIA">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtDias_Vigencia" runat="server" Font-Size="Large" Text='<%# Bind("diasvigencia") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblDias_Vigencia" runat="server" Font-Bold="True" Font-Size="Large" Text='<%# Bind("diasvigencia") %>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:CommandField ShowEditButton="True" CancelText="CANCELAR" DeleteText="ELIMINAR" EditText="EDITAR" UpdateText="ACTUALIZAR" >
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
        </div>
    </div>
</asp:Content>
