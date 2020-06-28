<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FrmCursos.aspx.cs" Inherits="Recibos_Electronicos.Form.FrmCursos" %>
<%@ Register assembly="CapaNegocio" namespace="CapaNegocio" tagprefix="customControl" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script src="../Scripts/jquery/jquery-3.1.1.min.js"></script>
  <script src="../Scripts/select2/js/select2.min.js"></script>
  <script src="https://ajax.googleapis.com/ajax/libs/angularjs/1.4.8/angular.min.js"></script>
  <link href="../Scripts/select2/css/select2.min.css" type="text/css" rel="stylesheet" />



    <style type="text/css">
                
        
        
        .auto-style2 {
            width: 293px;
        }
        .style3 {
            width: 20%;
        }
        
        
        
        .auto-style9 {
            width: 72%;
        }
        
        
        
        .auto-style13 {
            width: 75%;
        }
        .auto-style14 {
            width: 22%;
        }
                
        
        
        .auto-style15 {
            width: 148px;
        }
                        
        
        
        .auto-style16 {
            width: 28%;
        }
        .auto-style17 {
            width: 7%;
        }
        .auto-style18 {
            width: 5%;
        }
                        
        
        
        .auto-style21 {
            width: 112%;
        }
                        
        
        
    </style>

        <script type="text/javascript">
            function FiltMat() {
                $(".select2").select2();
            }
        </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <table class="tabla_contenido">
        <tr>
            <td>
    <table width="100%">
        <tr>
            <td align="center">
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>                    
                        <table width="100%">
                            <tr valign="top">
                                <td align="left" class="style3">
                                    <asp:Label ID="lblDependencia" runat="server" Text="Dependencia:"></asp:Label>
                                </td>
                                <td align="left" class="auto-style9" colspan="4">
                                    <asp:DropDownList ID="ddlDependencia" runat="server" AutoPostBack="True" onselectedindexchanged="ddlDependencia_SelectedIndexChanged" Width="100%">
                                    </asp:DropDownList>
                                    <br />
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="ddlDependencia" CssClass="MsjError" ErrorMessage="*Requerido" InitialValue="00000" ValidationGroup="guardar"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td align="left" class="style3">
                                    <asp:Label ID="lblCiclo" runat="server" Text="Ciclo Escolar:"></asp:Label>
                                    <br />
                                </td>
                                <td align="left" class="auto-style16">
                                    <customControl:GroupDropDownList ID="ddlCiclo" runat="server">
                                    </customControl:GroupDropDownList>
                                    
                                </td>
                                <td align="left" class="auto-style18">&nbsp;</td>
                                <td align="left" class="auto-style17">
                                    <asp:Label ID="lblStatus" runat="server" Text="Estatus:"></asp:Label>
                                </td>
                                <td align="left" class="auto-style9">
                                    <asp:RadioButtonList ID="rdoListStatus" runat="server" AutoPostBack="True" Height="16px" onselectedindexchanged="rdoListStatus_SelectedIndexChanged" RepeatDirection="Horizontal">
                                        <asp:ListItem Selected="True" Value="A">Activo</asp:ListItem>
                                        <asp:ListItem Value="B">Baja</asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>
                                <td align="left" colspan="5">
                                    <br />
                                    <hr />
                                    <br />
                                </td>
                            </tr>
                        </table>               
                    </ContentTemplate>
                </asp:UpdatePanel>                    
            </td>

