<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmExencionesAutomaticas.aspx.cs" Inherits="Recibos_Electronicos.Form.frmExencionesAutomaticas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-md-2">
                Dependencia
            </div>
            <div class="col-md-10">
                <asp:UpdatePanel ID="UpdatePanel11" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddlDependencias" runat="server" AutoPostBack="True" CssClass="select2" OnSelectedIndexChanged="ddlDependencias_SelectedIndexChanged" Width="100%">
                        </asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
        <div class="row">
            <div class="col-md-2">Ciclo Escolar</div>
            <div class="col-md-4">
                <asp:UpdatePanel ID="UpdatePanel8" runat="server">
                    <ContentTemplate>
                        <asp:UpdatePanel ID="UpdatePanel10" runat="server">
                            <ContentTemplate>
                                <asp:DropDownList ID="ddlCiclo" runat="server" AutoPostBack="True" CssClass="auto-style15" OnSelectedIndexChanged="ddlCiclo_SelectedIndexChanged" Width="100%">
                                </asp:DropDownList>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
            <div class="col-md-2">Sindicato</div>
            <div class="col-md-3">
                <asp:UpdatePanel ID="UpdatePanel9" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddlSindicato" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlSindicato_SelectedIndexChanged">
                            <asp:ListItem Value="SINSTA">STAUNACH</asp:ListItem>
                            <asp:ListItem Value="SINSPA">SPAUNACH</asp:ListItem>
                        </asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
            <div class="col-md-1">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlSindicato" ErrorMessage="*Requerido" InitialValue="T" ValidationGroup="ValidaSindicato"></asp:RequiredFieldValidator>
            </div>
        </div>

        <asp:UpdatePanel ID="UpdatePanel4" runat="server">
            <ContentTemplate>
                <asp:ImageButton ID="imgBttnBuscar" runat="server" ImageUrl="https://sysweb.unach.mx/resources/imagenes/buscar.png" OnClick="imgBttnBuscar_Click" ValidationGroup="BuscaAlumnos" Visible="False" />
            </ContentTemplate>
        </asp:UpdatePanel>
        <div class="row">
            <div class="col text-center">
                <asp:UpdateProgress ID="updPrMultiview" runat="server" AssociatedUpdatePanelID="UpdatePanel3">
                    <ProgressTemplate>
                        <asp:Image ID="imgMultiview" runat="server" AlternateText="Espere un momento, por favor.." Height="50px" ImageUrl="https://sysweb.unach.mx/resources/imagenes/ajax_loader_gray_512.gif" ToolTip="Espere un momento, por favor.." />
                    </ProgressTemplate>
                </asp:UpdateProgress>
            </div>
        </div>
        <div class="row">
            <div class="col">
                <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                    <ContentTemplate>
                        <ajaxToolkit:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="0" Width="100%" CssClass="classic-tabs">
                            <ajaxToolkit:TabPanel ID="TabPanel1" runat="server" HeaderText="TabPanel1">
                                <HeaderTemplate>
                                    Exenciones Generadas
                                </HeaderTemplate>
                                <ContentTemplate>
                                    <table style="width: 100%;">
                                        <tr>
                                            <td align="right">
                                                <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                                                    <ContentTemplate>
                                                        <asp:Button ID="bttnExenciones" runat="server" CssClass="btn btn-blue-grey" OnClick="bttnExenciones_Click" Text="Generar Exenciones de Pago" ValidationGroup="ValidaSindicato" />
                                                        &#160;
                                <asp:Button ID="Button1" runat="server" CssClass="btn btn-blue-grey" Text="Borrar Exenciones de Pago" Visible="False" />
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:GridView ID="grdExentos" runat="server" AllowPaging="True" AutoGenerateColumns="False" CssClass="mGrid" EmptyDataText="No se encontro ningún registro" PageSize="20" Width="100%" OnPageIndexChanging="grdExentos_PageIndexChanging">
                                                    <AlternatingRowStyle CssClass="alt" />
                                                    <Columns>
                                                        <asp:BoundField DataField="Matricula" HeaderText="MATRICULA" />
                                                        <asp:BoundField DataField="Nombre" HeaderText="NOMBRE" />
                                                        <asp:BoundField DataField="CicloEscolar" HeaderText="CICLO" />
                                                        <asp:BoundField DataField="Nivel" HeaderText="NIVEL" />
                                                        <asp:BoundField DataField="DescCarrera" HeaderText="CARRERA" />
                                                        <asp:BoundField DataField="TipoDescuento" HeaderText="TIPO DESCUENTO" />
                                                        <asp:BoundField DataField="StatusMatricula" HeaderText="STATUS" />
                                                    </Columns>
                                                    <FooterStyle CssClass="enc" />
                                                    <HeaderStyle CssClass="enc10px" />
                                                    <PagerStyle CssClass="enc" HorizontalAlign="Center" />
                                                    <SelectedRowStyle CssClass="sel" />
                                                </asp:GridView>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="auto-style7">
                                                <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                                                    <ContentTemplate>
                                                        <asp:Label ID="Label5" runat="server" Font-Bold="True" Font-Size="Small" Text="TOTAL EXENCIONES:"></asp:Label>
                                                        <asp:Label ID="lblTotExenciones" runat="server" Font-Bold="True" Text="0"></asp:Label>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="derecha">&nbsp;</td>
                                        </tr>
                                    </table>
                                </ContentTemplate>
                            </ajaxToolkit:TabPanel>
                            <ajaxToolkit:TabPanel ID="TabPanel3" runat="server" HeaderText="TabPanel3">
                                <HeaderTemplate>
                                    Reporte
                                </HeaderTemplate>
                                <ContentTemplate>
                                    <table style="width: 100%;">
                                        <tr>
                                            <td class="auto-style14">Ciclo Escolar Base:</td>
                                            <td>
                                                <asp:Label ID="lblCicloIni" runat="server" Font-Bold="True"></asp:Label>
                                            </td>
                                            <td>&nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td class="auto-style14">Ciclo Escolar Anterior:</td>
                                            <td>
                                                <asp:DropDownList ID="ddlCicloAnt" runat="server" Width="100%">
                                                </asp:DropDownList>
                                            </td>
                                            <td>&nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td class="auto-style14">&nbsp;</td>
                                            <td class="derecha">
                                                <asp:ImageButton ID="imgBttnReporte0" runat="server" ImageUrl="https://sysweb.unach.mx/resources/imagenes/pdf.png" OnClick="imgBttnReporte_Click" />
                                            </td>
                                            <td>&nbsp;</td>
                                        </tr>
                                    </table>
                                </ContentTemplate>
                            </ajaxToolkit:TabPanel>
                            <ajaxToolkit:TabPanel ID="TabPanel2" runat="server" HeaderText="TabPanel2">
                                <HeaderTemplate>
                                    Status del Alumno
                                </HeaderTemplate>
                                <ContentTemplate>
                                    <table style="width: 100%;">
                                        <tr>
                                            <td class="auto-style13">&nbsp;</td>
                                            <td class="auto-style12">&nbsp;</td>
                                            <td>&nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td align="right" class="auto-style13">
                                                <asp:Label ID="lblMatricula" runat="server" Text="Matricula:"></asp:Label>
                                            </td>
                                            <td class="auto-style12">
                                                <asp:TextBox ID="txtMatricula" runat="server"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:Button ID="bttnVerificar" runat="server" CssClass="btn btn-blue-grey" Text="Verificar" OnClick="bttnVerificar_Click" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right" colspan="3">
                                                <div align="center">
                                                    <asp:UpdateProgress ID="updPrMultiview0" runat="server" AssociatedUpdatePanelID="UpdatePanel7">
                                                        <ProgressTemplate>
                                                            <asp:Image ID="imgMultiview0" runat="server" AlternateText="Espere un momento, por favor.." Height="50px" ImageUrl="https://sysweb.unach.mx/resources/imagenes/ajax_loader_gray_512.gif" ToolTip="Espere un momento, por favor.." />
                                                        </ProgressTemplate>
                                                    </asp:UpdateProgress>
                                                </div>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="3" align="center">
                                                <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                                                    <ContentTemplate>
                                                        <asp:GridView ID="grdStatusAlumno" runat="server" AutoGenerateColumns="False" CssClass="mGrid" Width="70%">
                                                            <Columns>
                                                                <asp:BoundField DataField="StatusMatricula" HeaderText="Status" />
                                                                <asp:BoundField DataField="Semestre" HeaderText="Semestre">

                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                </asp:BoundField>

                                                                <asp:BoundField DataField="CicloEscolar" HeaderText="Último Semestre">
                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                </asp:BoundField>
                                                            </Columns>
                                                            <FooterStyle CssClass="enc" />
                                                            <PagerStyle CssClass="enc" HorizontalAlign="Center" />
                                                            <SelectedRowStyle CssClass="sel" />
                                                            <HeaderStyle CssClass="enc10px" />
                                                            <AlternatingRowStyle CssClass="alt" />
                                                        </asp:GridView>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="auto-style13">&nbsp;</td>
                                            <td class="auto-style12">&nbsp;</td>
                                            <td>&nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td class="auto-style13">&nbsp;</td>
                                            <td class="auto-style12">&nbsp;</td>
                                            <td>&nbsp;</td>
                                        </tr>
                                    </table>
                                </ContentTemplate>
                            </ajaxToolkit:TabPanel>

                        </ajaxToolkit:TabContainer>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
    </div>
</asp:Content>
