<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmCursos2.aspx.cs" Inherits="Recibos_Electronicos.Form.frmCursos2" %>

<%@ Register Assembly="CapaNegocio" Namespace="CapaNegocio" TagPrefix="customControl" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script type="text/javascript">
        function FiltMat() {
            $(".select2").select2();
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container-fluid">
        <div class="row">
            <div class="col-md-2">Dependencia</div>
            <div class="col-md-10">
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
        <div class="row">
            <div class="col">
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
                                <div class="col">
                                    <ajaxToolkit:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="0" Width="100%" CssClass="ajax__myTab" Height="350px">
                                        <ajaxToolkit:TabPanel ID="TabPanel1" runat="server" HeaderText="TabPanel1">
                                            <HeaderTemplate>
                                                (1) Datos Generales
                                            </HeaderTemplate>
                                            <ContentTemplate>
                                                <div class="container-fluid">
                                                    <div class="row">
                                                        <div class="col-md-2">
                                                            Programa
                                                        </div>
                                                        <div class="col-md-10">
                                                            <asp:DropDownList ID="ddlPrograma" runat="server" AutoPostBack="True" ClientIDMode="Predictable" OnSelectedIndexChanged="ddlPrograma_SelectedIndexChanged" TabIndex="5" Width="90%">
                                                            </asp:DropDownList>
                                                            <br />
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator23" runat="server" ControlToValidate="ddlPrograma" CssClass="MsjError" ErrorMessage="*Requerido" InitialValue="0" ValidationGroup="guardar"></asp:RequiredFieldValidator>
                                                        </div>
                                                    </div>
                                                    <div class="row">
                                                        <div class="col-md-2">Plan</div>
                                                        <div class="col-md-10">
                                                            <asp:DropDownList ID="ddlPlan" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlPlan_SelectedIndexChanged" Width="90%">
                                                            </asp:DropDownList>
                                                            <br />
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator30" runat="server" ControlToValidate="ddlPlan" CssClass="MsjError" ErrorMessage="*Requerido" InitialValue="0" ValidationGroup="guardar"></asp:RequiredFieldValidator>
                                                        </div>
                                                    </div>
                                                    <div class="row">
                                                        <div class="col-md-2">
                                                            Materia
                                                        </div>
                                                        <div class="col-md-10">
                                                            <asp:DropDownList ID="ddlMateria" runat="server" AutoPostBack="True" CssClass="select2" OnSelectedIndexChanged="ddlMateria_SelectedIndexChanged" TabIndex="5" Width="90%">
                                                            </asp:DropDownList>
                                                            <br />
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator25" runat="server" ControlToValidate="ddlMateria" CssClass="MsjError" ErrorMessage="*Requerido" InitialValue="0" ValidationGroup="guardar"></asp:RequiredFieldValidator>
                                                        </div>
                                                    </div>
                                                    <div class="row">
                                                        <div class="col-md-2">
                                                            Optativa
                                                        </div>
                                                        <div class="col-md-10">
                                                            <asp:DropDownList ID="ddlMateria_Opt" runat="server" CssClass="select2" TabIndex="5" Width="90%">
                                                            </asp:DropDownList>
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
                                                </caption>
                                                
                                            </ContentTemplate>
                                        </ajaxToolkit:TabPanel>
                                        <%--<ajaxToolkit:TabPanel ID="TabPanel2" runat="server" HeaderText="TabPanel2">
                                            <HeaderTemplate>
                                                (2) Oficios
                                            </HeaderTemplate>
                                            <ContentTemplate>
                                                <table style="width: 100%;">
                                                    <tr>
                                                        <td colspan="3">
                                                            <div class="mensaje_celeste">
                                                                <asp:UpdatePanel ID="UpdatePanel229" runat="server">
                                                                    <ContentTemplate>
                                                                        <table style="width: 100%;">
                                                                            <tr>
                                                                                <td align="left" style="border-width: 0px;" valign="top">
                                                                                    <asp:Label ID="lblArchivos" runat="server" Font-Bold="True" Text="*Solo formatos PDF, JPG Y PNG"></asp:Label>
                                                                                    <asp:FileUpload ID="FileOficio" runat="server" />
                                                                                    <br />
                                                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="FileOficio" ErrorMessage="Archivo incorrecto, debe ser un PDF, JPG, JPEG o PNG" ValidationExpression="(.*?)\.(jpg|JPG|jpeg|JPEG|png|PNG|pdf|PDF)$" ValidationGroup="guardar"></asp:RegularExpressionValidator>
                                                                                    <br />
                                                                                    <asp:HyperLink ID="LinkNombreArchivo" runat="server" Target="_blank">[LinkNombreArchivo]</asp:HyperLink>
                                                                                    &#160;<asp:ImageButton ID="imgBttnEliminar" runat="server" ImageUrl="https://sysweb.unach.mx/resources/imagenes/del.png" OnClick="imgBttnEliminar_Click" OnClientClick="return confirm('¿En realidad desea Eliminar este registro?');" Visible="False" />
                                                                                </td>
                                                                                <td style="border-style: 0; border-color: 0; border-width: 0px; width: 50%" valign="top">
                                                                                    <asp:Button ID="bttnAgregaOficio" runat="server" CssClass="btn btn-blue-grey" Font-Size="Smaller" OnClick="bttnAgregaOficio_Click" Text="ADJUNTAR" Width="100px" />
                                                                                    <br />
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </ContentTemplate>
                                                                    <Triggers>
                                                                        <asp:PostBackTrigger ControlID="bttnAgregaOficio" />
                                                                    </Triggers>
                                                                </asp:UpdatePanel>
                                                            </div>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="auto-style15">&#160;</td>
                                                        <td>&#160;</td>
                                                        <td class="columna3">&#160;</td>
                                                    </tr>
                                                    <tr>
                                                        <td class="auto-style15">&#160;</td>
                                                        <td>&#160;</td>
                                                        <td class="columna3">&#160;</td>
                                                    </tr>
                                                    <tr>
                                                        <td class="auto-style15">&#160;</td>
                                                        <td>&#160;</td>
                                                        <td class="columna3">&#160;</td>
                                                    </tr>
                                                </table>
                                            </ContentTemplate>
                                        </ajaxToolkit:TabPanel>--%>
                                    </ajaxToolkit:TabContainer>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col text-right">
                                    <asp:Button ID="btnGuardar_Nuevo" runat="server" CssClass="btn btn-info" OnClick="btnGuardar_Nuevo_Click" TabIndex="20" Text="GUARDAR Y CONTINUAR" ValidationGroup="guardar" />
                                    &nbsp;<asp:Button ID="btnGuardar_Salir" runat="server" CssClass="btn btn-primary" OnClick="btnGuardar_Salir_Click" Text="GUARDAR Y SALIR" ValidationGroup="guardar_conceptos" />
                                    &nbsp;<asp:Button ID="btnCancelar" runat="server" CssClass="btn btn-blue-grey" OnClick="btnCancelar_Click" TabIndex="21" Text="SALIR" />
                                    &nbsp;&nbsp;
                                </div>
                            </div>
                        </div>
                    </asp:View>

                </asp:MultiView>
            </div>
        </div>
    </div>

</asp:Content>
