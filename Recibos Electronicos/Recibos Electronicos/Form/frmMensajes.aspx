<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmMensajes.aspx.cs" Inherits="Recibos_Electronicos.Form.frmMensajes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .auto-style2 {
            width: 104px;
        }
        .auto-style3 {
            width: 104px;
            height: 18px;
        }
        .auto-style4 {
            height: 18px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <table style="width: 100%;">
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>
               
            </td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td colspan="3">
                 <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                     <ContentTemplate>
<asp:MultiView ID="MultiView1" runat="server">
                    <asp:View ID="View2" runat="server">
                        <table style="width:100%;">
                            <tr>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td align="right">
                                    <asp:ImageButton ID="imgBttnNuevo" runat="server" ImageUrl="https://sysweb.unach.mx/resources/imagenes/nuevo.png" OnClick="imgBttnNuevo_Click" />
                                </td>
                            </tr>
                            <tr>
                                <td colspan="3">
                                    <asp:GridView ID="grvMensajes" runat="server" AllowPaging="True" AutoGenerateColumns="False" CssClass="mGrid" OnPageIndexChanging="grvMensajes_PageIndexChanging" PageSize="15" Width="100%" OnRowDeleting="grvMensajes_RowDeleting" OnSelectedIndexChanged="grvMensajes_SelectedIndexChanged">
                                        <Columns>
                                            <asp:BoundField DataField="IdMensaje" HeaderText="IdMensaje" />
                                            <asp:BoundField DataField="Tipo_Usuario" HeaderText="Tipo Usuario" />
                                            <asp:BoundField DataField="TMensaje" HeaderText="Mensaje"></asp:BoundField>
                                            <asp:BoundField DataField="Status" HeaderText="Status">
                                            <ItemStyle HorizontalAlign="Center" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="Fecha_inicial" HeaderText="Fecha Inicial" />
                                            <asp:BoundField DataField="Fecha_inicial" HeaderText="Fecha Final" />
                                            <asp:CommandField ButtonType="Image" SelectImageUrl="https://sysweb.unach.mx/resources/Imagenes/edit.png" SelectText="" ShowSelectButton="True" />
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:ImageButton ID="imgBttnCancelar" runat="server" CommandName="Delete" ImageUrl="https://sysweb.unach.mx/resources/Imagenes/del.png" OnClientClick="return confirm('¿Desea eliminar el registro?');" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                        <FooterStyle CssClass="enc" />
                                        <PagerStyle CssClass="enc" HorizontalAlign="Center" />
                                        <SelectedRowStyle CssClass="sel" />
                                        <HeaderStyle CssClass="enc" />
                                        <AlternatingRowStyle CssClass="alt" />
                                    </asp:GridView>
                                </td>
                            </tr>
                            <tr>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                            </tr>
                        </table>
                    </asp:View>
                    <asp:View ID="View1" runat="server">
                        <table style="width:100%;">
                            <tr>
                                <td class="auto-style2">&nbsp;</td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td class="auto-style2" valign="top">
                                    <asp:Label ID="lblTipo" runat="server" Text="Tipo de Usuario:"></asp:Label>
                                </td>
                                <td valign="top">
                                    <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                                        <ContentTemplate>
                                            <asp:DropDownList ID="DDLTipoUsu" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DDLTipoUsu_SelectedIndexChanged">
                                                <asp:ListItem Value="3">Usuario Dependencia</asp:ListItem>
                                                <asp:ListItem Value="1">Alumno</asp:ListItem>
                                            </asp:DropDownList>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </td>
                                <td valign="top">&nbsp;</td>
                                <td valign="top">&nbsp;</td>
                            </tr>
                            <tr>
                                <td class="auto-style3" valign="top">
                                    <asp:Label ID="lblDependencia" runat="server" Text="Dependencia:"></asp:Label>
                                </td>
                                <td class="auto-style4" valign="top" colspan="3">
                                    <asp:DropDownList ID="ddlDependencia" runat="server" Width="100%">
                                    </asp:DropDownList>

                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style3" valign="top">
                                    <asp:Label ID="lblFecha_Inicial" runat="server" Text="Fecha Inicial:"></asp:Label>
                                </td>
                                <td class="auto-style4" valign="top">
                                    <asp:TextBox ID="txtFecha_Inicial" runat="server"></asp:TextBox>
                                    <ajaxToolkit:CalendarExtender ID="CalendarExtenderIni" runat="server" PopupButtonID="imgCalendarioIni" TargetControlID="txtFecha_Inicial" />
                                    <asp:ImageButton ID="imgCalendarioIni" runat="server" ImageUrl="https://sysweb.unach.mx/resources/imagenes/calendario.gif" />
                                </td>
                                <td class="auto-style4" valign="top">
                                    <asp:Label ID="lblFecha_Final" runat="server" Text="Fecha Final:"></asp:Label>
                                </td>
                                <td class="auto-style4" valign="top">
                                    <asp:TextBox ID="txtFecha_Final" runat="server"></asp:TextBox>
                                    <ajaxToolkit:CalendarExtender ID="CalendarExtenderFin" runat="server" PopupButtonID="imgCalendarioFin" TargetControlID="txtFecha_Final" />
                                    <asp:ImageButton ID="imgCalendarioFin" runat="server" ImageUrl="https://sysweb.unach.mx/resources/imagenes/calendario.gif" />
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style2" valign="top">
                                    <asp:Label ID="lblStatus" runat="server" Text="Status:"></asp:Label>
                                </td>
                                <td valign="top">
                                    <asp:RadioButtonList ID="rdoBttnStatus" runat="server" RepeatDirection="Horizontal">
                                        <asp:ListItem Selected="True" Value="A">Activo</asp:ListItem>
                                        <asp:ListItem Value="B">Baja</asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>
                                <td valign="top">&nbsp;</td>
                                <td valign="top">&nbsp;</td>
                            </tr>
                            <tr valign="top">
                                <td class="auto-style2" valign="top">
                                    <asp:Label ID="lblMensaje" runat="server" Text="Mensaje:"></asp:Label>
                                </td>
                                <td colspan="3" valign="top">
                                    <asp:TextBox ID="txtMensaje" runat="server" TextMode="MultiLine"></asp:TextBox>
                                    <ajaxToolkit:HtmlEditorExtender ID="editorMensaje" runat="server" DisplaySourceTab="True" TargetControlID="txtMensaje" EnableSanitization="False">
                                        <Toolbar> 
                <ajaxToolkit:Undo />
                <ajaxToolkit:Redo />
                <ajaxToolkit:Bold />
                <ajaxToolkit:Italic />
                <ajaxToolkit:Underline />
                <ajaxToolkit:StrikeThrough />
                <ajaxToolkit:Subscript />
                <ajaxToolkit:Superscript />
                <ajaxToolkit:JustifyLeft />
                <ajaxToolkit:JustifyCenter />
                <ajaxToolkit:JustifyRight />
                <ajaxToolkit:JustifyFull />
                <ajaxToolkit:InsertOrderedList />
                <ajaxToolkit:InsertUnorderedList />
                <ajaxToolkit:CreateLink />
                <ajaxToolkit:UnLink />
                <ajaxToolkit:RemoveFormat />
                <ajaxToolkit:SelectAll />
                <ajaxToolkit:UnSelect />
                <ajaxToolkit:Delete />
                <ajaxToolkit:Cut />
                <ajaxToolkit:Copy />
                <ajaxToolkit:Paste />
                <ajaxToolkit:BackgroundColorSelector />
                <ajaxToolkit:ForeColorSelector />
                <ajaxToolkit:FontNameSelector />
                <ajaxToolkit:FontSizeSelector />
                <ajaxToolkit:Indent />
                <ajaxToolkit:Outdent />
                <ajaxToolkit:InsertHorizontalRule />
                <ajaxToolkit:HorizontalSeparator />
                <ajaxToolkit:InsertImage />
            </Toolbar>
                                    </ajaxToolkit:HtmlEditorExtender>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style2">&nbsp;</td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td align="center" colspan="4">
                                    <asp:Button ID="btnGuardar" runat="server" Cssclass="btn btn-blue-grey" Height="45px" OnClick="btnGuardar_Click" TabIndex="15" Text="GUARDAR" ValidationGroup="guardar" />
                                    &nbsp;<asp:Button ID="btnCancelar" runat="server" CssClass="btn btn-blue-grey" Height="45px" OnClick="btnCancelar_Click" TabIndex="16" Text="CANCELAR" />
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style2">&nbsp;</td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td class="auto-style2">&nbsp;</td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                            </tr>
                        </table>
                    </asp:View>
                </asp:MultiView>
                     </ContentTemplate>
                </asp:UpdatePanel>
                
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    </table>
</asp:Content>
