<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmPruebas.aspx.cs" Inherits="Recibos_Electronicos.Form.frmPruebas" %>
<%@ Register TagName="uCCorreo" TagPrefix="usr" Src="~/EnviarCorreo.ascx"%>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:MultiView ID="mltViewFamiliares" runat="server" ActiveViewIndex="0">
                                             <asp:View ID="View4" runat="server">
                                                 <table style="width:100%;">
                                                     <tr>
                                                         <td class="auto-style55">&nbsp;</td>
                                                         <td class="auto-style63">&nbsp;</td>
                                                         <td class="auto-style65">&nbsp;</td>
                                                         <td>&nbsp;</td>
                                                     </tr>
                                                     <tr>
                                                         <td class="auto-style55">&nbsp;</td>
                                                         <td class="auto-style63">
                                                             <asp:Label ID="lblNombreEmpleado1" runat="server" Text="Nombre(s):"></asp:Label>
                                                         </td>
                                                         <td class="auto-style65">
                                                             <asp:TextBox ID="txtNombreEmp" runat="server" Width="100%"></asp:TextBox>
                                                         </td>
                                                         <td class="izquierda">
                                                             <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="txtNombreEmp" ErrorMessage="*Requerido" ValidationGroup="EmpleadoBusca"></asp:RequiredFieldValidator>
                                                         </td>
                                                     </tr>
                                                     <tr>
                                                         <td class="auto-style55" valign="top">&nbsp;</td>
                                                         <td class="auto-style63" valign="top">
                                                             <asp:Label ID="lblNombreEmpleado2" runat="server" Text="Apellidos:"></asp:Label>
                                                         </td>
                                                         <td class="auto-style64" valign="top">
                                                             <asp:TextBox ID="txtApellidosEmp" runat="server" PlaceHolder="Paterno Materno" Width="100%"></asp:TextBox>
                                                             <br />
                                                             <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="txtApellidosEmp" ErrorMessage="*Requerido" ValidationGroup="EmpleadoBusca"></asp:RequiredFieldValidator>
                                                         </td>
                                                         <td class="izquierda" valign="top">
                                                             <asp:ImageButton ID="imgBttnBuscarEmp" runat="server" ImageUrl="https://sysweb.unach.mx/resources/imagenes/buscar.png" OnClick="imgBttnBuscarEmp_Click" ValidationGroup="EmpleadoBusca" />
                                                         </td>
                                                     </tr>
                                                     <tr>
                                                         <td colspan="4" valign="top">&nbsp;</td>
                                                     </tr>
                                                     <tr>
                                                         <td align="center" class="auto-style51" colspan="4" valign="top">
                                                             <asp:Label ID="lblNombreEmpleado3" runat="server" Text="Empleados"></asp:Label>
                                                         </td>
                                                     </tr>
                                                     <tr>
                                                         <td colspan="4" valign="top">
                                                             <asp:GridView ID="grvEmpleados" runat="server" AllowPaging="True" AutoGenerateColumns="False" CssClass="mGrid" EmptyDataText="No se encontro ningun registro." OnSelectedIndexChanged="grvEmpleados_SelectedIndexChanged" PageSize="6" Width="100%">
                                                                 <AlternatingRowStyle CssClass="alt" />
                                                                 <Columns>
                                                                     <asp:BoundField DataField="IdPersona" />
                                                                     <asp:BoundField DataField="TipoPersonaStr" HeaderText="TIPO PERSONAL">
                                                                     <HeaderStyle HorizontalAlign="Left" />
                                                                     <ItemStyle HorizontalAlign="Left" />
                                                                     </asp:BoundField>
                                                                     <asp:BoundField DataField="Dependencia" HeaderText="DEP.">
                                                                     <HeaderStyle HorizontalAlign="Right" />
                                                                     <ItemStyle HorizontalAlign="Right" />
                                                                     </asp:BoundField>
                                                                     <asp:BoundField DataField="Nombre" HeaderText="NOMBRE COMPLETO">
                                                                     <HeaderStyle HorizontalAlign="Left" />
                                                                     <ItemStyle HorizontalAlign="Left" />
                                                                     </asp:BoundField>
                                                                     <asp:BoundField DataField="NoControl" HeaderText="PLAZA">
                                                                     <HeaderStyle HorizontalAlign="Left" />
                                                                     <ItemStyle HorizontalAlign="Left" />
                                                                     </asp:BoundField>
                                                                     <asp:CommandField ShowSelectButton="True" />
                                                                 </Columns>
                                                                 <FooterStyle CssClass="enc" />
                                                                 <HeaderStyle CssClass="enc" />
                                                                 <PagerStyle CssClass="enc" HorizontalAlign="Center" />
                                                                 <SelectedRowStyle CssClass="sel" />
                                                             </asp:GridView>
                                                         </td>
                                                     </tr>
                                                     <tr>
                                                         <td valign="top">&nbsp;</td>
                                                         <td class="auto-style63" valign="top">
                                                             <asp:Label ID="lblHijo" runat="server" Text="Hijo(a):"></asp:Label>
                                                         </td>
                                                         <td align="left" class="auto-style65" valign="top">
                                                             <asp:UpdatePanel ID="UpdatePanel243" runat="server">
                                                                 <ContentTemplate>
                                                                     <asp:DropDownList ID="ddlHijo" runat="server" Width="100%">
                                                                     </asp:DropDownList>
                                                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ControlToValidate="ddlHijo" ErrorMessage="*Requerido" InitialValue="-1" ValidationGroup="Empleado"></asp:RequiredFieldValidator>
                                                                 </ContentTemplate>
                                                             </asp:UpdatePanel>
                                                         </td>
                                                         <td valign="top">
                                                             <asp:ImageButton ID="imgBttnNuevoHijo" runat="server" ImageUrl="https://sysweb.unach.mx/resources/imagenes/nuevo.png" OnClick="imgBttnNuevoHijo_Click" ValidationGroup="Nuevo" />
                                                         </td>
                                                     </tr>
                                                     <tr>
                                                         <td colspan="4" valign="top">&nbsp;</td>
                                                     </tr>
                                                     <tr>
                                                         <td colspan="4" valign="top">
                                                             <asp:DropDownList ID="ddlParentesco" runat="server" Visible="False" Width="100%">
                                                             </asp:DropDownList>
                                                         </td>
                                                     </tr>
                                                     <tr>
                                                         <td align="center" colspan="4">
                                                             <asp:Button ID="bttnSalirEmp" runat="server" Cssclass="btn btn-blue-grey" OnClick="bttnSalirEmp_Click" Text="SALIR" />
                                                                                            &nbsp;<asp:Button ID="bttnAgregarEmp" runat="server" Cssclass="btn btn-blue-grey" OnClick="bttnAgregarEmp_Click" Text="AGREGAR" ValidationGroup="Empleado" />
                                                         </td>
                                                     </tr>
                                                     <tr>
                                                         <td class="auto-style55">&nbsp;</td>
                                                         <td class="auto-style63">&nbsp;</td>
                                                         <td class="auto-style65">&nbsp;</td>
                                                         <td>&nbsp;</td>
                                                     </tr>
                                                     <tr>
                                                         <td class="auto-style55">&nbsp;</td>
                                                         <td class="auto-style63">
                                                             <asp:Label ID="lblNombreEmpleado0" runat="server" Text="Tipo de Personal:" Visible="False"></asp:Label>
                                                         </td>
                                                         <td class="auto-style65">
                                                             <asp:UpdatePanel ID="UpdatePanel237" runat="server">
                                                                 <ContentTemplate>
                                                                     <asp:RadioButtonList ID="rdoBttnTipoPersonal" runat="server" AutoPostBack="True" OnSelectedIndexChanged="rdoBttnTipoPersonal_SelectedIndexChanged" RepeatDirection="Horizontal" Visible="False">
                                                                         <asp:ListItem Value="C">CONFIANZA</asp:ListItem>
                                                                         <asp:ListItem Value="A">ADMINISTRATIVO DE BASE</asp:ListItem>
                                                                         <asp:ListItem Value="D">DOCENTE</asp:ListItem>
                                                                     </asp:RadioButtonList>
                                                                 </ContentTemplate>
                                                             </asp:UpdatePanel>
                                                         </td>
                                                         <td>
                                                             <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="rdoBttnTipoPersonal" ErrorMessage="*Requerido" ValidationGroup="TipoPersonal"></asp:RequiredFieldValidator>
                                                         </td>
                                                     </tr>
                                                     <tr>
                                                         <td class="auto-style55">&nbsp;</td>
                                                         <td class="auto-style63">
                                                             <asp:Label ID="lblNombreEmpleado" runat="server" Text="Dependencia:" Visible="False"></asp:Label>
                                                         </td>
                                                         <td class="auto-style65">
                                                             <asp:UpdatePanel ID="UpdatePanel235" runat="server">
                                                                 <ContentTemplate>
                                                                     <asp:DropDownList ID="ddlDependencia_Empleado" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlDependencia_Empleado_SelectedIndexChanged" ValidationGroup="TipoPersonal" Visible="False" Width="100%">
                                                                     </asp:DropDownList>
                                                                 </ContentTemplate>
                                                             </asp:UpdatePanel>
                                                         </td>
                                                         <td>
                                                             <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="ddlDependencia_Empleado" ErrorMessage="*Requerido" InitialValue="X" ValidationGroup="TipoPersonal"></asp:RequiredFieldValidator>
                                                         </td>
                                                     </tr>
                                                     <tr>
                                                         <td class="auto-style55">&nbsp;</td>
                                                         <td class="auto-style63">
                                                             <asp:Label ID="Label4" runat="server" Text="Empleado:" Visible="False"></asp:Label>
                                                         </td>
                                                         <td class="auto-style65">
                                                             <asp:UpdatePanel ID="UpdatePanel236" runat="server">
                                                                 <ContentTemplate>
                                                                     <asp:DropDownList ID="ddlEmpleado0" runat="server" AutoPostBack="True" Visible="False" Width="100%">
                                                                     </asp:DropDownList>
                                                                 </ContentTemplate>
                                                             </asp:UpdatePanel>
                                                         </td>
                                                         <td align="right">&nbsp;</td>
                                                     </tr>
                                                     <tr>
                                                         <td class="auto-style55">&nbsp;</td>
                                                         <td class="auto-style63">&nbsp;</td>
                                                         <td class="auto-style65">&nbsp;</td>
                                                         <td>&nbsp;</td>
                                                     </tr>
                                                     <tr>
                                                         <td class="auto-style55">&nbsp;</td>
                                                         <td class="auto-style63">&nbsp;</td>
                                                         <td class="auto-style65">&nbsp;</td>
                                                         <td>&nbsp;</td>
                                                     </tr>
                                                     <tr>
                                                         <td class="auto-style55">&nbsp;</td>
                                                         <td class="auto-style63">&nbsp;</td>
                                                         <td class="auto-style65">&nbsp;</td>
                                                         <td>&nbsp;</td>
                                                     </tr>
                                                     <tr>
                                                         <td class="auto-style55">&nbsp;</td>
                                                         <td class="auto-style63">&nbsp;</td>
                                                         <td class="auto-style65">&nbsp;</td>
                                                         <td>&nbsp;</td>
                                                     </tr>
                                                     <tr>
                                                         <td class="auto-style55">&nbsp;</td>
                                                         <td class="auto-style63">&nbsp;</td>
                                                         <td class="auto-style65">&nbsp;</td>
                                                         <td>&nbsp;</td>
                                                     </tr>
                                                 </table>
                                             </asp:View>
                                             <asp:View ID="View5" runat="server">
                                                 <table style="width:100%;">
                                                     <tr>
                                                         <td class="auto-style55" colspan="4">
                                                             <asp:Label ID="lblEtParentesco" runat="server" Text="Familiares"></asp:Label>
                                                         </td>
                                                     </tr>
                                                     <tr>
                                                         <td class="auto-style55">&nbsp;</td>
                                                         <td class="auto-style63">
                                                             <asp:Label ID="lblNombreFamiliar" runat="server" Text="Nombre:"></asp:Label>
                                                         </td>
                                                         <td class="auto-style65">
                                                             <asp:TextBox ID="txtNombreFamiliar" runat="server" Width="90%"></asp:TextBox>
                                                         </td>
                                                         <td class="izquierda">&nbsp;</td>
                                                     </tr>
                                                     <tr>
                                                         <td class="auto-style55">&nbsp;</td>
                                                         <td class="auto-style63">
                                                             <asp:Label ID="lblParentesco" runat="server" Text="Parentesco:"></asp:Label>
                                                         </td>
                                                         <td class="auto-style65">
                                                             <asp:DropDownList ID="ddlParentescoFam" runat="server" Width="90%">
                                                             </asp:DropDownList>
                                                         </td>
                                                         <td class="izquierda">&nbsp;</td>
                                                     </tr>
                                                     <tr>
                                                         <td colspan="4" align="center">
                                                             <asp:Button ID="bttnSalirFam" runat="server" Cssclass="btn btn-blue-grey" Text="SALIR" />
                                                             &nbsp;<asp:Button ID="bttnAgregarFam" runat="server" Cssclass="btn btn-blue-grey" Text="GUARDAR" />
                                                         </td>
                                                     </tr>
                                                     <tr>
                                                         <td class="auto-style55">&nbsp;</td>
                                                         <td class="auto-style63">&nbsp;</td>
                                                         <td class="auto-style65">&nbsp;</td>
                                                         <td class="izquierda">&nbsp;</td>
                                                     </tr>
                                                 </table>
                                             </asp:View>
                                         </asp:MultiView>
</asp:Content>