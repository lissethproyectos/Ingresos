<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FrmCursos.aspx.cs" Inherits="Recibos_Electronicos.Form.FrmCursos" %>

<%@ Register Assembly="CapaNegocio" Namespace="CapaNegocio" TagPrefix="customControl" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script src="../Scripts/jquery/jquery-3.1.1.min.js"></script>
    <script src="../Scripts/select2/js/select2.min.js"></script>
    <script src="https://ajax.googleapis.com/ajax/libs/angularjs/1.4.8/angular.min.js"></script>
    <link href="../Scripts/select2/css/select2.min.css" type="text/css" rel="stylesheet" />
    <script type="text/javascript">
        function FiltMat() {
            $(".select2").select2();
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <asp:UpdatePanel ID="updPnlMlv" runat="server">
        <ContentTemplate>
            <div class="container-fluid">
                <div class="row">
                    <div class="col-md-2">Dependencia</div>
                    <div class="col-md-9">
                        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                            <ContentTemplate>
                                <asp:DropDownList ID="ddlDependencia" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlDependencia_SelectedIndexChanged" Width="100%">
                                </asp:DropDownList>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-2">Ciclo Escolar</div>
                    <div class="col-md-4">
                        <customControl:GroupDropDownList ID="ddlCiclo" runat="server">
                        </customControl:GroupDropDownList>


                    </div>
                    <div class="col-md-2">Estatus</div>
                    <div class="col-md-4">
                        <asp:UpdatePanel ID="updPnlStatus" runat="server">
                            <ContentTemplate>
                                <asp:RadioButtonList ID="rdoListStatus" runat="server" AutoPostBack="True" Height="16px" OnSelectedIndexChanged="rdoListStatus_SelectedIndexChanged" RepeatDirection="Horizontal">
                                    <asp:ListItem Selected="True" Value="A">Activo</asp:ListItem>
                                    <asp:ListItem Value="B">Baja</asp:ListItem>
                                </asp:RadioButtonList>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </div>
            </div>
            <asp:MultiView ID="MultiView1" runat="server">
                <asp:View ID="View1" runat="server">
                    <div class="container-fluid">
                        <div class="row">
                            <div class="col-md-11">
                                <asp:TextBox ID="txtBusca" runat="server" Width="98%"></asp:TextBox>
                            </div>
                            <div class="col-md-1">
                                <asp:UpdatePanel ID="updPnlBuscar" runat="server">
                                    <ContentTemplate>
                                        <asp:ImageButton ID="imgBttnBuscar" runat="server" ImageUrl="https://sysweb.unach.mx/resources/imagenes/buscar.png" OnClick="imgBttnBuscar_Click" />
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col text-center">
                                <asp:UpdateProgress ID="updPrgBuscar" runat="server" AssociatedUpdatePanelID="updPnlBuscar">
                                    <ProgressTemplate>
                                        <asp:Image ID="imgBuscar" runat="server" AlternateText="Espere un momento, por favor.." Height="50px" ImageUrl="https://sysweb.unach.mx/resources/imagenes/ajax_loader_gray_512.gif" ToolTip="Espere un momento, por favor.." />
                                    </ProgressTemplate>
                                </asp:UpdateProgress>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col text-center">
                                <asp:UpdateProgress ID="updPrGrid" runat="server" AssociatedUpdatePanelID="updPnlGrid">
                                    <ProgressTemplate>
                                        <asp:Image ID="imgGrid" runat="server" AlternateText="Espere un momento, por favor.." Height="50px" ImageUrl="https://sysweb.unach.mx/resources/imagenes/ajax_loader_gray_512.gif" ToolTip="Espere un momento, por favor.." />
                                    </ProgressTemplate>
                                </asp:UpdateProgress>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <asp:UpdatePanel ID="updPnlGrid" runat="server">
                                    <ContentTemplate>
                                        <asp:GridView ID="grvCursos" runat="server" AllowPaging="True" AutoGenerateColumns="False" CssClass="mGrid" OnPageIndexChanging="grvCursos_PageIndexChanging" OnRowDeleting="grvCursos_RowDeleting" OnSelectedIndexChanging="grvCursos_SelectedIndexChanging" Width="100%" EmptyDataText="No hay cursos de verano registrados." ShowHeaderWhenEmpty="True">
                                            <Columns>
                                                <asp:BoundField DataField="Dependencia" HeaderText="Dependencia" />
                                                <asp:BoundField DataField="DescCarrera" HeaderText="Carrera" />
                                                <asp:BoundField DataField="DescMateria" HeaderText="Materia" />
                                                <asp:BoundField DataField="DescConcepto" HeaderText="Concepto" />
                                                <asp:BoundField DataField="semestre" HeaderText="Semestre">
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="Importe" HeaderText="Importe" DataFormatString="{0:c}">
                                                    <ItemStyle HorizontalAlign="Right" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="IdCurso" HeaderText="Id" />
                                                <asp:CommandField SelectText="Editar" ShowSelectButton="True" ButtonType="Image" SelectImageUrl="https://sysweb.unach.mx/resources/Imagenes/edit.png">
                                                    <ItemStyle HorizontalAlign="Right" />
                                                </asp:CommandField>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        <asp:Button ID="bttnNuevo" runat="server" CssClass="btn btn-blue-grey" Font-Size="XX-Small" OnClick="bttnNuevo_Click" Text="AGREGAR" />
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:ImageButton ID="imgBttnCancelar" runat="server" CommandName="Delete" ImageUrl="https://sysweb.unach.mx/resources/Imagenes/del.png" OnClientClick="return confirm('¿Desea eliminar el registro?');" />
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
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
                </asp:View>
                <asp:View ID="View2" runat="server">
                    <div class="container-fluid">
                        <div class="row">
                            <div class="col-md-2">
                                Programa
                            </div>
                            <div class="col-md-9">
                                <asp:DropDownList ID="ddlPrograma" runat="server" AutoPostBack="True" ClientIDMode="Predictable" OnSelectedIndexChanged="ddlPrograma_SelectedIndexChanged" TabIndex="5" Width="100%">
                                </asp:DropDownList>
                            </div>
                            <div class="col-md-1">
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator23" runat="server" ControlToValidate="ddlPrograma" CssClass="MsjError" ErrorMessage="*Requerido" InitialValue="0" ValidationGroup="guardar"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-2">Plan</div>
                            <div class="col-md-9">
                                <asp:UpdatePanel ID="updPnlPlan" runat="server">
                                    <ContentTemplate>
                                        <asp:DropDownList ID="ddlPlan" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlPlan_SelectedIndexChanged" Width="100%">
                                        </asp:DropDownList>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                            <div class="col-md-1">
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator30" runat="server" ControlToValidate="ddlPlan" CssClass="MsjError" ErrorMessage="*Requerido" InitialValue="0" ValidationGroup="guardar"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-2">
                                Materia
                            </div>
                            <div class="col-md-9">
                                <asp:UpdatePanel ID="updPnlMateria" runat="server">
                                    <ContentTemplate>
                                        <asp:DropDownList ID="ddlMateria" runat="server" AutoPostBack="True" CssClass="select2" OnSelectedIndexChanged="ddlMateria_SelectedIndexChanged" TabIndex="5" Width="100%">
                                        </asp:DropDownList>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                            <div class="col-md-1">
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator25" runat="server" ControlToValidate="ddlMateria" CssClass="MsjError" ErrorMessage="*Requerido" InitialValue="0" ValidationGroup="guardar"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-2">
                                Optativa
                            </div>
                            <div class="col-md-9">
                                <asp:UpdatePanel ID="updPnlMateriaOpt" runat="server">
                                    <ContentTemplate>
                                        <asp:DropDownList ID="ddlMateria_Opt" runat="server" CssClass="select2" TabIndex="5" Width="100%">
                                        </asp:DropDownList>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-2">Semestre</div>
                            <div class="col-md-4">

                                <asp:DropDownList ID="ddlSemestre" runat="server">
                                    <asp:ListItem Value="0">--Seleccionar--</asp:ListItem>
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

                                <asp:RequiredFieldValidator ID="RequiredFieldValidator24" runat="server" ControlToValidate="ddlSemestre" CssClass="MsjError" ErrorMessage="*Requerido" ValidationGroup="guardar" InitialValue="0"></asp:RequiredFieldValidator>
                            </div>
                            <div class="col-md-2">Importe</div>
                            <div class="col-md-4">
                                <asp:TextBox ID="txtImporte" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator29" runat="server" ControlToValidate="txtImporte" CssClass="MsjError" ErrorMessage="*Requerido" ValidationGroup="guardar"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txtImporte" CssClass="MsjError" ErrorMessage="*Solo Números" ValidationExpression="^(-?\d{0,13}\.\d{0,2}|\d{0,13})$" ValidationGroup="guardar"></asp:RegularExpressionValidator>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-11 text-right">
                                <asp:Button ID="btnGuardar_Nuevo" runat="server" CssClass="btn btn-info" OnClick="btnGuardar_Nuevo_Click" TabIndex="20" Text="GUARDAR Y CONTINUAR" ValidationGroup="guardar" />
                                &nbsp;<asp:Button ID="btnGuardar_Salir" runat="server" CssClass="btn btn-primary" OnClick="btnGuardar_Salir_Click" Text="GUARDAR Y SALIR" ValidationGroup="guardar_conceptos" />
                                &nbsp;<asp:Button ID="btnCancelar" runat="server" CssClass="btn btn-blue-grey" OnClick="btnCancelar_Click" TabIndex="21" Text="SALIR" />
                                &nbsp;&nbsp;
                            </div>
                        </div>
                    </div>
                </asp:View>
            </asp:MultiView>

        </ContentTemplate>
    </asp:UpdatePanel>



</asp:Content>
