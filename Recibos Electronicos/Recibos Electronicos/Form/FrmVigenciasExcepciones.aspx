<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FrmVigenciasExcepciones.aspx.cs" Inherits="Recibos_Electronicos.Form.FrmVigenciasExcepciones" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 34px;
        }
        .auto-style2 {
            width: 167px;
        }
        .auto-style3 {
            width: 64px;
        }
        .auto-style4 {
            width: 1002px;
        }
        .auto-style5 {
            width: 14px;
        }
        .auto-style6 {
            width: 100px;
        }
        .auto-style7 {
            width: 100px;
            height: 26px;
        }
        .auto-style8 {
            height: 26px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <table style="width:100%;" class="tabla_contenido">
        <tr>
            <td class="auto-style1" valign="top">
                                                    <asp:Label ID="lblDependencia" runat="server" Text="Dependencia:"></asp:Label>
            </td>
            <td class="auto-style4">
                <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddlDependencia" runat="server" ClientIDMode="Predictable" Width="100%">
                        </asp:DropDownList>
                        &nbsp;
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td class="auto-style3" align="right">
                &nbsp;</td>
            <td>
                <table style="width:100%;">
                    <tr>
                        <td class="auto-style5">
                                                                <asp:ImageButton ID="imgBttnBuscar" runat="server" ImageUrl="https://sysweb.unach.mx/resources/imagenes/buscar.png" onclick="imgBttnBuscar_Click" />
                                                            </td>
                        <td>
                                                                <asp:ImageButton ID="imgBttnNuevo" runat="server" ImageUrl="https://sysweb.unach.mx/resources/imagenes/nuevo.png" OnClick="imgBttnNuevo_Click" ValidationGroup="Nuevo" />
                                                            </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td colspan="4">
                <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                    <ContentTemplate>
                        <asp:GridView ID="grdVigencias" runat="server" AutoGenerateColumns="False" CssClass="mGrid3" Width="100%" OnRowCancelingEdit="grdVigencias_RowCancelingEdit" OnRowEditing="grdVigencias_RowEditing" OnRowUpdating="grdVigencias_RowUpdating">
                            <Columns>
                                <asp:BoundField DataField="Dependencia" HeaderText="DEPENDENCIA" ReadOnly="True" />
                                <asp:BoundField DataField="Carrera" HeaderText="CARRERA" ReadOnly="True" >
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="FechaInicial" HeaderText="FECHA INICIAL" >
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="FechaFinal" HeaderText="FECHA FINAL" >
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="ClaveConcepto" HeaderText="CONCEPTO" ReadOnly="True" />
                                <asp:CommandField ShowEditButton="True" CancelText="CANCELAR" DeleteText="ELIMINAR" EditText="EDITAR" UpdateText="ACTUALIZAR" ButtonType="Image" EditImageUrl="~/Imagenes/edit.png" />
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
            <td class="auto-style1">
                <asp:HiddenField ID="hddnVigencias" runat="server" />
                <ajaxToolkit:ModalPopupExtender ID="modalVigencias" runat="server" PopupControlID="pnlVigencias" TargetControlID="hddnVigencias" BackgroundCssClass="modalBackground_Proy">
                </ajaxToolkit:ModalPopupExtender>
            </td>
            <td class="auto-style2" colspan="2">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style1">&nbsp;</td>
            <td class="auto-style2" colspan="2">
                <asp:Panel ID="pnlVigencias" runat="server" Width="60%" CssClass="TituloModalPopupMsg">
                    <table style="width:100%;">
                        <tr>
                            <td class="auto-style6">&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="auto-style6">
                                <asp:Label ID="lblDependenciaA" runat="server" Text="Dependencia:"></asp:Label>
                            </td>
                            <td>
                                <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                                    <ContentTemplate>
                                        <asp:DropDownList ID="ddlDependenciaA" runat="server" AutoPostBack="True" ClientIDMode="Predictable" OnSelectedIndexChanged="ddlDependenciaA_SelectedIndexChanged" Width="100%">
                                        </asp:DropDownList>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="auto-style7">
                                <asp:Label ID="lblCarrera" runat="server" Text="Carrera:"></asp:Label>
                            </td>
                            <td class="auto-style8">
                                <asp:UpdatePanel ID="updPnlCarrera" runat="server">
                                    <ContentTemplate>
                                        <asp:DropDownList ID="ddlCarrera" runat="server">
                                        </asp:DropDownList> 
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                            <td class="auto-style8"></td>
                        </tr>
                        <tr>
                            <td class="auto-style6">
                                <asp:Label ID="lblFechaInicial" runat="server" Text="Fecha Ini:"></asp:Label>
                            </td>
                            <td>
<table width="100%"  >
                                                                            <tr>
                                                                                <td>
                                                                                    <asp:TextBox ID="txtFechaInicial" runat="server" Enabled="False" Width="80px"></asp:TextBox>
                                                                                
                                                                                    <ajaxToolkit:CalendarExtender ID="CalendarExtenderIni" runat="server" TargetControlID="txtFechaInicial" PopupButtonID="imgCalendarioIni" BehaviorID="_content_CalendarExtenderIni" />
                                                                                    <asp:ImageButton ID="imgCalendarioIni" runat="server" ImageUrl="https://sysweb.unach.mx/resources/imagenes/calendario.gif"/>
                                                                                </td>
                                                                                <td class="auto-style42" align="right">
                                                                                    <asp:Label ID="lblFechaFinal" runat="server" Text="Fecha Fin:"></asp:Label>
                                                                                </td>
                                                                                <td>
                                                                                    <asp:TextBox ID="txtFechaFinal" runat="server" Enabled="False" Width="80px"></asp:TextBox>
                                                                                    <ajaxToolkit:CalendarExtender ID="CalendarExtenderFin" runat="server" PopupButtonID="imgCalendarioFin" TargetControlID="txtFechaFinal" BehaviorID="_content_CalendarExtenderFin" />
                                                                                    <asp:ImageButton ID="imgCalendarioFin" runat="server" ImageUrl="https://sysweb.unach.mx/resources/imagenes/calendario.gif" />
                                                                                </td>
                                                                            </tr>
                                                                        </table>                            </td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="auto-style6">&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="auto-style6">&nbsp;</td>
                            <td align="center">                                                                                                            <asp:Button ID="bttnSalirEmp" runat="server" Cssclass="btn btn-blue-grey" OnClick="bttnSalirEmp_Click" Text="SALIR" />
                                                                                                            &nbsp;<asp:Button ID="bttnAgregar" runat="server" Cssclass="btn btn-blue-grey" OnClick="bttnAgregar_Click" Text="AGREGAR" ValidationGroup="Empleado" />
</td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="auto-style6">&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                    </table>
                </asp:Panel>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style1">&nbsp;</td>
            <td class="auto-style2" colspan="2">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style1">&nbsp;</td>
            <td class="auto-style2" colspan="2">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style1">&nbsp;</td>
            <td class="auto-style2" colspan="2">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    </table>
</asp:Content>
