<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmCatAspirantes.aspx.cs" Inherits="Recibos_Electronicos.Form.frmCatAspirantes" %>
<%@ Register assembly="CapaNegocio" namespace="CapaNegocio" tagprefix="customControl" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 35%;
        }
       
        .auto-style4 {
            width: 15%;
        }
        .auto-style11 {
            width: 32%;
        }
        .auto-style12 {
            width: 69%;
        }
        .auto-style18 {
            width: 18%;
        }
        .auto-style19 {
            width: 155px;
        }
        .auto-style20 {
            width: 41px;
        }
        .auto-style21 {
            width: 471px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdatePanel ID="UpdatePanel4" runat="server">
        <ContentTemplate>
            <table  class="tabla_contenido">
                <tr>
                    <td class="auto-style18" valign="top">
                        Dependencia:</td>
                    <td valign="top" colspan="3">
                        <asp:DropDownList ID="ddlDependencias" runat="server" CssClass="select2" Width="100%">
                        </asp:DropDownList>
                    </td>
                    <td valign="top">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style18" valign="top">
                        Nivel:</td>
                    <td class="auto-style11" valign="top">
                        <asp:UpdatePanel ID="UpdatePanel10" runat="server">
                            <ContentTemplate>
                                <asp:UpdatePanel ID="UpdatePanel11" runat="server">
                                    <ContentTemplate>
                                        <asp:DropDownList ID="ddlNivel" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlNivel_SelectedIndexChanged" Width="100%">
                                            <asp:ListItem Value="T">--Todos--</asp:ListItem>
                                            <asp:ListItem Value="Z">Seleccionar Nivel</asp:ListItem>
                                            <asp:ListItem Value="L">Licenciatura</asp:ListItem>
                                            <asp:ListItem Value="M">Maestria</asp:ListItem>
                                            <asp:ListItem Value="E">Especialidad</asp:ListItem>
                                            <asp:ListItem Value="D">Doctorado</asp:ListItem>
                                        </asp:DropDownList>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                    <td align="right" class="auto-style4" valign="top">
                        <asp:Label ID="lblCicloEscolar" runat="server" Text="Ciclo Escolar:"></asp:Label>
                    </td>
                    <td valign="top">
                        <asp:DropDownList ID="ddlCicloEscolar" runat="server" AutoPostBack="True" Width="100%" OnSelectedIndexChanged="ddlCicloEscolar_SelectedIndexChanged">
                        </asp:DropDownList>
                    </td>
                    <td valign="top">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlNivel" ErrorMessage="RequiredFieldValidator" InitialValue="Z" ValidationGroup="BuscaAlumnos">*</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr valign="top">
                    <td class="auto-style18" valign="top">
                        Origen:</td>
                    <td colspan="4">
                        <table style="width:100%;">
                            <tr valign="top">
                                <td class="auto-style19" valign="top">
                                    <asp:UpdatePanel ID="UpdatePanel12" runat="server">
                                        <ContentTemplate>
                                            <asp:DropDownList ID="ddlOrigen" runat="server">
                                                <asp:ListItem>TODOS</asp:ListItem>
                                                <asp:ListItem>ACEPTADO</asp:ListItem>
                                                <asp:ListItem>ASPIRANTE</asp:ListItem>
                                            </asp:DropDownList>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </td>
                                <td class="auto-style20">&nbsp;</td>
                                <td class="auto-style21">
                                    <asp:TextBox ID="txtBuscar" runat="server" PlaceHolder="Matricula/Nombre" Width="98%"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:ImageButton ID="imgBttnBuscar" runat="server" ImageUrl="https://sysweb.unach.mx/resources/imagenes/buscar.png" onclick="imgBttnBuscar_Click" ValidationGroup="BuscaAlumnos" />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td align="center" colspan="5">
                        <asp:UpdateProgress ID="updProgCiclo" runat="server" AssociatedUpdatePanelID="UpdatePanel11">
                            <progresstemplate>
                                <asp:Image ID="imgProgCiclo" runat="server" AlternateText="Espere un momento, por favor.." Height="50px" ImageUrl="https://sysweb.unach.mx/resources/imagenes/ajax_loader_gray_512.gif" ToolTip="Espere un momento, por favor.." />
                            </progresstemplate>
                        </asp:UpdateProgress>
                    
                        <asp:UpdateProgress ID="UpdateProgress4" runat="server" AssociatedUpdatePanelID="UpdatePanel4">
                            <progresstemplate>
                                <asp:Image ID="Image85" runat="server" AlternateText="Espere un momento, por favor.." Height="50px" ImageUrl="https://sysweb.unach.mx/resources/imagenes/ajax_loader_gray_512.gif" ToolTip="Espere un momento, por favor.." />
                            </progresstemplate>
                        </asp:UpdateProgress>
                    </td>
                </tr>
                <tr>
                    <td colspan="5">
                        <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                            <ContentTemplate>
                                <asp:GridView ID="grvAspirantes" runat="server" AllowPaging="True" AutoGenerateColumns="False" CssClass="mGrid" EmptyDataText="No se encontro ningún registro" OnPageIndexChanging="grvAlumnosUNACH_PageIndexChanging" PageSize="20" Width="100%" Font-Size="Small">
                                    <Columns>
                                        <asp:BoundField DataField="TipoPersonaStr" HeaderText="Origen" />
                                        <asp:BoundField DataField="Nivel" HeaderText="Nivel">
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
                                        <asp:TemplateField>
                                            <HeaderTemplate>
                                                Ciclo Escolar<asp:UpdatePanel ID="UpdatePanel6" runat="server">
                                                    <ContentTemplate>
                                                        <asp:DropDownList ID="ddlCiclo" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlCiclo_SelectedIndexChanged">
                                                        </asp:DropDownList>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="Label4" runat="server" Text='<%# Bind("CicloEscolar") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="CicloEscolar" HeaderText="Ciclo Escolar">
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Matricula" HeaderText="Mat/Ficha" />
                                        <asp:BoundField DataField="Nombre" HeaderText="Nombre">
                                            <HeaderStyle HorizontalAlign="Left" />
                                            <ItemStyle HorizontalAlign="Left" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Semestre" HeaderText="Semestre">
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Dependencia" HeaderText="Dependencia" />
                                        <asp:BoundField DataField="DescCarrera" HeaderText="Carrera" />
                                        <asp:BoundField DataField="Correo" HeaderText="Correo" />
                                        <asp:BoundField DataField="Password" HeaderText="Password" />
                                        <asp:TemplateField HeaderText="Página">
                                            <ItemTemplate>                                                
                                                <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# Bind("LinkEsquema") %>' Text='<%# Bind("Esquema") %>' Target="_blank"></asp:HyperLink>
                                            </ItemTemplate>
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
                    </td>
                </tr>
                <tr>
                    <td class="auto-style18">&nbsp;&nbsp;</td>
                    <td class="auto-style11">&nbsp;</td>
                    <td class="auto-style4">&nbsp;</td>
                    <td align="right" colspan="2">
                        <asp:ImageButton ID="imgBttnReporte" runat="server" ImageUrl="https://sysweb.unach.mx/resources/imagenes/pdf.png" OnClick="imgBttnReporte_Click" />
                        <asp:ImageButton ID="imgBttnExportar" runat="server" ImageUrl="https://sysweb.unach.mx/resources/imagenes/excel.png" OnClick="imgBttnExportar_Click" />
                    </td>
                </tr>
                <tr>
                    <td class="auto-style18">
                    </td>
                    <td class="auto-style11">&nbsp;</td>
                    <td class="auto-style4">&nbsp;</td>
                    <td class="auto-style12">
                        &nbsp;</td>
                    <td class="auto-style1">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style18">&nbsp;</td>
                    <td class="auto-style11">&nbsp;</td>
                    <td class="auto-style4">&nbsp;</td>
                    <td class="auto-style12">&nbsp;</td>
                    <td class="auto-style1">&nbsp;</td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
