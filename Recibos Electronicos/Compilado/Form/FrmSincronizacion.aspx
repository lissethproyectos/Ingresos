<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="FrmSincronizacion.aspx.cs" Inherits="Recibos_Electronicos.Form.FrmSincronizacion" %>
    
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
   
    <style type="text/css">
        .style1
        {
            width: 825px;
        }
        .style3
        {
        }
        .style4
        {
            width: 529px;
        }
        .style6
        {
            width: 414px;
        }
        .style7
        {
        }
        .style8
        {}
        .style9
        {
            width: 246px;
        }
    </style>
      <link href="../Css/Tab.css" rel="stylesheet" type="text/css" />    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    &nbsp;<asp:UpdatePanel ID="UpdatePanel2" runat="server">
        <ContentTemplate>
            <table style="width: 100%;">
                <tr>
                    <td align="center" colspan="3">
                        <br />
                        <asp:Label ID="lblMsj" runat="server" ForeColor="Red"></asp:Label>
                        <asp:MultiView ID="mltViewSauce" runat="server">
                            <asp:View ID="vwSincroniza" runat="server">
                                <table style="width: 100%;">
                                    <tr>
                                        <td align="left" valign="top">
                                            &nbsp;</td>
                                        <td class="style4">
                                            &nbsp;
                                        </td>
                                        <td>
                                            <asp:ImageButton ID="imgBttnConsulta_Mat" runat="server" ImageUrl="../Imagenes/btnConsultar_Mat.png"
                                                OnClick="imgBttnConsulta_Mat_Click" Visible="False" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left" valign="top" colspan="3" width="80%">
                                            &nbsp; &nbsp; &nbsp;
                                            <table align="center" width="100%">
                                                <tr>
                                                    <td>
                                                        &nbsp;</td>
                                                    <td>
                                                        &nbsp;</td>
                                                    <td>
                                                        &nbsp;</td>
                                                </tr>
                                                <tr>
                                                    <td colspan="3">
                                                        <ajaxToolkit:TabContainer ID="TabContainerDatos" runat="server" ActiveTabIndex="1"
                                                        CssClass="ajax__myTab" Width="100%">
                                                            <ajaxToolkit:TabPanel ID="TabPanel1" runat="server" >
                                                             <HeaderTemplate>                                                                
                                                                SINCRONIZACIÓN
                                                            </HeaderTemplate>
                                                                <ContentTemplate>
                                                                    
                                                                    <table align="center" frame="border" width="100%">
                                                                        <tr>
                                                                            <td>
                                                                                &#160;</td>
                                                                            <td>
                                                                                &#160;</td>
                                                                            <td>
                                                                                &#160;</td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td colspan="3">
                                                                                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                                                                    <ContentTemplate>
                                                                                        <asp:GridView ID="grvRegistros" runat="server" AllowPaging="True" 
                                                                                            AutoGenerateColumns="False"
                                                                                            EmptyDataText="La matrícula no ha realizado pagos" 
                                                                                            OnPageIndexChanging="grvRegistros_PageIndexChanging" 
                                                                                            onselectedindexchanged="grvRegistros_SelectedIndexChanged" Width="100%" CssClass="mGrid">                                                                                            
                                                                                            <Columns>
                                                                                                <asp:BoundField DataField="Tipo" HeaderText="Tipo" />
                                                                                                <asp:BoundField DataField="Ingresos" HeaderText="Registros INGRESOS" />
                                                                                                <asp:BoundField DataField="Sauce" HeaderText="Registros SAUCE" />
                                                                                                <asp:BoundField DataField="PendienteSincronizar" 
                                                                                                    HeaderText="Pendientes de Sincronizar" />
                                                                                                <asp:BoundField DataField="UltimaActualizacion" 
                                                                                                    HeaderText="Ultima Actualización" />
                                                                                                <asp:CommandField SelectText="Sincronizar" ShowSelectButton="True" 
                                                                                                    Visible="False" />
                                                                                                <asp:TemplateField HeaderText="Acción">
                                                                                                    <ItemTemplate>
                                                                                                        <asp:LinkButton ID="linkSincronizar" runat="server" 
                                                                                                            CommandArgument='<%# DataBinder.Eval(Container.DataItem, "TIPO") %>' 
                                                                                                            CommandName="Select" ForeColor="#333333" OnClick="linkSincronizar_Click" 
                                                                                                            OnClientClick="return confirm('Esta proceso puede tardar varios minutos, ¿desea continuar?');">Sincronizar</asp:LinkButton>
                                                                                                    </ItemTemplate>
                                                                                                </asp:TemplateField>
                                                                                                <asp:ImageField DataImageUrlField="status1" 
                                                                                                    DataImageUrlFormatString="~/Imagenes/imagen{0}.png">
                                                                                                </asp:ImageField>
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
                                                                            <td colspan="3">
                                                                                <asp:UpdateProgress ID="UpdateProgress2" runat="server" 
                                                                                    AssociatedUpdatePanelID="UpdatePanel1">
                                                                                    <progresstemplate>
                                                                                        <span>
                                                                                        <img height="26" src="../Imagenes/load.gif" width="222" />
                                                                                        </span><span class="loading">Sincronizacion en Proceso…
                                                                                        </span>
                                                                                    </progresstemplate>
                                                                                </asp:UpdateProgress>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                &#160;</td>
                                                                            <td>
                                                                                &#160;</td>
                                                                            <td>
                                                                                &#160;</td>
                                                                        </tr>
                                                                    </table>
                                                                    
                                                                </ContentTemplate>
                                                            </ajaxToolkit:TabPanel>
                                                             <ajaxToolkit:TabPanel ID="TabPanel2" runat="server">
                                                              <HeaderTemplate>                                                                
                                                                VISTAS MATERIALIZADAS INHABILES
                                                            </HeaderTemplate>
                                                                <ContentTemplate>
                                                                   
                                                                    <table style="width:100%;">
                                                                        <tr>
                                                                            <td class="style8">
                                                                                &#160;</td>
                                                                            <td class="style9">
                                                                                &#160;</td>
                                                                            <td>
                                                                                &#160;</td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td class="style8" colspan="3">
                                                                                <asp:GridView ID="grvInhabiles" runat="server" AllowPaging="True" 
                                                                                    AutoGenerateColumns="False"
                                                                                    EmptyDataText="NO HAY VISTAS MATERIALIZAS INHABILES"
                                                                                    OnPageIndexChanging="grvRegistros_PageIndexChanging" Width="100%" 
                                                                                    onselectedindexchanged="rgv_SelectedIndexChanged" CssClass="mGrid">                                                                                    
                                                                                    <Columns>
                                                                                        <asp:BoundField DataField="objeto" HeaderText="Objeto" />
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
                                                                            <td class="style8">
                                                                                &#160;</td>
                                                                            <td class="style9">
                                                                                &#160;</td>
                                                                            <td style="text-align: right">
                                                                                <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                                                                                    <ContentTemplate>
                                                                                        <asp:Button ID="btnhabilitar" runat="server" Cssclass="btn btn-blue-grey" 
                                                                                            Text="HABILITAR" onclick="btnhabilitar_Click" />
                                                                                    </ContentTemplate>
                                                                                </asp:UpdatePanel>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                   
                                                                </ContentTemplate>
                                                            </ajaxToolkit:TabPanel>
                                                            <ajaxToolkit:TabPanel ID="TabPanel3" runat="server" >
                                                                 <HeaderTemplate>                                                                
                                                              VISTAS MATERIALIZADAS
                                                            </HeaderTemplate>
                                                                <ContentTemplate>                                                                   
                                                                    <table style="width:100%;">
                                                                        <tr>
                                                                            <td colspan="3">
                                                                                <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                                                                    <ContentTemplate>
                                                                                        <asp:GridView ID="rgvVMaterializadas" runat="server" AllowPaging="True" 
                                                                                            AutoGenerateColumns="False"
                                                                                            EmptyDataText="La matrícula no ha realizado pagos"
                                                                                            OnPageIndexChanging="rgvVMaterializadas_PageIndexChanging" 
                                                                                            OnSelectedIndexChanged="rgvVMaterializadas_SelectedIndexChanged" Width="100%" CssClass="mGrid">                                                                                            
                                                                                            <Columns>
                                                                                                <asp:BoundField DataField="name" 
                                                                                                    HeaderText="Nombre de la Vista Materializada" />
                                                                                                <asp:BoundField DataField="fecha" HeaderText="Fecha Refresh" />
                                                                                                <asp:BoundField DataField="hora" HeaderText="Ultima Refrescada" />
                                                                                                <asp:CommandField SelectText="Sincronizar" ShowSelectButton="True" 
                                                                                                    Visible="False" />
                                                                                                <asp:TemplateField HeaderText="Acción">
                                                                                                    <ItemTemplate>
                                                                                                        <asp:LinkButton ID="refresh" runat="server" onclick="refresh_Click">Refrescar</asp:LinkButton>
                                                                                                    </ItemTemplate>
                                                                                                </asp:TemplateField>
                                                                                                <asp:ImageField DataImageUrlField="status" 
                                                                                                    DataImageUrlFormatString="~/Imagenes/imagen{0}.png" ReadOnly="True">
                                                                                                </asp:ImageField>
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
                                                                            <td colspan="3">
                                                                                &#160;</td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                &#160;</td>
                                                                            <td>
                                                                                &#160;</td>
                                                                            <td>
                                                                                &#160;</td>
                                                                        </tr>
                                                                    </table>
                                                                   
                                                                </ContentTemplate>
                                                            </ajaxToolkit:TabPanel>
                                                        </ajaxToolkit:TabContainer>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        &nbsp;</td>
                                                    <td>
                                                        &nbsp;</td>
                                                    <td>
                                                        &nbsp;</td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                   
                                </table>
                            </asp:View>
                            <asp:View ID="vwConsulaMat" runat="server">
                                <table style="width: 100%;">
                                    <tr>
                                        <td class="style7">
                                            &nbsp;
                                        </td>
                                        <td class="style6">
                                            &nbsp;
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" class="style7">
                                            <asp:Label ID="lblMatricula" runat="server" Text="Matricula:"></asp:Label>
                                        </td>
                                        <td align="left" class="style6">
                                            <asp:TextBox ID="txtMatricula" runat="server"></asp:TextBox>
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" class="style7">
                                            <asp:Label ID="lblNombre" runat="server" Text="Nombre:"></asp:Label>
                                        </td>
                                        <td align="left" class="style6">
                                            <asp:TextBox ID="txtNombre" runat="server" Width="400px" Enabled="False" ReadOnly="True"></asp:TextBox>
                                            &nbsp;
                                        </td>
                                        <td align="left">
                                            <asp:Button ID="btnConsultar" runat="server" CssClass="btn3" Text="CONSULTAR" OnClick="btnConsultar_Click" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center" class="style3" colspan="3">
                                            <asp:GridView ID="grvDatos_Grals" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                                                OnPageIndexChanging="grvDatos_Grals_PageIndexChanging" CssClass="mGrid">                                                
                                                <Columns>
                                                    <asp:BoundField DataField="BaseDatos" HeaderText="Base Datos" />
                                                    <asp:BoundField DataField="Clasificacion" HeaderText="Clasificación" />
                                                    <asp:BoundField DataField="Tipo" HeaderText="Tipo" />
                                                    <asp:BoundField DataField="Matricula" HeaderText="Matricula" />
                                                    <asp:BoundField DataField="Dependencia" HeaderText="Dependencia" />
                                                    <asp:BoundField DataField="Status" HeaderText="Estatus" />
                                                    <asp:BoundField DataField="Fecha" HeaderText="Fecha" />
                                                    <asp:BoundField DataField="Referencia" HeaderText="Referencia" />
                                                    <asp:BoundField DataField="Banco" HeaderText="Banco" />
                                                    <asp:BoundField DataField="Folio" HeaderText="Folio" />
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
                                        <td align="left" class="style7">
                                            &nbsp;
                                        </td>
                                        <td class="style6">
                                            &nbsp;
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center" class="style7" colspan="3">
                                            <asp:Button ID="btnRegresar" runat="server" CssClass="btn3" Height="36px" Text="REGRESAR"
                                                OnClick="btnRegresar_Click" />
                                        </td>
                                    </tr>
                                </table>
                            </asp:View>
                        </asp:MultiView>
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;
                    </td>
                    <td class="style1">
                        &nbsp;
                    </td>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;
                    </td>
                    <td class="style1">
                        &nbsp;
                    </td>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;
                    </td>
                    <td class="style1">
                        &nbsp;
                    </td>
                    <td>
                        &nbsp;
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel2">
        <ProgressTemplate>
            <asp:Image ID="Image1q" runat="server" Height="30px" ImageUrl="~/Imagenes/ajax_loader_gray_512.gif"
                Width="30px" ImageAlign="Middle" />
        </ProgressTemplate>
    </asp:UpdateProgress>
</asp:Content>
