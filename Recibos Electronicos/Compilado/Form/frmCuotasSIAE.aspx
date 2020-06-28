<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmCuotasSIAE.aspx.cs" Inherits="Recibos_Electronicos.Form.frmCuotasSIAE" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdatePanel ID="updPnlTipo" runat="server">
        <ContentTemplate>
            <div class="container" runat="server" id="containerTipo">
                <div class="row">
                    <div class="col-md-3">
                        Dependencia:
                    </div>

                    <div class="col-md-9">



                        <asp:DropDownList ID="ddlDependenciasFiltro" runat="server" CssClass="form-control">
                        </asp:DropDownList>

                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="ddlDependenciasFiltro" ErrorMessage="RequiredFieldValidator" ValidationGroup="Nuevo">*Requerido</asp:RequiredFieldValidator>


                    </div>
                </div>

                <div class="row">
                    <div class="col-md-3">
                        Tipo:
                    </div>
                    <div class="col-md-6">

                        <asp:DropDownList ID="ddlTipo" runat="server" CssClass="form-control">
                            <asp:ListItem Value="T">--TODOS--</asp:ListItem>
                            <asp:ListItem Value="0">PROPEDEUTICO</asp:ListItem>
                            <asp:ListItem Value="99	">PREUNIVERSITARIO</asp:ListItem>
                            <asp:ListItem Value="98">CURSO DE NIVELACIÓN</asp:ListItem>
                            <asp:ListItem Value="1">INSCRIPCIÓN</asp:ListItem>
                            <asp:ListItem Value="2">REINSCRIPCIÓN	</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <div class="col-md-3">
                        <asp:LinkButton runat="server" ID="bttnBuscar" class="btn btn-mini" OnClick="bttnBuscar_Click">Buscar <i class="fa fa-search" aria-hidden="true"></i>
                        </asp:LinkButton>
                    </div>
                </div>
                <div class="row text-center">
                    <div class="col">
                        <asp:UpdateProgress ID="updPrMultiview" runat="server" AssociatedUpdatePanelID="UpdatePanel3">
                            <ProgressTemplate>
                                <asp:Image ID="imgMultiview" runat="server" AlternateText="Espere un momento, por favor.." Height="50px" ImageUrl="https://sysweb.unach.mx/resources/imagenes/ajax_loader_gray_512.gif" ToolTip="Espere un momento, por favor.." />
                            </ProgressTemplate>
                        </asp:UpdateProgress>
                    </div>
                    <div class="col">
                        <asp:UpdateProgress ID="updPgrCuotas" runat="server" AssociatedUpdatePanelID="updPnlCuotas">
                            <ProgressTemplate>
                                <asp:Image ID="imgCuotas" runat="server" AlternateText="Espere un momento, por favor.." Height="50px" ImageUrl="https://sysweb.unach.mx/resources/imagenes/ajax_loader_gray_512.gif" ToolTip="Espere un momento, por favor.." />
                            </ProgressTemplate>
                        </asp:UpdateProgress>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <div class="container">
        <div class="row">
            <div class="col">
                <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                    <ContentTemplate>
                        <asp:MultiView ID="MultiView1" runat="server">
                            <asp:View ID="View1" runat="server">
                                <div class="container">
                                    <div class="row">
                                        <div class="col">
                                            <div style="overflow-x: auto;">
                                                <asp:UpdatePanel ID="updPnlCuotas" runat="server">
                                                    <ContentTemplate>
                                                        <asp:GridView ID="grvCuotas" runat="server" AutoGenerateColumns="False" CssClass="mGrid" OnSelectedIndexChanged="grvCuotas_SelectedIndexChanged" Width="100%" OnRowDeleting="grvCuotas_RowDeleting" EmptyDataText="No hay cuotas registradas." AllowPaging="True" OnPageIndexChanging="grvCuotas_PageIndexChanging" ShowHeaderWhenEmpty="True">
                                                            <Columns>
                                                                <asp:BoundField DataField="TipoRegistro" HeaderText="TIPO" />
                                                                <asp:BoundField DataField="Descripcion" HeaderText="DEPENDENCIA" />
                                                                <asp:BoundField DataField="Dependencia" ReadOnly="True" />
                                                                <asp:BoundField DataField="CicloEscolar" HeaderText="SEMESTRE" ReadOnly="True">
                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="ImporteConcepto" HeaderText="IMPORTE">
                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="ImporteDetalle" HeaderText="EXTEMPORANEO">
                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="Porcentaje" HeaderText="% DESCUENTO">
                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                </asp:BoundField>
                                                                <asp:TemplateField>
                                                                    <HeaderTemplate>
                                                                        <asp:Button ID="bttnNuevo" runat="server" CssClass="btn btn-blue-grey" Text="AGREGAR" OnClick="bttnNuevo_Click" />
                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:ImageButton ID="imgBttnEditar" runat="server" ImageUrl="https://sysweb.unach.mx/resources/Imagenes/edit.png" Style="width: 20px" OnClick="imgBttnEditar_Click" />
                                                                        &nbsp;<asp:ImageButton ID="imgBttnCancelar" runat="server" CommandName="Delete" ImageUrl="~/Imagenes/del.PNG" OnClick="imgBttnCancelar_Click" OnClientClick="return confirm('¿Desea eliminar el registro?');" Style="width: 20px" />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:BoundField DataField="Anexo" />
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
                            </asp:View>
                            <asp:View ID="View2" runat="server">
                                <div class="container">
                                    <div class="row">
                                        <div class="col-md-3">
                                            Dependencia:
                                        </div>
                                        <div class="col-md-7">
                                            <asp:DropDownList ID="ddlDependencias" runat="server" CssClass="form-control select2" Width="100%">
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="reqDependencia" runat="server" ControlToValidate="ddlDependencias" ErrorMessage="RequiredFieldValidator" InitialValue="00000" ValidationGroup="DatosCuotas">*Requerido</asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-md-3">Semestre:</div>
                                        <div class="col-md-7">
                                            <asp:DropDownList ID="ddlSemestre" runat="server" CssClass="form-control">
                                                <asp:ListItem Value="Z">--Seleccionar--</asp:ListItem>
                                                <asp:ListItem Value="0">Propedeutico</asp:ListItem>
                                                <asp:ListItem Value="98">Curso de Nivelación</asp:ListItem>
                                                <asp:ListItem Value="99">Preuniversitario</asp:ListItem>
                                                <asp:ListItem>1</asp:ListItem>
                                                <asp:ListItem>2</asp:ListItem>
                                                <asp:ListItem>3</asp:ListItem>
                                                <asp:ListItem>4</asp:ListItem>
                                                <asp:ListItem>5</asp:ListItem>
                                                <asp:ListItem>6</asp:ListItem>
                                                <asp:ListItem>7</asp:ListItem>
                                                <asp:ListItem>8</asp:ListItem>
                                                <asp:ListItem>9</asp:ListItem>
                                                <asp:ListItem>10</asp:ListItem>
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlSemestre" ErrorMessage="RequiredFieldValidator" InitialValue="Z" ValidationGroup="DatosCuotas">*Requerido</asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-md-3">
                                            Importe:
                                        </div>
                                        <div class="col-md-7">
                                            <asp:TextBox ID="txtImporte" runat="server" Width="100px" CssClass="form-control"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtImporte" ErrorMessage="RequiredFieldValidator" ValidationGroup="DatosCuotas">*Requerido</asp:RequiredFieldValidator>
                                        </div>
                                    </div>

                                    <div class="row" runat="server" id="rowExtemporaneo">
                                        <div class="col-md-3">
                                            Extemporaneo:
                                        </div>
                                        <div class="col-md-7">
                                            <asp:TextBox ID="txtExtemporaneo" runat="server" Width="100px" CssClass="form-control"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtExtemporaneo" ErrorMessage="RequiredFieldValidator" ValidationGroup="DatosCuotas">*Requerido</asp:RequiredFieldValidator>

                                        </div>

                                    </div>

                                    <div class="row">
                                        <div class="col-md-3">
                                            % de Descuento:
                                        </div>
                                        <div class="col-md-7">
                                            <asp:TextBox ID="txtDescuento" runat="server" Width="100px" CssClass="form-control"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtDescuento" ErrorMessage="RequiredFieldValidator" ValidationGroup="DatosCuotas">*Requerido</asp:RequiredFieldValidator>

                                        </div>
                                    </div>
                                </div>
                                <div class="container text-center">
                                    <div class="row">
                                        <div class="col">

                                            <asp:Button ID="btnGuardar" runat="server" CssClass="btn btn-primary" OnClick="btnGuardar_Click" TabIndex="15" Text="GUARDAR" ValidationGroup="DatosCuotas" />
                                        </div>
                                        <div class="col">
                                            &nbsp;<asp:Button ID="btnCancelar" runat="server" CssClass="btn btn-blue-grey" TabIndex="16" Text="CANCELAR" OnClick="btnCancelar_Click" />
                                        </div>
                                    </div>
                                </div>

                            </asp:View>
                        </asp:MultiView>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
    </div>
</asp:Content>