<%--            HASTA AQUI--%>
        </tr>
        <tr>
            <td align="center">
                <asp:UpdateProgress ID="UpdateProgress5" runat="server" AssociatedUpdatePanelID="UpdatePanel2">
                    <ProgressTemplate>
                        <asp:Image ID="Image85" runat="server" AlternateText="Espere un momento, por favor.." Height="50px" 
                        ImageUrl="https://sysweb.unach.mx/resources/imagenes/ajax_loader_gray_512.gif" ToolTip="Espere un momento, por favor.." />
                    </ProgressTemplate>
                </asp:UpdateProgress>
                <asp:UpdateProgress ID="UpdateProgress4" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
                    <ProgressTemplate>
                        <asp:Image ID="Image86" runat="server" AlternateText="Espere un momento, por favor.." Height="50px" 
                        ImageUrl="https://sysweb.unach.mx/resources/imagenes/ajax_loader_gray_512.gif" ToolTip="Espere un momento, por favor.." />
                    </ProgressTemplate>
                </asp:UpdateProgress>
            </td>
        </tr>
        <tr>
            <td>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:MultiView ID="MultiView1" runat="server">
                <asp:View ID="View1" runat="server">
                    
                        <table style="width: 100%;">
                        <tr><td>
                            <table width="100%">
                            <tr>
                                    <td align="left" valign="top" class="auto-style21">
                                        <asp:TextBox ID="txtBusca" runat="server" Width="98%"></asp:TextBox>
                                    </td>
                                    <td align="left" valign="top" >
                                        <asp:ImageButton ID="imgBttnBuscar" runat="server" ImageUrl="https://sysweb.unach.mx/resources/imagenes/buscar.png" onclick="imgBttnBuscar_Click" />
                                    </td>
                                </tr>
                            </table>
                        </td></tr>
                        </table>
                    
                        </td>
                        </tr>
                        <tr>
                            <td align="center">
                                <asp:GridView ID="grvCursos" runat="server" AllowPaging="True" AutoGenerateColumns="False" CssClass="mGrid" OnPageIndexChanging="grvCursos_PageIndexChanging" onrowdeleting="grvCursos_RowDeleting" OnSelectedIndexChanging="grvCursos_SelectedIndexChanging" Width="100%" EmptyDataText="No hay cursos de verano registrados." ShowHeaderWhenEmpty="True">
                                    <Columns>
                                        <asp:BoundField DataField="Dependencia" HeaderText="Dependencia" />
                                        <asp:BoundField DataField="DescCarrera" HeaderText="Carrera" />
                                        <asp:BoundField DataField="DescMateria" HeaderText="Materia" />
                                        <asp:BoundField DataField="DescConcepto" HeaderText="Concepto" />
                                        <asp:BoundField DataField="semestre" HeaderText="Semestre">
                                            <ItemStyle HorizontalAlign="Center" /></asp:BoundField>
                                        <asp:BoundField DataField="Importe" HeaderText="Importe" DataFormatString="{0:c}">
                                        <ItemStyle HorizontalAlign="Right" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="IdCurso" HeaderText="Id" />
                                        <asp:CommandField SelectText="Editar" ShowSelectButton="True" ButtonType="Image" SelectImageUrl="https://sysweb.unach.mx/resources/Imagenes/edit.png" >                                            
                                            <ItemStyle HorizontalAlign="Right" /></asp:CommandField>
                                        <asp:TemplateField>
                                            <HeaderTemplate>
                                                <asp:Button ID="bttnNuevo" runat="server" Cssclass="btn btn-blue-grey" Font-Size="XX-Small" OnClick="bttnNuevo_Click" Text="AGREGAR" />
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
                            </td>
                        </tr>
                        </table>
                    
                    </asp:View>
                <asp:View ID="View2" runat="server">
                    <table width="100%">
                        <tr>
                            <td>
                                <ajaxToolkit:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="0" Width="100%" CssClass="ajax__myTab" Height="350px">
                                                        <ajaxToolkit:TabPanel ID="TabPanel1" runat="server" HeaderText="TabPanel1">
                                                            <HeaderTemplate>
                                                                (1) Datos Generales
                                                            </HeaderTemplate>
                                                            <ContentTemplate>
                                                                <table style="width:100%;">
                                                                    <tr>
                                                                        <td align="left" class="style3" valign="top" width="15%">
                                                                            <asp:Label ID="lblCarrera" runat="server" Text="Programa:"></asp:Label>
                                                                        </td>
                                                                        <td class="auto-style13" colspan="3" valign="top" width="40%">
                                                                            <asp:DropDownList ID="ddlPrograma" runat="server" AutoPostBack="True" ClientIDMode="Predictable" OnSelectedIndexChanged="ddlPrograma_SelectedIndexChanged" TabIndex="5" Width="90%">
                                                                            </asp:DropDownList>
                                                                            <br />
                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator23" runat="server" ControlToValidate="ddlPrograma" CssClass="MsjError" ErrorMessage="*Requerido" InitialValue="0" ValidationGroup="guardar"></asp:RequiredFieldValidator>
                                                                            <br />
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="left" class="style3" valign="top" width="15%">
                                                                            <asp:Label ID="lblPlan" runat="server" Text="Plan:"></asp:Label>
                                                                        </td>
                                                                        <td colspan="3" valign="top">
                                                                            <asp:DropDownList ID="ddlPlan" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlPlan_SelectedIndexChanged" Width="90%">
                                                                            </asp:DropDownList>
                                                                            <br />
                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator30" runat="server" ControlToValidate="ddlPlan" CssClass="MsjError" ErrorMessage="*Requerido" InitialValue="0" ValidationGroup="guardar"></asp:RequiredFieldValidator>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="left" class="style3" valign="top" width="15%">
                                                                            <asp:Label ID="lblMateria" runat="server" Text="Materia:"></asp:Label>
                                                                        </td>
                                                                        <td colspan="3" valign="top">
                                                                            <asp:DropDownList ID="ddlMateria" runat="server" AutoPostBack="True" CssClass="select2" OnSelectedIndexChanged="ddlMateria_SelectedIndexChanged" TabIndex="5" Width="90%">
                                                                            </asp:DropDownList>
                                                                            <br />
                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator25" runat="server" ControlToValidate="ddlMateria" CssClass="MsjError" ErrorMessage="*Requerido" InitialValue="0" ValidationGroup="guardar"></asp:RequiredFieldValidator>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="left" class="style3" valign="top" width="15%">
                                                                            <asp:Label ID="lblMateria_Opt" runat="server" Text="Optativa:"></asp:Label>
                                                                        </td>
                                                                        <td colspan="3" valign="top">
                                                                            <asp:DropDownList ID="ddlMateria_Opt" runat="server" CssClass="select2" TabIndex="5" Width="90%">
                                                                            </asp:DropDownList>
                                                                            <br />
                                                                        </td>
                                                                    </tr>
                                                                    <caption>
                                                                        <br />
                                                                        </tr>
                                                                        <tr valign="top">
                                                                            <td align="left" class="style3" valign="top" width="15%">
                                                                                <asp:Label ID="lblSemestre" runat="server" Text="Semestre:"></asp:Label>
                                                                            </td>
                                                                            <td class="auto-style14" valign="top">
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
                                                                                <br />
                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator24" runat="server" ControlToValidate="ddlSemestre" CssClass="MsjError" ErrorMessage="*Requerido" ValidationGroup="guardar" InitialValue="0"></asp:RequiredFieldValidator>
                                                                                <br />
                                                                            </td>
                                                                            <td align="right" class="auto-style2" valign="top">
                                                                                <asp:Label ID="lblImporte" runat="server" Text="Importe:"></asp:Label>
                                                                            </td>
                                                                            <td valign="top" width="35%">
                                                                                <asp:TextBox ID="txtImporte" runat="server"></asp:TextBox>
                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator29" runat="server" ControlToValidate="txtImporte" CssClass="MsjError" ErrorMessage="*Requerido" ValidationGroup="guardar"></asp:RequiredFieldValidator>
                                                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txtImporte" CssClass="MsjError" ErrorMessage="*Solo Números" ValidationExpression="^(-?\d{0,13}\.\d{0,2}|\d{0,13})$" ValidationGroup="guardar"></asp:RegularExpressionValidator>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td align="center" colspan="4" width="100%">
                                                                                &#160;</td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td align="right" class="style3" width="15%">&#160;</td>
                                                                            <td colspan="3" width="85%">&#160;</td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td align="right" class="style3" width="15%">&#160;</td>
                                                                            <td colspan="3" width="85%">&#160;</td>
                                                                            <td>&#160;</td>
                                                                        </tr>
                                                                    </caption>
                                                                </table>
                                                            </ContentTemplate>
                                                        </ajaxToolkit:TabPanel>
                                                        <ajaxToolkit:TabPanel ID="TabPanel2" runat="server" HeaderText="TabPanel2">
                                                            <HeaderTemplate>
                                                                (2) Oficios
                                                            </HeaderTemplate>
                                                            <ContentTemplate>
                                                                <table style="width:100%;">
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
                                                                                                    <asp:Button ID="bttnAgregaOficio" runat="server" Cssclass="btn btn-blue-grey" Font-Size="Smaller" OnClick="bttnAgregaOficio_Click" Text="ADJUNTAR" Width="100px" />
                                                                                                    <br />
                                                                                                </td>
                                                                                            </tr>
                                                                                        </table>
                                                                                    </ContentTemplate>
                                                                                    <triggers>
                                                                                        <asp:PostBackTrigger ControlID="bttnAgregaOficio" />
                                                                                    </triggers>
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
                                                        </ajaxToolkit:TabPanel>
                                                    </ajaxToolkit:TabContainer>
                            </td>
                        </tr>
                        <tr>
                            <td class="centro">
                                <asp:Button ID="btnGuardar_Nuevo" runat="server" Cssclass="btn btn-info" OnClick="btnGuardar_Nuevo_Click" TabIndex="20" Text="GUARDAR Y CONTINUAR" ValidationGroup="guardar" />
&nbsp;<asp:Button ID="btnGuardar_Salir" runat="server" CssClass="btn btn-primary" OnClick="btnGuardar_Salir_Click" Text="GUARDAR Y SALIR" ValidationGroup="guardar_conceptos" />
                                &nbsp;<asp:Button ID="btnCancelar" runat="server" CssClass="btn btn-blue-grey" OnClick="btnCancelar_Click" TabIndex="21" Text="SALIR" />
                                &nbsp;&nbsp;</td>
                        </tr>
                    </table>
                    

                </asp:View>
                
            </asp:MultiView>
        </ContentTemplate>
    </asp:UpdatePanel></td>
        </tr>
        <tr>
            <td class="centro">
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
        </tr>
    </table>

    
            </td>
        </tr>
    </table>


</asp:Content>
