<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FrmAutorizados.aspx.cs" Inherits="Recibos_Electronicos.Form.FrmAutorizados" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">

        .style2
        {
            width: 118px;
        }
        .style1
        {
            width: 392px;
        }
        .auto-style1 {
            width: 208px;
        }
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <table class="tabla_contenido">
        <tr align="center">
            <td align="center">
                <div class="borde">
                    <table width="100%">
                        <tr align="center">
                            <td align="center" colspan="3">
                                <table width="95%">
                                    <tr>
                                        <td align="left" class="style2" valign="top">
                                            <asp:Label ID="lblEmpleado0" runat="server" Text="Evento:"></asp:Label>
                                        </td>
                                        <td align="left" colspan="2">
                                            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                                <ContentTemplate>
                                                    <asp:DropDownList ID="DDLEvento" runat="server" AutoPostBack="True" 
                                                        onselectedindexchanged="DDLEvento_SelectedIndexChanged">
                                                    </asp:DropDownList>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left" class="style2" valign="top">
                                            <asp:Label ID="lblEmpleado" runat="server" Text="Matrícula:"></asp:Label>
                                        </td>
                                        <td align="left" class="style1" valign="top">
                                        <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                                                <ContentTemplate>
                                                    
                                                    
                                                    <table width="100%"><tr><td class="auto-style1" valign="top"><asp:TextBox ID="txtMatricula" runat="server" AutoPostBack="True" 
                                                        CssClass="cuadros" ontextchanged="txtMatricula_TextChanged" Width="100%"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtMatricula" ErrorMessage="RequiredFieldValidator" ValidationGroup="BuscaMatricula">*Requerido</asp:RequiredFieldValidator>
                                                        </td><td valign="top"><asp:ImageButton ID="imgBttnBuscaMatricula" runat="server" 
                                                        ImageUrl="https://sysweb.unach.mx/resources/imagenes/buscar.png" 
                                                        onclick="imgBttnBuscaMatricula_Click" ValidationGroup="BuscaMatricula" /></td></tr></table>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </td>
                                        <td align="left">
                                            <asp:CheckBox ID="chkExterno1" runat="server" AutoPostBack="True" 
                                                oncheckedchanged="chkExterno_CheckedChanged" Text="Externo" 
                                                Visible="False" />
                                            <asp:CheckBox ID="chkActivo" runat="server" Checked="True" Enabled="False" 
                                                Text="Activo" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left" class="style2" valign="top">
                                            <asp:Label ID="lblUsuario" runat="server" Text="Nombre:"></asp:Label>
                                        </td>
                                        <td align="left" valign="top" width="35%">
                                            <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                                                <ContentTemplate>
                                                    <asp:TextBox ID="txtNombre" 
    runat="server" CssClass="cuadros" Enabled="False" 
                                                Width="100%"></asp:TextBox>
                                                    <br />
                                                    <asp:RequiredFieldValidator ID="RFVUsuario" runat="server" 
                                                        ControlToValidate="txtNombre" ErrorMessage="*Requerido" ForeColor="Red" 
                                                        ValidationGroup="matricula"></asp:RequiredFieldValidator>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </td>
                                        <td align="left" valign="top">
                                            <asp:Button ID="btnAgregar" runat="server" onclick="btnAgregar_Click" 
                                                Text="AGREGAR" Cssclass="btn btn-info" 
                                                ValidationGroup="matricula" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left" class="style2">
                                            &nbsp;</td>
                                        <td align="left" colspan="2">
                                            &nbsp;</td>
                                    </tr>
                                </table>
                                &nbsp;
                                <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                                    <ContentTemplate>
                                        <asp:Label ID="lblMsj" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                        </tr>
                        <tr>
                            <td align="center">
                                <asp:Label ID="lblActivo1" runat="server" Font-Bold="True" ForeColor="#63603B">Matrículas Autorizadas:</asp:Label>
                                <asp:Label ID="lblTotal" runat="server" Font-Bold="True" Font-Size="Medium" 
                                    ForeColor="#63603B"></asp:Label>
                            </td>
                            <td align="center">
                                <asp:Label ID="lblActivo0" runat="server" Font-Bold="True" ForeColor="#63603B">Activos:</asp:Label>
                                <asp:Label ID="lblActivo" runat="server" Font-Bold="True" Font-Size="Medium" 
                                    ForeColor="#4985EB"></asp:Label>
                            </td>
                            <td align="center">
                                <asp:Label ID="lblSuspendido0" runat="server" Font-Bold="True" 
                                    ForeColor="#63603B">Suspendidos:</asp:Label>
                                <asp:Label ID="lblSuspendido" runat="server" Font-Bold="True" 
                                    Font-Size="Medium" ForeColor="#FF9900"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="center" colspan="3">
        <%--                     <script type="text/javascript">
                                 function RefreshUpdatePanel() {

                                     __doPostBack('<%= txtBuscar.ClientID %>', '');


                                 };
                                     </script> --%>       
                               
                                        <table style="width:95%;">
                                            <tr>
                                                <td>
                                                    &nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td align="left">
                                                
                                                    <div class="input-group">
                                                    <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                                                    <ContentTemplate>                                                   
                                                        <asp:TextBox ID="txtBuscar" runat="server" AutoPostBack="True" 
                                                        ontextchanged="txtBuscar_TextChanged" Width="450px" Class="form-control"  placeholder="Busqueda por Matricula/Nombre"></asp:TextBox>
                                                        <span class="input-group-btn">
                                                        <asp:Button ID="btnBuscar" runat="server" class="btn btn-default" onclick="btnBuscar_Click" Text="Buscar" CssClass="btn btn-primary" />
                                                        </span>
                                                    </ContentTemplate>
                                                    </asp:UpdatePanel>       
                                                    <span class="input-group-btn">
                                                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                                        </asp:UpdatePanel>                                                        
                                                    </span>
                                                    </div><!-- /input-group -->                                                 
                                            </td>
                                            </tr>
                                            <tr>
                                                <td align="left">
                                <asp:Panel ID="pnlCatalogo" runat="server" Width="100%">
                                    <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                        <ContentTemplate>
                                            <asp:GridView ID="grdUsuarios" runat="server" AllowPaging="True" 
                                                AutoGenerateColumns="False" 
                                                EmptyDataText="No hay usuarios registrados" GridLines="None" 
                                                onpageindexchanging="grdUsuarios_PageIndexChanging" 
                                                onselectedindexchanging="grdUsuarios_SelectedIndexChanging" 
                                                ShowHeaderWhenEmpty="True" Width="95%" CssClass="mGrid">                                                
                                                <Columns>
                                                    <asp:BoundField DataField="Matricula" HeaderText="Matrícula">
                                                    <FooterStyle HorizontalAlign="Center" />
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Center" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="Nombre" HeaderText="Nombre Alumno">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="TipoPersonaStr" HeaderText="Tipo">
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="StatusMatricula" HeaderText="Estatus">
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                    </asp:BoundField>
                                                    <asp:TemplateField HeaderText="Cambiar Estatus">
                                                        <ItemTemplate>
                                                            <asp:ImageButton ID="ImageButton1" runat="server" 
                                                                ImageUrl='<%# Bind("ImageStatusMatricula") %>' CommandName="Select" 
                                                                CausesValidation="False" OnClick="ImageButton1_Click" />
                                                        </ItemTemplate>
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
                                        <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="txtBuscar" />
                                    </Triggers>
                                    </asp:UpdatePanel>
                                    
                                    <br />
                                    &nbsp; &nbsp;
                                    <input id="Hidden1" type="hidden" />
                                </asp:Panel>
                                                </td>
                                            </tr>
                                        </table>
                                    
                            </td>
                        </tr>
                        <tr>
                            <td align="center" colspan="3">
                                &nbsp; &nbsp;</td>
                        </tr>
                        <tr>
                            <td align="center" colspan="3">
                                &nbsp;<table width="85%">
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="3">
                            </td>
                        </tr>
                        <tr>
                            <td colspan="3">
                            </td>
                        </tr>
                    </table>
                </div>
            </td>
        </tr>
        <tr align="center">
            <td align="center">
            </td>
        </tr>
    </table>
</asp:Content>
